using Google.Cloud.Firestore;
using iBanking.Form;
using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using iBanking.Repository;
using iBanking.Repository.Cuong;
using iBanking.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

            // Dùng khi dùng trực tiếp DBcontext
            services.AddTransient<mainForm>();
            services.AddTransient<loginForm>();
            services.AddTransient<SignUp>();
            services.AddTransient<ForgotPass>();
            services.AddTransient<OtpUControl>();
            services.AddTransient<Home>();
            // Dùng khi dùng dbcontext gián tiếp
            services.AddScoped<IRepoUser>(provider =>
            {
                return new RepoUser(provider.GetRequiredService<ILogger<RepoUser>>(), connectionString);
            });
            services.AddScoped<ISerUser, SerUser>();


            //services.AddScoped<IRepoUser, UserService>();

            services.AddLogging(builder =>
            {
                builder.AddDebug();
                builder.AddConsole();
            });
            //services.AddScoped<IFire>
        }

    }
}
