using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RichLife.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RichLife.infrastructure;

namespace RichLife
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(
            //    x =>
            //{
            //    x.AddPolicy(name: MyAllowSpecificOrigins,
            //        x =>
            //        {
            //            x.WithOrigins("http://localhost:9092", "http://31.31.24.200:5051/");
            //        });
            //}
                );
            services.AddUserService();
            ConfigureAuthentication(ref services);
            services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "v1",
                    Version = Assembly.GetEntryAssembly()?.GetName().Version.ToString()
                });

                swaggerGenOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT"
                });

                swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>()
                    }
                });

                swaggerGenOptions.DescribeAllParametersInCamelCase();
                swaggerGenOptions.UseOneOfForPolymorphism();
                swaggerGenOptions.UseAllOfForInheritance();
                swaggerGenOptions.SelectDiscriminatorNameUsing((baseType) => "TypeName");
                swaggerGenOptions.SelectDiscriminatorValueUsing((subType) => subType.Name);
                var commentsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml");
                if (!File.Exists(commentsFile))
                    throw new Exception(
                        $"SwaggerExtensions: Xml comments file does not exist! ({commentsFile})");
                swaggerGenOptions.IncludeXmlComments(commentsFile);
                swaggerGenOptions.UseOneOfForPolymorphism();
                swaggerGenOptions.UseAllOfForInheritance();

                // Application specific swagger generation options that have been injected (nvm these)
                //options?.Invoke(swaggerGenOptions);
            });
            
        }

        public void ConfigureAuthentication(ref IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = AuthOptions.ISSUER,
                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthOptions.AUDIENCE,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,
                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseSwagger(x =>
            //{
            //    x.SerializeAsV2 = true;
            //});
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                x.RoutePrefix = "";
            });
            
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                    
                // Expose Swagger/OpenAPI JSON in new (v3) and old (v2) formats
                endpoints.MapSwagger("swagger/{documentName}/swagger.json");
                endpoints.MapSwagger("swagger/{documentName}/swaggerv2.json", c =>
                {
                    c.SerializeAsV2 = true;
                });
            });
        }
    }
}
