using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class TipoMensalidadeDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public TipoMensalidadeDAL()
        {
            SqlConnection.Open();
        }

        public int InserirTipoMensalidade(string dsTipo, int diasFaturacao, bool flHabilitado)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsTipo", SqlDbType.VarChar, dsTipo);
            SqlConnection.AdicionarParametro("@diasFaturacao", SqlDbType.Int, diasFaturacao);
            SqlConnection.AdicionarParametro("@flHabilitado", SqlDbType.Bit, flHabilitado);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbTipoMensalidade (dsTipo, diasFaturacao, flHabilitado) " +
                                                         "VALUES (@dsTipo, @diasFaturacao, @flHabilitado)");
        }

        public int AtualizarTipoMensalidade(int id,string dsTipo, int diasFaturacao, bool flHabilitado)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsTipo", SqlDbType.VarChar, dsTipo);
            SqlConnection.AdicionarParametro("@diasFaturacao", SqlDbType.Int, diasFaturacao);
            SqlConnection.AdicionarParametro("@flHabilitado", SqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbTipoMensalidade SET dsTipo = @dsTipo, diasFaturacao = @diasFaturacao, flHabilitado = @flHabilitado " +
                                                                 " WHERE Id = @id");

        }

        public int ExcluirTipoMensalidade(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbTipoMensalidade WHERE Id = @id");
        }

        public DataTable ConsultarTiposMensalidades()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoMensalidade");
        }
        public DataTable ConsultarTiposMensalidades(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoMensalidade Where id = @id");
        }
    }
}
