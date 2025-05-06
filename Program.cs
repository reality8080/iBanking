using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using iBanking.UserView;

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
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = Host.CreateApplicationBuilder();

            // Đăng ký UserHomeForm vào DI container
            builder.Services.AddSingleton<CashierHome>();

            // Xây dựng host
            using var host = builder.Build();

            // Lấy instance của UserHomeForm từ DI container
            var f1 = host.Services.GetRequiredService<CashierHome>();

            // Chạy ứng dụng với form
            Application.Run(f1);
        }
    }
}