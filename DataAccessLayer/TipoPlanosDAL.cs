using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class TipoPlanosDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public TipoPlanosDAL()
        {
            SqlConnection.Open();
        }

        public int InserirTipoPlanos(string dsTipo, int NrNivel, int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsTipo", SqlDbType.VarChar, dsTipo);
            SqlConnection.AdicionarParametro("@NrNivel", SqlDbType.Int, NrNivel);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbTipoPlanos (dsTipo, NrNivel, idPersonal) " +
                                                         "VALUES (@dsTipo, @NrNivel, @idPersonal)");
        }

        public int ExcluirTipoPlanos(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbTipoPlanos WHERE Id = @id");
        }

        public DataTable ConsultarTiposPlanos()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoPlanos");
        }
        public DataTable ConsultarTiposPlanos(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoPlanos WHERE Id = @id");
        }
    }
}
