using System.Threading.Tasks;
using System.Runtime.InteropServices;
using ConferenceApp.Backend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ConferenecApp.Backend
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
            services.AddControllers();
            services.AddDbContext<DatabaseContext>(options => {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) 
                {
                    options.UseSqlServer(Configuration.GetConnectionString("SqlServerLocal"));
                }
                else 
                {
                    options.UseNpgsql(Configuration.GetConnectionString("PostgresSqlLocal"));
                }
            });
            services.AddSwaggerGen(options => {
                options.CustomSchemaIds(m => m.FullName);
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Conference API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Conference API V1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/swagger");
                    return Task.CompletedTask;
                });
                endpoints.MapControllers();
            });
        }
    }
}
