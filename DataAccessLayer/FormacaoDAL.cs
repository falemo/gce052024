using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class FormacaoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public FormacaoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirFormacao(string dsFormacao, int idTipoFormacao)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsFormacao", SqlDbType.VarChar, dsFormacao);
            SqlConnection.AdicionarParametro("@idTipoFormacao", SqlDbType.Int, idTipoFormacao);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbFormacao (dsFormacao, idTipoFormacao) " +
                                                         "VALUES (@dsFormacao, @idTipoFormacao)");
        }

        public int AtualizarFormacao(int id, string dsFormacao, int idTipoFormacao)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsFormacao", SqlDbType.VarChar, dsFormacao);
            SqlConnection.AdicionarParametro("@idTipoFormacao", SqlDbType.Int, idTipoFormacao);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbFormacao SET dsFormacao = @dsFormacao, idTipoFormacao = @idTipoFormacao WHERE Id = @id");
        }

        public int ExcluirFormacao(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbFormacao WHERE Id = @id");
        }

        public DataTable ConsultarFormacoes()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbFormacao");
        }

        public DataTable ConsultarFormacoes(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbFormacao Where id = @id");
        }

        public DataTable ConsultarFormacoesPorTipoFormacao(int idTipoFormacao)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idTipoFormacao", SqlDbType.Int, idTipoFormacao);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbFormacao WHERE idTipoFormacao = @idTipoFormacao");
        }
    }
}
