using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using DataAccessLayer;
namespace APIDemolaySergipe
{
    public class PaisDAL
    {
        private SQLServerConexion SqlConnection;

        public PaisDAL(string stringcnx)
        {
            SqlConnection = new SQLServerConexion(stringcnx);
            SqlConnection.Open();
        }

        public int InserirPais(string nmPais, int codPais)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nmPais", MySqlDbType.VarChar, nmPais);
            SqlConnection.AdicionarParametro("@codPais", MySqlDbType.Int64, codPais);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbPais (nmPais, codPais) " +
                                                         "VALUES (@nmPais, @codPais)");
        }
        public int AtualizarPais(int id,string nmPais, int codPais)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nmPais", MySqlDbType.VarChar, nmPais);
            SqlConnection.AdicionarParametro("@codPais", MySqlDbType.Int64, codPais);
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);

            return SqlConnection.ExecutaAtualizacao("UPDATE TbPais SET nmPais = @nmPais, codPais = @codPais WHERE Id = @id");
         
        }
        public int ExcluirPais(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbPais WHERE Id = @id");
        }

        public DataTable ConsultarPaises()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPais order by nmPais");
        }
        public DataTable ConsultarPaises(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPais WHERE Id = @id");
        }
    }
}
