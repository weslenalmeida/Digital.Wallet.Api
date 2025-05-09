using Application.Shared;
using Domain.Interfaces.v1.Context;
using Domain.Interfaces.v1.Repositories;
using Infrastructure.Data.v1.Mongo;

namespace Application.Infrastructure
{
    public class Bootstrapper
    {
        public Bootstrapper(WebApplicationBuilder builder)
        {
            InjectSingleton(builder.Services);
            InjectLogger(builder.Services);
            InjectMediator(builder.Services);
            InjectAutoMapper(builder.Services);
            InjectHealthChecks(builder.Services);
            Holder.Container = builder.Services.BuildServiceProvider();
        }

        private static void InjectSingleton(IServiceCollection services)
        {
            services.AddSingleton(typeof(IPersonRepository), typeof(PersonRepository)); 
            services.AddSingleton(typeof(IContext), new Context()); 
        }

        private static void InjectMediator(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }

        private static void InjectAutoMapper(IServiceCollection services) =>
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        private static void InjectLogger(IServiceCollection services) =>
            services.AddLogging();

        private static void InjectHealthChecks(IServiceCollection services) =>
            services.AddHealthChecks();
    
    }
}