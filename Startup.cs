using iBanking.Data;
using iBanking.Form;
using iBanking.Interfaces.Repo;
using iBanking.Interfaces.Ser;
using iBanking.Repository;
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
            services.AddDbContext<iBankContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\localThienPhu;Initial Catalog=iBanking;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            services.AddScoped(typeof(IRepoCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRepoBAcc), typeof(RepoBAcc));
            services.AddScoped(typeof(IRepoBCard), typeof(RepoBCard));
            services.AddScoped(typeof(IRepoLoans), typeof(RepoLoans));
            services.AddScoped(typeof(IRepoTransHistory), typeof(RepoTransHistory));
            services.AddScoped(typeof(IRepoUserAuth), typeof(RepoUserAuth));

            services.AddScoped(typeof(ISerCustomer), typeof(SerCustomer));
            services.AddScoped(typeof(ISerUserAuth), typeof(SerUserAuth));
            services.AddScoped(typeof(ISerBAcc), typeof(SerBAcc));

            // Dùng khi dùng trực tiếp DBcontext
            services.AddTransient<mainForm>();
            services.AddTransient<loginForm>();
            services.AddTransient<SignUp>();
            services.AddTransient<ForgotPass>();
            // Dùng khi dùng dbcontext gián tiếp
            //services.AddSingleton<Form1>();

            //return services.BuildServiceProvider();

            //string jsonString = File.ReadAllText("config.json");
            //var appConfig = JsonConvert.DeserializeObject<AppConfig>(jsonString);
            //if (appConfig?.FirebaseConfig == null)
            //{
            //    throw new InvalidOperationException("Không thể đọc cấu hình Firebase từ config.json.");
            //}
            //services.AddSingleton(appConfig.FirebaseConfig);
            //services.AddScoped<IAuthService, FirebaseAuthSer>();

            //serviceProvider = services.BuildServiceProvider();
        }

    }
}
