using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OTS.Administration.Models.Auth;
using OTS.Administration.Models.Events.CreateEdit;
using OTS.Administration.Models.Events.Item;
using OTS.Administration.Models.Events.List;
using OTS.Administration.Models.Tickets.Purchase;
using OTS.DataLayer;
using OTS.DataLayer.Entities;
using OTS.DataLayer.Entities.Events;
using OTS.DataLayer.Entities.Users;
using OTS.DataLayer.Infrastructure;

namespace OTS.Administration.Infrastructure
{
    public static class ServiceProviderExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<ILoginModelHandler, LoginModelHandler>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserFactory, UserFactory>();
            services.AddTransient<IUserEventLinkFactory, UserEventLinkFactory>();
            services.AddTransient<IUserEventLinkRepository, UserEventLinkRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IEventFactory, EventFactory>();
            services.AddTransient<IEventRepository, EventRepository>();

            services.AddTransient<IEventListModelBuilder, EventListModelBuilder>();
            services.AddTransient<IEventModelBuilder, EventModelBuilder>();
            services.AddTransient<IEventFormValidator, EventFormValidator>();
            services.AddTransient<IEventFormHandler, EventFormHandler>();
            services.AddTransient<IEventEditModelBuilder, EventEditModelBuilder>();

            services.AddTransient<ITicketHandler, TicketHandler>();

            services.AddTransient<IProfileModelBuilder, ProfileModelBuilder>();

            services.AddSingleton<IEntityRepository<IOtsEntity>, EntityRepository<IOtsEntity>>();
            services.AddTransient<OtsDbContext>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

    }
}