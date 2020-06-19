using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace rcDominiosApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc().AddXmlSerializerFormatters();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("rc-Dominios-Autenticacao")),
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidIssuer = "rcDominiosAutentica",
                    ValidAudience = "Postman"
                };
            });

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("doc", new OpenApiInfo { 
                    Title = "rcDominiosApi",
                    Description = "API para gerenciamento das informações dos domínios.", 
                    Version = "1.0" 
                });

                OpenApiSecurityScheme esquema = new OpenApiSecurityScheme {
                    Description = "Autenticação utilizando Bearer. Exemplo: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Autenticacao",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                };

                options.AddSecurityDefinition("Bearer", esquema);
                
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new[] { "readAccess", "writeAccess" }
                    }
                });

                options.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Dominios}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(ui => ui.SwaggerEndpoint("/swagger/doc/swagger.json", "doc"));
        }
    }
}
