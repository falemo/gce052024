using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class TipoFormacaoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public TipoFormacaoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirTipoFormacao(string dsTipo, int nrNivel)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsTipo", SqlDbType.VarChar, dsTipo);
            SqlConnection.AdicionarParametro("@nrNivel", SqlDbType.Int, nrNivel);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbTipoFormacao (dsTipo, nrNivel) " +
                                                         "VALUES (@dsTipo, @nrNivel)");
        }

        public int ExcluirTipoFormacao(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbTipoFormacao WHERE Id = @id");
        }
        public int AtualizarTipoFormacao(int id, string dsTipo, int nrNivel)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsTipo", SqlDbType.VarChar, dsTipo);
            SqlConnection.AdicionarParametro("@nrNivel", SqlDbType.Int, nrNivel);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbTipoFormacao SET dsTipo = @dsTipo, nrNivel = @nrNivel " +
                                                                " WHERE Id = @id");
        }

        public DataTable ConsultarTiposFormacoes()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoFormacao");
        }
        public DataTable ConsultarTiposFormacoes(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoFormacao Where id = @id");
        }
    }
}
