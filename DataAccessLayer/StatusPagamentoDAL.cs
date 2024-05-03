using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class StatusPagamentoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public StatusPagamentoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirStatusPagamento(string dsTipo, bool FlPago)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsTipo", SqlDbType.VarChar, dsTipo);
            SqlConnection.AdicionarParametro("@FlPago", SqlDbType.Bit, FlPago);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbStatusPagamento (dsTipo, FlPago) " +
                                                         "VALUES (@dsTipo, @FlPago)");
        }

        public int ExcluirStatusPagamento(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbStatusPagamento WHERE Id = @id");
        }

        public DataTable ConsultarStatusPagamentos()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbStatusPagamento");
        }
        public DataTable ConsultarStatusPagamentos(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbStatusPagamento Where id = @id");
        }
    }
}
