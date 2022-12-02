using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConexion()
        {
            return ConfigurationManager.ConnectionStrings["HSilvaProgramacionNCapas"].ConnectionString;
        }
    }
}