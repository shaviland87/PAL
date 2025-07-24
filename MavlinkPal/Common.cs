using MavLinkPal.MavLinkProtocol;
using System.Collections.Concurrent;

namespace MavLinkPal
{
    public class Common
    {
        // Command-line options
        public string Host { get; set; }
        public int Port { get; set; }
        public string OutputFolder { get; set; }
        public List<int> MessageIds { get; set; }
        public bool OverwriteFiles { get; set; }

        private CancellationTokenSource _cancellationTokenSource = new();
        public CancellationToken CancellationToken => _cancellationTokenSource.Token;
        public bool ShouldStopTask => CancellationToken.IsCancellationRequested;

        public BlockingCollection<IMessage> Messages = new();

        public const int MessageDequeueTimeout = 1000;

        public void CancelTasks()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
