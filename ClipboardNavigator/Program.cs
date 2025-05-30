using Serilog;

namespace ClipboardNavigator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            InitLog();
            Application.ThreadException += Application_ThreadException;
            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception, "Thread exception");
        }

        private static void InitLog()
        {
            new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}