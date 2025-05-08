using iBanking.Form;
using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using iBanking.Repository;
using iBanking.Repository.Cuong;
using iBanking.Service;
using iBanking.UserView;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;
using System.Text.Json;


namespace iBanking
{
    public class Startup
    {
        //public static IServiceProvider? serviceProvider { get; private set; }
        public static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            //Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"ibanking-8080-firebase-adminsdk.json");
            var connectionString = configuration.GetConnectionString("MyDB");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("Connection string is null or empty");
            }

            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Information()
            //    .WriteTo.File(
            //        new JsonFormatter(),
            //        "logs\\app.json",
            //        rollingInterval: RollingInterval.Day,
            //        shared: true,
            //        flushToDiskInterval: TimeSpan.FromSeconds(1),
            //        fileSizeLimitBytes: 10000000
            //    )
            //    .CreateLogger();

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(
                "logs\\app.txt",
                rollingInterval: RollingInterval.Day,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1),
                fileSizeLimitBytes: 10000000,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] ({SourceContext}) {Message}{NewLine}{Exception}"
            )
            .CreateLogger();

            // Dùng khi dùng trực tiếp DBcontext
            //services.AddTransient<mainForm>();
            services.AddTransient<loginForm>();
            services.AddTransient<SignUp>();
            services.AddTransient<ForgotPass>();
            services.AddTransient<OtpUControl>();
            // Dùng khi dùng dbcontext gián tiếp
            services.AddScoped<IRepoUser>(provider =>
            {
                return new RepoUser(provider.GetRequiredService<ILogger<RepoUser>>(), connectionString);
            });

            services.AddScoped<IRepoEmployee>(provider =>
            {
                return new RepoEmployee(connectionString, provider.GetRequiredService<ILogger<RepoEmployee>>());
            });

            services.AddScoped<ISerUser, SerUser>();
            services.AddScoped<ISerEmployee, SerEmployee>();


            //services.AddScoped<IRepoUser, UserService>();



            services.AddLogging(builder =>
            {
                builder.AddDebug();
                builder.AddConsole();
                builder.AddSerilog();
            });
            //services.AddScoped<IFire>
        }

    }
}
