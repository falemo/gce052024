using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace ModelLayer
{
    public class MySQLS
    {
        public string Clavecriptografia { get; set; }
        public string Stringcnx { get; set; }
        public MySqlConnection MySqlConnection { get; set; }
        public MySqlCommand comando { get; set; }
        public MySqlParameter parametro  { get; set; }
        public string Clave { get; set; }

        public MySQLS()
        {
            Clave = "headin2023fabrinioandessantanalemos";
        }

    }
}
