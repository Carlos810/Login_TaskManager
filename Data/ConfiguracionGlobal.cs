using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class ConfiguracionGlobal
    {
        public static readonly string CadenaConexion =
        ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}
