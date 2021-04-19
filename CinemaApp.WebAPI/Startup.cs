using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CinemaApp.BLL.Contracts;
using CinemaApp.BLL.Implementation;
using CinemaApp.DAL;
using CinemaApp.DAL.Contracts;
using CinemaApp.DAL.Implementations;

namespace CinemaApp.WebAPI
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст MobileContext в качестве сервиса в приложение
            services.AddDbContext<AppContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            services.AddControllersWithViews();
            
            services.AddAutoMapper(typeof(Startup));
            
            //BLL
            services.Add(new ServiceDescriptor(typeof(ILoyaltyCardService), typeof(LoyaltyCardService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IVisitorService), typeof(VisitorService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISessionService), typeof(SessionService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IFilmService), typeof(FilmService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(INoteService), typeof(NoteService), ServiceLifetime.Scoped));
            
            // DAL
            services.Add(new ServiceDescriptor(typeof(ILoyaltyCardDAL), typeof(LoyaltyCardDAL), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IVisitorDAL), typeof(VisitorDAL), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ISessionDAL), typeof(SessionDAL), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IFilmDAL), typeof(FilmDAL), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(INoteDAL), typeof(NoteDAL), ServiceLifetime.Scoped));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {    
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}