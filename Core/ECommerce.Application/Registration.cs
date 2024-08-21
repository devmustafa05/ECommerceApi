using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using ECommerce.Application.Exceptions;
using System.Globalization;
using ECommerce.Application.Behaviors;
using MediatR;


namespace ECommerce.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            var assembly = Assembly.GetExecutingAssembly();

            // services.AddTransient<ExceptionMiddleware>();
            // her durum icin aynı durum calistigi icin Singleton kullanilir 
            services.AddSingleton<ExceptionMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            // services.AddValidatorsFromAssemblyContaining<>


            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));

         
        }
    }
}
