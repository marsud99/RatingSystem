using Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RatingSystem.Application.WriteOperations;

namespace RatingSystem.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<EnrollCustomerOperation>();
            //services.AddTransient<CreateAccount>();
            //services.AddTransient<DepositMoney>();
            //services.AddTransient<WithdrawMoney>();
            //services.AddTransient<PurchaseProduct>();
            //services.AddTransient<QueryHandler>();


            services.AddSingleton<Data.RatingDbContext>();

/*            services.AddSingleton(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var options = new AccountOptions
                {
                    InitialBalance = config.GetValue("AccountOptions:InitialBalance", 0)
                };
                return options;
            });*/


            return services;
        }
    }
}
