using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using OnlineRetailStore.Context;
using OnlineRetailStore.Models.Interfaces;
using OnlineRetailStore.Repository;
using OnlineRetailStore.Repository.Interfaces;
using OnlineRetailStore.Services;

namespace OnlineRetailStore
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineRetailStore", Version = "v1" });
            });

            services.Configure<OnlineRetailStoreDbSettings>(
                Configuration.GetSection("OnlineRetailStoreDatabase"));

            services.AddScoped<IOnlineRetailStoreDbSettings>(sp =>
                sp.GetRequiredService<IOptions<OnlineRetailStoreDbSettings>>().Value);

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IOrderServices, OrderServices>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineRetailStore v1"));
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
