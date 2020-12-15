using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace AUBNB.Web.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            // Registra o Swagger para documentar a API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AUBNB.Web.API",
                    Description = "API Web",
                });

                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                });

                var jwtbearerScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" }
                };

                var security = new OpenApiSecurityRequirement
                {
                    [jwtbearerScheme] = new string[] { }
                };

                c.AddSecurityRequirement(security);

                // Adiciona os comentários da "nddSmart.Core.IntegrationTool.API" no Swagger JSON da UI.
                IncludeXmlComments(c, Assembly.GetExecutingAssembly());

                // Linha adicionada para resolver seguinte erro:
                // Conflicting schemaIds: Duplicate schemaIds
                // Acontece devido os command's terem o mesmo nome
                c.CustomSchemaIds(x => x.FullName);
            });

            //services.AddSwaggerGenNewtonsoftSupport();
        }

        private static void IncludeXmlComments(SwaggerGenOptions swaggerGenOptions, Assembly assembly)
        {
            var xmlFile = $"{assembly.GetName().Name}.xml";
            var xmlFullPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (File.Exists(xmlFullPath))
                swaggerGenOptions.IncludeXmlComments(xmlFullPath);
        }

        public static void ConfigSwagger(this IApplicationBuilder app)
        {
            // Habilita o Middleware do Swagger.
            app.UseSwagger();

            // Configura o Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                // Linha adicionada para resolver seguinte erro
                // Fetch error Not Found /swagger/v1/swagger.json
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";

                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "AUBNB API V1");
            });
        }
    }
}
