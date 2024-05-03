using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class TipoEspecialidadeDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public TipoEspecialidadeDAL()
        {
            SqlConnection.Open();
        }

        public int InserirTipoEspecialidade(string dsTipo)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsTipo", SqlDbType.VarChar, dsTipo);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbTipoEspecialidade (dsTipo) " +
                                                         "VALUES (@dsTipo)");
        }

        public int ExcluirTipoEspecialidade(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbTipoEspecialidade WHERE Id = @id");
        }

        public DataTable ConsultarTiposEspecialidades()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoEspecialidade");
        }
        public DataTable ConsultarTiposEspecialidades(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoEspecialidade WHERE Id = @id");
        }
    }
}
