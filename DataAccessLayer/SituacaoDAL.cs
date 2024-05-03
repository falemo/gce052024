using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class SituacaoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public SituacaoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirSituacao(string descricao, bool flBloqueado, bool flNovo, bool flSuspenso, bool flAtivo)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@descricao", MySqlDbType.VarChar, descricao);
            SqlConnection.AdicionarParametro("@flBloqueado", MySqlDbType.Bit, flBloqueado);
            SqlConnection.AdicionarParametro("@flNovo", MySqlDbType.Bit, flNovo);
            SqlConnection.AdicionarParametro("@flSuspenso", MySqlDbType.Bit, flSuspenso);
            SqlConnection.AdicionarParametro("@flAtivo", MySqlDbType.Bit, flAtivo);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbSituacao (descricao, flBloqueado, flNovo, flSuspenso, flAtivo) " +
                                                         "VALUES (@descricao, @flBloqueado, @flNovo, @flSuspenso, @flAtivo)");
        }

        public int ExcluirSituacao(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbSituacao WHERE Id = @id");
        }

        public DataTable ConsultarSituacoes()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbSituacao");
        }
        public DataTable ConsultarSituacoes(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbSituacao WHERE Id = @id");
        }
    }
}
