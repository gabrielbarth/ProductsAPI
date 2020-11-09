using System;
using System.Collections.Generic;
using System.Text;

namespace Estudos.Infraestrutura
{
    public class ConexaoDB
    {
        public string ConexaoString { get;  set; }
        public bool ExibeSql { get; set; }

        //@"Server=localhost,1433;Database=prodcat;User ID=SA;Password=sql123sql"
    }
}
