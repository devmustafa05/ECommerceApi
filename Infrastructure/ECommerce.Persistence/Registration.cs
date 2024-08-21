using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ECommerce.Persistence.Context;
using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Persistence.Repositories;
using ECommerce.Persistence.UnitOfWorks;
using ECommerce.Application.Interfaces.UnitOfWorks;

namespace ECommerce.Persistence
{
    public static  class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => 
                 opt.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStrings")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRespostory<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
