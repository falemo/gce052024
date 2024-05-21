using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using ModelLayer;
using ToolAccessLayer;


namespace DataAccessLayer
{
    public class teste
    {
        private MySQLS mysqls;



        public teste(string clave)
        {

        }
        public teste()
        {
            try
            {
                Funcoes.LogError(" teste()", "");
              //  mysqls = new MySQLS();
              //  Funcoes.LogError(" mysqls = new MySQLS();", "");
              //  mysqls.Clavecriptografia = "";
              //  mysqls.Stringcnx = "";
              //  mysqls.MySqlConnection = new MySqlConnection();
              //  Funcoes.LogError("  mysqls.MySqlConnection = new MySqlConnection();", "");
              //  mysqls.comando = new MySqlCommand();
              //  mysqls.parametro = new MySqlParameter();
              //  Funcoes.LogError("mysqls.parametro = new MySqlParameter();", "");
              //  mysqls.Clavecriptografia = mysqls.Clave;
              //  mysqls.Stringcnx = AesEncryption.DecryptString(ConfigurationManager.ConnectionStrings["CNXSQL"].ConnectionString, mysqls.Clave);
               // Funcoes.LogError("AesEncryption.DecryptString", mysqls.Stringcnx);
                //Connection(mysqls.Clave, 0); ;
               // Funcoes.LogError("Connection(clave, 0)", "");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
    }
}
