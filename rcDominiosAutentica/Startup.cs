using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace rcDominiosAutentica
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder => {
                builder.AllowAnyOrigin().
                    AllowAnyMethod().
                    AllowAnyHeader();
            }));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

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
                    Title = "rcDominiosAutentica",
                    Description = "API de autenticação para o sistema de gerenciamento de domínios.", 
                    Version = "1.0" 
                });

                options.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");
            
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(ui => ui.SwaggerEndpoint("/swagger/doc/swagger.json", "doc"));
        }
    }
}
