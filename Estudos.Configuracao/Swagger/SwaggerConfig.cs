using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Estudos.Configuracao.Swagger
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddConfigurationSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var sb = new StringBuilder();
                sb.AppendLine("Api para Estudos .net,");
                sb.AppendLine("  aplicação desenvolvida na plataforna .Net utilizando ASP.NET Core e atualmente hospedadada em container docker.");
                c.SwaggerDoc("v1",
                            new OpenApiInfo
                            {
                                Title = "Estudos api",
                                Version = "v1",
                                Description = sb.ToString(),
                                Contact = new OpenApiContact
                                {
                                    Name = "Estudos",
                                    Url = new Uri("http://www.google.com")
                                }
                            });
                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);
                    return versions.Any(v => $"v{v}" == docName);
                });
                c.OperationFilter<SwaggerOperationFilter>();
                c.DocumentFilter<SwaggerDocumentFilter>();
                c.SchemaFilter<SwaggerSchemaFilter>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autorização JWT no cabeçalho usando esquema Bearer. Exemplo: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                 });
                c.DescribeAllParametersInCamelCase();
                var rootApp = new DirectoryInfo(AppContext.BaseDirectory);
                var Files = rootApp.GetFiles("*.xml");
                foreach (FileInfo file in Files)
                {
                    c.IncludeXmlComments(file.FullName, true);
                }
            });
            return services;
        }

        public static IApplicationBuilder AddConfigurationSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "estudos/v1/swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "estudos/v1/swagger";
                c.SwaggerEndpoint("/estudos/v1/swagger/v1/swagger.json", "Projeto Estudos V1");
            });
            return app;
        }
    }
}
