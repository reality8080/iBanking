using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace iBanking
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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            ApplicationConfiguration.Initialize();

            var builder = Host.CreateApplicationBuilder();
            Startup.ConfigureServices(builder.Services);
            using var host = builder.Build();
            using (var lF = host.Services.GetRequiredService<loginForm>()){
                Application.Run(lF);
            };
        }
    }
}