using Microsoft.Extensions.Logging;

namespace MavLinkPal.CommandLine
{
    public sealed class CmdProcessor
    {
        private readonly ILogger<CmdProcessor> _logger;
        private readonly Common _common;
        private readonly MavLinkParser _mavLinkparser;
        private readonly MavLinkLogger _mavLinkLogger;

        public CmdProcessor(ILogger<CmdProcessor> logger, Common common, MavLinkParser mavLinkparser, MavLinkLogger mavLinkLogger)
        {
            _logger = logger;
            _common = common;

            _mavLinkparser = mavLinkparser;
            _mavLinkLogger = mavLinkLogger;
        }

        public void Run(CmdOptions options)
        {
            _common.Host = options.Host;
            _common.Port = options.Port;
            _common.OutputFolder = options.OutputFolder;
            _common.MessageIds = options.MessageIds.ToList();
            _common.OverwriteFiles = options.OverwriteFiles;

            try
            {
                var task1 = Task.Run(_mavLinkparser.Run);

                var task2 = Task.Run(_mavLinkLogger.Run);

                Task.WaitAll(task1, task2);
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.Flatten().InnerExceptions)
                {
                    _logger.LogError(e.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            finally
            {
            }
        }
    }
}
