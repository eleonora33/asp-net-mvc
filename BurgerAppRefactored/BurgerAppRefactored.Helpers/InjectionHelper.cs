using BurgerAppRefactored.DataAccess;
using BurgerAppRefactored.DataAccess.Implementations;
using BurgerAppRefactored.Domain.Models;
using BurgerAppRefactored.Services.Implementations;
using BurgerAppRefactored.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BurgerAppRefactored.Helpers
{
    public static class InjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Burger>, BurgerRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IBurgerService, BurgerService>();
        }

        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<BurgerAppDbContext>(options =>
            {
                //local server(our machine), the database is PizzaAppG5, we use Windows credentials
                options.UseSqlServer("Server=DESKTOP-O6838O0\\SQLEXPRESS;Database=BurgerShopDb;Trusted_Connection=True;TrustServerCertificate=True");
                //if you have sqlexpress, you need \\sqlexpress next to the localhost
                //options.UseSqlServer("Server=.\\sqlexpress;Database=PizzaAppDb;Trusted_Connection=True;TrustServerCertificate=True");
            });
        }
    }
}