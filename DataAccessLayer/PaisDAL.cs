using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class PaisDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public PaisDAL()
        {
            SqlConnection.Open();
        }

        public int InserirPais(string nmPais, int codPais)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nmPais", SqlDbType.VarChar, nmPais);
            SqlConnection.AdicionarParametro("@codPais", SqlDbType.Int, codPais);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbPais (nmPais, codPais) " +
                                                         "VALUES (@nmPais, @codPais)");
        }
        public int AtualizarPais(int id,string nmPais, int codPais)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nmPais", SqlDbType.VarChar, nmPais);
            SqlConnection.AdicionarParametro("@codPais", SqlDbType.Int, codPais);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);

            return SqlConnection.ExecutaAtualizacao("UPDATE TbPais SET nmPais = @nmPais, codPais = @codPais WHERE Id = @id");
         
        }
        public int ExcluirPais(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
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
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPais WHERE Id = @id");
        }
    }
}
