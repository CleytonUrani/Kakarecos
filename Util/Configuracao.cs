using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace Kakarecos.Util
{
    public class Configuracao
    {
        private static IConfigurationRoot Configuration { get; set; }

        public Configuracao()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public string ObtemConfiguracao(string parametro)
        {
            return Configuration[parametro];
        }
    }
}
