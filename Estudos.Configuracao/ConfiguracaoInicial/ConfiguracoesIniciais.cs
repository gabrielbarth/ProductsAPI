using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Estudos.Configuracao.ConfiguracaoInicial
{
    public static class ConfiguracoesIniciais
    {
        public static IConfigurationRoot ConfiguracaoVariaveisAmbiente(this IWebHostEnvironment env)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            return configBuilder.Build();
        }
    }
}
