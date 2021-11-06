using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MfPulse.Auth.Contract;
using MfPulse.Auth.Contract.Database.Operations;
using MfPulse.Auth.Contract.Groups.Operations;
using MfPulse.Auth.Contract.Groups.Services;
using MfPulse.Auth.Contract.Services;
using MfPulse.Auth.Implementation.Database;
using MfPulse.Auth.Implementation.Groups.Operations;
using MfPulse.Auth.Implementation.Groups.Services;
using MfPulse.Auth.Implementation.Services;
using MfPulse.Company.Contract.Operations;
using MfPulse.Company.Contract.Services;
using MfPulse.Company.Impl.Operations;
using MfPulse.Company.Impl.Services;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace MfPulse.Api
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
services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            
            services.AddMvc(options => options.Filters.Add<ValidateModelAttribute>());
            
            services.AddControllers();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "FBA", Version = "v1"});
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    In = ParameterLocation.Header, 
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey 
                });
                
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    { 
                        new OpenApiSecurityScheme 
                        { 
                            Reference = new OpenApiReference 
                            { 
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" 
                            } 
                        },
                        Array.Empty<string>()
                    } 
                });
            });

            services.AddLogging();

            services.AddScoped<DbContext>();
            services.AddScoped<IUserGetOperations, UserGetOperations>();
            services.AddScoped<IUserWriteOperations, UserWriteOperations>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<MongoSecurityFilter>();

            services.AddScoped<ICompanyGetOperations, CompanyGetOperations>();
            services.AddScoped<ICompanyWriteOperations, CompanyWriteOperations>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IGroupGetOperations, GroupGetOperations>();
            services.AddScoped<IGroupWriteOperations, GroupWriteOperations>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddTransient<IUserIdentity, UserIdentity>();
            services.AddHttpContextAccessor();
            services.AddTransient<IMongoIdentity, UserIdentity>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MfPulse.Api v1"));
            }
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}