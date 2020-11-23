using Intelutions.Permisos.Models.Contexts;
using Intelutions.Permisos.Repositories;
using Intelutions.Permisos.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Intelutions.Permisos
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
            services.AddMvc();

            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration["Data:ConnectionString"]));
            services.AddTransient<IPermissionsRepository, PermissionRepository>();
            services.AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Intelutions", Version = "v1" });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.Use(async (context, next) =>
            {
                if (context.Request.Method == "OPTIONS")
                {
                    var allowHeaders = context.Request.Headers["Access-Control-Request-Headers"];
                    var allows = allowHeaders.Count == 0 ? string.Empty : string.Join(",", allowHeaders);
                    var headers = "Origin, X-Requested-With, Content-Type, Accept,Authorization,ms-sso";
                    if (!string.IsNullOrEmpty(allows))
                    {
                        headers += "," + allows;
                    }
                    context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] });
                    context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { headers });
                    context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });                    
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("OK");
                }
                else
                {
                    context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] });                    
                    context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
                    await next.Invoke();                  
                }
            });

            app.UseCors(builder =>
            {


                builder.WithOrigins("http://localhost:8080/", "http://localhost:8081/")
                    .AllowAnyHeader()
                    .AllowAnyMethod()                    
                    .SetIsOriginAllowedToAllowWildcardSubdomains();
            });



            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Intelutions API");
            });

            app.UseMvc();
            SeedData.Initialize(dataContext);
        }
    }
}
