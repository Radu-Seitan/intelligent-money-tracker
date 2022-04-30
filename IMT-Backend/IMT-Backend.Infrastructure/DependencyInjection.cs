using IMT_Backend.Application.Common.Interfaces;
using IMT_Backend.Infrastructure.Persistence;
using IMT_Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IMT_Backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IAppImageRepository, AppImageRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<IUserRepository, UserRepository>();


            return services;
        }
    }
}
