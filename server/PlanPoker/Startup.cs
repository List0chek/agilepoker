using DataService;
using DataService.Models;
using DataService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanPoker.Models;
using PlanPoker.Services;

namespace PlanPoker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddControllers();

            services.AddControllers();

            services.AddTransient<RoomService>();
            services.AddSingleton<IRepository<Room>, InMemoryRoomRepository>();

            services.AddTransient<UserService>();
            services.AddSingleton<IRepository<User>, InMemoryUserRepository>();

            services.AddTransient<VoteService>();
            services.AddSingleton<IRepository<Vote>, InMemoryVoteRepository>();

            services.AddTransient<DiscussionService>();
            services.AddSingleton<IRepository<Discussion>, InMemoryDiscussionRepository>();

            services.AddTransient<DeckService>();
            services.AddSingleton<IRepository<Deck>, InMemoryDeckRepository>();

            services.AddSingleton<IRepository<Card>, InMemoryCardRepository>();

            mvcBuilder.Services.Configure((MvcOptions options) =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .WithExposedHeaders("token"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
