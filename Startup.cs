using iBanking.Data;
using iBanking.Interfaces.Repo.Create;
using iBanking.Interfaces.Repo.Delete;
using iBanking.Interfaces.Repo.Read;
using iBanking.Interfaces.Repo.Update;
using iBanking.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBanking
{
    public class Startup
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<iBankContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\localThienPhu;Initial Catalog=iBanking;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            services.AddScoped(typeof(IRCreaCus),typeof(RepoCustom));
            services.AddScoped(typeof(IRDeleCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRReadCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRUpdaCus), typeof(RepoCustom));

            services.AddScoped(typeof(IRCreaCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRDeleCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRReadCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRUpdaCus), typeof(RepoCustom));

            services.AddScoped(typeof(IRCreaCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRDeleCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRReadCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRUpdaCus), typeof(RepoCustom));

            services.AddScoped(typeof(IRCreaCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRDeleCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRReadCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRUpdaCus), typeof(RepoCustom));

            services.AddScoped(typeof(IRCreaCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRDeleCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRReadCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRUpdaCus), typeof(RepoCustom));

            services.AddScoped(typeof(IRCreaCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRDeleCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRReadCus), typeof(RepoCustom));
            services.AddScoped(typeof(IRUpdaCus), typeof(RepoCustom));
        }
    }
}
