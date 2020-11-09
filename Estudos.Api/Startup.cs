using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


using Estudos.Configuracao.ConfiguracaoInicial;
using Estudos.Configuracao.Swagger;
using Estudos.Configuracao.InjetorDependencia;
using SimpleInjector;

namespace Estudos.Api
{
    public class Startup
    {

        private readonly Container container = new Container();

        public Startup(IWebHostEnvironment env)
        {
            Configuration = env.ConfiguracaoVariaveisAmbiente();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AdicionarConfiguracoes(Configuration);
            services.AddConfigurationSwaggerGen();
            
            services.AddConfigurationSimpleInjector(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsarConfiguracoes(env);
            app.AddConfigurationSwaggerUI();

            container.InitializeComponents(Configuration, app);
        }
    }
}
