using MavLinkPal.MavLinkProtocol;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Sockets;

namespace MavLinkPal
{
    public sealed class MavLinkParser
    {
        private readonly ILogger<MavLinkParser> _logger;
        private readonly Common _common;
        
        private readonly Mutex _mutex = new();
        private IPEndPoint _endPoint;
        private UdpClient _udpClient;
        private bool _disposed;

        public MavLinkParser(ILogger<MavLinkParser> logger, Common common)
        {
            _logger = logger;
            _common = common;
        }

        public void Run()
        {
            _logger.LogInformation($"{nameof(MavLinkParser)} task started.");

            try
            {
                _endPoint = new IPEndPoint(IPAddress.Parse(_common.Host), _common.Port);

                _udpClient = new UdpClient(_endPoint);

                while (!_common.ShouldStopTask)
                {
                    IAsyncResult result = _udpClient.BeginReceive(AsyncRecv, this);

                    // Always time out, Never block
                    result.AsyncWaitHandle.WaitOne(1000);

                    if (Console.KeyAvailable)
                    {
                        if (Console.ReadKey(true).Key == ConsoleKey.Q)
                        {
                            _logger.LogInformation("Q was pressed. Quiting the program...");

                            _common.CancelTasks();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                Dispose();

                _common.CancelTasks();
            
                _logger.LogInformation($"{nameof(MavLinkParser)} task ended.");
            }
        }

        /// <summary>
        /// Delegate that is invoked when packet is received.
        /// </summary>
        /// <param name="result"></param>
        private void AsyncRecv(IAsyncResult result)
        {
            var instance = (MavLinkParser)result.AsyncState;

            try
            {
                instance._mutex.WaitOne();

                if (result.IsCompleted)
                {
                    var packet = instance._udpClient.EndReceive(result, ref instance._endPoint);

                    instance.ParseMessage(ref packet);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                instance._mutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// stop running and exit.
        /// </summary>
        private void Stop()
        {
            _common.CancelTasks();
        }

        private void ParseMessage(ref byte[] packet)
        {
            // We need to be able to read at least the length of the payload
            for (int offset = 0; offset < packet.Length; offset++)
            {
                if (packet[offset] == Message.StartMarker)
                {
                    if (packet.Length < offset + Message.LengthMin || packet.Length > Message.LengthMax)
                    {
                        _logger.LogWarning($"Invalid MessageLength({packet.Length - offset}), " +
                            $"must be between {Message.LengthMin} and {Message.LengthMax}.");

                        break;
                    }

                    var payloadLength = packet[offset + Message.OffsetPayloadLength];

                    // Sanity check, ditch this packet just in case
                    if (packet.Length < offset + payloadLength + Message.LengthMin)
                    {
                        _logger.LogWarning($"Invalid MessageLength({packet.Length - offset}) < " +
                            $"PayloadLength({payloadLength}) + MessageLengthMin({Message.LengthMin}).");

                        break;
                    }

                    var messageId = packet[offset + Message.OffsetMessageId] +
                        (uint)(packet[offset + Message.OffsetMessageId + 1] << 8) +
                        (uint)(packet[offset + Message.OffsetMessageId + 2] << 16);

                    if (!_common.MessageIds.Contains((int)messageId)) break;

                    IMessage message = null;

                    switch (messageId)
                    {
                        case 000:
                            message = new Heartbeat();
                            break;
                        case 001:
                            message = new SysStatus();
                            break;
                        case 024:
                            message = new GpsRawInt();
                            break;
                        case 030:
                            message = new Attitude();
                            break;
                        case 035:
                            message = new RcChannelsRaw();
                            break;
                        case 074:
                            message = new VfrHud();
                            break;
                        case 147:
                            message = new BatteryStatus();
                            break;
                        case 168:
                            message = new Wind();
                            break;
                        case 193:
                            message = new EkfStatusReport();
                            break;
                        case 194:
                            message = new PidTuning();
                            break;
                        case 251:
                            message = new NamedValueFloat();
                            break;
                    }

                    if (message == null) break;

                    MemoryStream stream;

                    var start = Message.OffsetPayload;
                    var end = Message.OffsetPayload + payloadLength;

                    // Check for truncated message
                    if (payloadLength < message.PayloadLength)
                    {
                        var buffer = new byte[message.PayloadLength];

                        packet[start..end].CopyTo(buffer, 0);

                        stream = new MemoryStream(buffer);
                    }
                    else
                    {
                        stream = new MemoryStream(packet[start..]);
                    }

                    var br = new BinaryReader(stream);

                    message.Deserialize(br);

                    _common.Messages.Add(message);
                }
            }
        }

        public void Dispose() => Dispose(true);

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _udpClient?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
