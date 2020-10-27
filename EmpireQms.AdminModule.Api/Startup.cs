using EmpireQms.AdminModule.Api.Domain;
using EmpireQms.AdminModule.Api.Domain.CommandHandlers;
using EmpireQms.AdminModule.Api.Domain.CommandHandlers.Signages;
using EmpireQms.AdminModule.Api.Domain.CommandHandlers.TerminalRelatedObjects;
using EmpireQms.AdminModule.Api.Domain.CommandHandlers.Terminals;
using EmpireQms.AdminModule.Api.Domain.Commands;
using EmpireQms.AdminModule.Api.Domain.Commands.Signages;
using EmpireQms.AdminModule.Api.Domain.Commands.TerminalCategories;
using EmpireQms.AdminModule.Api.Domain.Commands.TerminalRelatedObjects;
using EmpireQms.AdminModule.Api.Domain.Commands.Terminals;
using EmpireQms.AdminModule.Api.Domain.Repositories;
using EmpireQms.AdminModule.Api.Persistence;
using EmpireQms.AdminModule.Api.Persistence.Repositories;
using EmpireQms.Domain.Core.Bus;
using EmpireQms.Infra.Bus;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmpireQms.AdminModule.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<SettingsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AdminModuleConnection"));
            });

            services.AddSwaggerGen(sg => sg.SwaggerDoc("v1", new OpenApiInfo { Title = "Empire Administration Module Service V1.0", Version = "v1.0" }));
            services.AddSignalR();
            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
            services.AddControllers().AddNewtonsoftJson();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, "Admin Module");
            });

            services.AddTransient<IRequestHandler<UpdateTicketCategoryCommand, bool>, UpdateTicketCategoryCommandHandler>();
            services.AddTransient<IRequestHandler<CreateTicketCategoryCommand, bool>, CreateTicketCategoryCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteTicketCategoryCommand, bool>, DeleteTicketCategoryCommandHandler>();

            services.AddTransient<IRequestHandler<UpdateTerminalSettingsCommand, bool>, UpdateTerminalSettingsCommandHandler>();
            services.AddTransient<IRequestHandler<CreateTerminalCommand, bool>, CreateTerminalCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteTerminalCommand, bool>, DeleteTerminalCommandHandler>();
            services.AddTransient<IRequestHandler<SyncTerminalsCommand, bool>, SyncTerminalsCommandHandler>();

            services.AddTransient<IRequestHandler<UpdateSignageCommand, bool>, UpdateSignageCommandHandler>();
            services.AddTransient<IRequestHandler<CreateSignageCommand, bool>, CreateSignageCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteSignageCommand, bool>, DeleteSignageCommandHandler>();
            services.AddTransient<IRequestHandler<SyncSignagesCommand, bool>, SyncSignagesCommandHandler>();

            services.AddTransient<IRequestHandler<CreateTerminalCategoryCommand, bool>, CreateTerminalCategoryCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteTerminalCategoryCommand, bool>, DeleteTerminalCategoryCommandHandler>();

            services.AddTransient<IRequestHandler<CreateTerminalSignageCommand, bool>, CreateTerminalSignageCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteTerminalSignageCommand, bool>, DeleteTerminalSignageCommandHandler>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITicketCategoryRepository, TicketCategoryRepository>();
            services.AddTransient<ITerminalRepository, TerminalRepository>();
            services.AddTransient<ISignageRepository, SignageRepository>();
            services.AddTransient<SettingsContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(sui => sui.SwaggerEndpoint("/swagger/v1/swagger.json", "Empire Administration Module Service V1.0"));
        }
    }
}
