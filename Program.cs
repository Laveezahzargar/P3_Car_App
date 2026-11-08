using P3_Car_App.Data;
using Serilog;
using Serilog.Events;
using Serilog.Enrichers;

namespace P3_Car_App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
                Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .Enrich.WithThreadId()
               .WriteTo.Console()

               .WriteTo.File("logs/info-.txt",
                   rollingInterval: RollingInterval.Day,
                   restrictedToMinimumLevel: LogEventLevel.Information,
                    outputTemplate:
                "{Timestamp:HH:mm:ss} | {Level:u3} | [Thread:{ThreadId}] | {SourceContext} | {Message:lj}{NewLine}{Exception}{NewLine}------------------------{NewLine}"
                   )

               .WriteTo.File(
                "logs/error-.txt",
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: LogEventLevel.Error,
                outputTemplate:
                "{Timestamp:HH:mm:ss} | {Level:u3} | [Thread:{ThreadId}] | {SourceContext} | {Message:lj}{NewLine}{Exception}{NewLine}------------------------{NewLine}"
               )

               .CreateLogger();

            try
            {
                Application.ThreadException += (sender, args) =>
                {
                    Log.Error(args.Exception, "Unhandled UI exception");
                    MessageBox.Show("Unexpected error occurred.");
                };

                AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
                {
                    Log.Fatal((Exception)args.ExceptionObject, "Fatal error");
                };

                ApplicationConfiguration.Initialize();
                using var context = new AppDbContext();
                //context.Database.EnsureCreated();
                Application.Run(new Main_Form());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application crashed on startup");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}