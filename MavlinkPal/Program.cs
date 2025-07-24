using CommandLine;
using MavLinkPal;
using MavLinkPal.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

IServiceProvider _serviceProvider;

AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

Console.CancelKeyPress += OnCancelKeyPress;

RegisterDependencies();

ParseCommandLineOptions(args);

void RegisterDependencies()
{
    var services = new ServiceCollection();

    services.AddSingleton<Common>();
    services.AddSingleton<CmdProcessor>();
    services.AddSingleton<MavLinkParser>();
    services.AddSingleton<MavLinkLogger>();

    services.AddLogging(option =>
    {
        option.SetMinimumLevel(LogLevel.Trace);
        option.AddNLog("nlog.config");
    });

    _serviceProvider = services.BuildServiceProvider();
}

void ParseCommandLineOptions(string[] args)
{
    var processor = _serviceProvider.GetRequiredService<CmdProcessor>();

    Parser.Default.ParseArguments<CmdOptions>(args)
        .WithParsed(options =>
        {
            processor.Run(options);
        })
        .WithNotParsed(_ =>
        {
        });
}

void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
{
    var ex = (Exception)e.ExceptionObject;

    var logger = LogManager.GetCurrentClassLogger();

    logger.Error(ex.Message);
    logger.Debug(ex.StackTrace);
    logger.Debug(ex.InnerException);
    logger.Debug(ex.TargetSite);

}

void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
{
    var logger = LogManager.GetCurrentClassLogger();

    // Call this to prevent process termination
    //e.SetObserved();

    e.Exception.Handle(ex =>
    {
        logger.Error(ex.Message);
        logger.Debug(ex.StackTrace);
        logger.Debug(ex.InnerException);
        logger.Debug(ex.TargetSite);

        return true;
    });
}

/// <summary>
/// CTRL+C handler.
/// </summary>
void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
{
}

void OnProcessExit(object sender, EventArgs e)
{
}
