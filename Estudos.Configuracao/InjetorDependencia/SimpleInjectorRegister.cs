using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Estudos.Repositorio.Mapping;
using Estudos.Repositorio.Repositorios;
using Estudos.Aplicacao.Adapter;
using Estudos.Aplicacao.Interfaces;
using Estudos.Aplicacao.IServices;
using Estudos.Aplicacao.Services;
using Estudos.Dominio.Interfaces;
using Estudos.Infraestrutura;
using Estudos.Repositorio.ConfiguracaoHibernate;

namespace Estudos.Configuracao.InjetorDependencia
{
    public static class SimpleInjectorRegister
    {
        
        public static Container InitializeComponents(this Container container, IConfiguration Configuration, IApplicationBuilder app)
        {
            var initialConfig = Configuration.GetSection("ConexaoBD").Get<ConexaoDB>();

            // define tudo o que é necessário para o simple injector acessar
            container.RegisterTypes(initialConfig);

            app.UseSimpleInjector(container);

            container.Verify();
;
            return container;
        }

        public static void RegisterTypes(this Container container, ConexaoDB initConfig)
        {
            container.RegisterSingleton(() => initConfig);

            container.RegisterSingleton(() => new SessionFactory(initConfig));

            container.Register<IUnityOfWork, UnityOfWork>(Lifestyle.Scoped);

            //var uowType = typeof(IUnityOfWork);
            //var repositoriesAssembly = uowType.Assembly;
            //var repositoriesRegistrations =
            //    from type in repositoriesAssembly.GetExportedTypes()
            //    where type.GetInterfaces().Any()
            //    where type.Namespace.StartsWith("Estudos.Repositorio.Repositorios")                     
            //    select new { Interface = type.GetInterfaces().Single(), Implementation = type };
            //repositoriesRegistrations.ToList().ForEach(repository =>
            //    container.Register(repository.Interface, repository.Implementation, Lifestyle.Scoped)
            //);

            container.Register<ICategoryRepository, CategoryRepository>(Lifestyle.Scoped);
            container.Register<ICategoryService, CategoryService>(Lifestyle.Scoped);
            // container.Register(typeof(IAdapter<,>), typeof(IAdapter<,>).Assembly, Lifestyle.Scoped);
            container.Register<ICategoryAdapter, CategoryAdapter>(Lifestyle.Scoped);
            
        }
    }
}
