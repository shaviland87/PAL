using CsvHelper;
using Humanizer;
using MavLinkPal.MavLinkProtocol;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Xml.Linq;

namespace MavLinkPal
{
    public class MavLinkLogger
    {
        private readonly ILogger<MavLinkLogger> _logger;
        private readonly Common _common;

        private readonly Dictionary<string, StreamWriter> _streams = new();
        private readonly Dictionary<string, CsvWriter> _writers = new();

        private bool _disposed;

        public MavLinkLogger(ILogger<MavLinkLogger> logger, Common common)
        {
            _logger = logger;
            _common = common;
        }

        public void Run()
        {
            _logger.LogInformation($"{nameof(MavLinkLogger)} task started.");

            try
            {
                Directory.CreateDirectory(_common.OutputFolder);

                while (!_common.ShouldStopTask)
                {
                    if (_common.Messages.TryTake(out var message, Common.MessageDequeueTimeout))
                    {
                        SendToCsvFile(message);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Something went wrong!");
            }
            finally
            {
                Dispose();

                _common.CancelTasks();

                _logger.LogInformation($"{nameof(MavLinkLogger)} task ended.");
            }
        }

        private void SendToCsvFile(IMessage message)
        {
            var filename = message.GetFileName();

            // Validate the filename to avoid bad chars returned by simulator
            if (filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                return;
            }

            var filepath = Path.Combine(_common.OutputFolder, filename);

            if (!_writers.ContainsKey(filename))
            {
                var exists = File.Exists(filepath);

                if (exists && _common.OverwriteFiles)
                {
                    // TODO: backup
                }

                _streams[filename] = new StreamWriter(filepath, !_common.OverwriteFiles);
                
                _writers[filename] = new CsvWriter(_streams[filename], CultureInfo.CurrentCulture);

                if (!exists || _common.OverwriteFiles)
                {
                    var names = message.GetNames();
                    var units = message.GetUnits();

                    // Write headers (field names)
                    foreach (var name in names)
                    {
                        _writers[filename].WriteField(name);
                    }

                    _writers[filename].NextRecord();

                    // Write units
                    foreach (var unit in units)
                    {
                        _writers[filename].WriteField(unit);
                    }
                }
            }

            _writers[filename].NextRecord();

            var values = message.GetValues();

            foreach (var value in values)
            {
                _writers[filename].WriteField(value);
            }

            _writers[filename].Flush();
        }

        public void Dispose() => Dispose(true);

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    foreach (var (_, writer) in _writers)
                    {
                        if (writer != null)
                        {
                            writer.Dispose();
                        }
                    }

                    foreach (var (_, stream) in _streams)
                    {
                        if (stream != null)
                        {
                            stream.Dispose();
                        }
                    }
                }

                _disposed = true;
            }
        }
    }
}
