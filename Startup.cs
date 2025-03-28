﻿using iBanking.Data;
using iBanking.Interfaces.Repo;
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
            // Dùng khi dùng trực tiếp DBcontext
            services.AddTransient<Form1>();
            // Dùng khi dùng dbcontext gián tiếp
            //services.AddSingleton<Form1>();

            //return services.BuildServiceProvider();
        }
    }
}
