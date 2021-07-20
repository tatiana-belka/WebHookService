using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebhooksAPIStore.MoviesContext;
using WebhooksAPIStore.Repository;
using WebhooksAPIStore.Models;
using Microsoft.AspNetCore.Http;
using WebhooksAPIStore.Middlewares;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace WebhooksAPIStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.Name = "_WebhookCookie";
            });

            


            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();
            

            services.AddTransient<IRegisterUser, RegisterUserConcrete>();
            services.AddTransient<IServicesStore, ServicesStoreConcrete>();
            services.AddTransient<ISize, SizeConcrete>();
            services.AddTransient<IAPIManager, APIManagerConcrete>();
            services.AddTransient<IValidateRequest, ValidateRequestConcrete>();
            services.AddTransient<IWebhooks, WebhooksConcrete>();
            services.AddTransient<IUrl, UrlConcrete>();
            services.AddTransient<IRequestLogger, RequestLoggerConcrete>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WebHookService",
                    Description = "Webhooks",
                    Contact = new OpenApiContact
                    {
                        Name = "Татьяна Горелова",
                        Email = "tatiana-gorelova32br@yandex.ru",
                    },

                });

            });
        }


     
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();

            
            app.UseMiddleware<ApiKeyValidatorsMiddleware>();

            app.UseSwagger();

            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Servicedefault", "{controller=Login}/{action=Login}/{ServiceID}/{ServiceName}");
                endpoints.MapControllerRoute("default", "{controller=Login}/{action=Login}/{id?}");
            });

                    
        }
    }
}

