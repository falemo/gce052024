using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class GrupoEspecificoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public GrupoEspecificoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirGrupoEspecifico(string dsGrupo, bool flNumerico)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsGrupo", SqlDbType.VarChar, dsGrupo);
            SqlConnection.AdicionarParametro("@flNumerico", SqlDbType.Bit, flNumerico);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbGrupoEspecifico (dsGrupo, flNumerico) " +
                                                         "VALUES (@dsGrupo, @flNumerico)");
        }

        public int AtualizarGrupoEspecifico(int id, string dsGrupo, bool flNumerico)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsGrupo", SqlDbType.VarChar, dsGrupo);
            SqlConnection.AdicionarParametro("@flNumerico", SqlDbType.Bit, flNumerico);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbGrupoEspecifico SET dsGrupo = @dsGrupo, flNumerico = @flNumerico WHERE Id = @id");
        }

        public int ExcluirGrupoEspecifico(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbGrupoEspecifico WHERE Id = @id");
        }

        public DataTable ConsultarGruposEspecificos()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbGrupoEspecifico");
        }
        public DataTable ConsultarGruposEspecificos(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbGrupoEspecifico where id = @id");
        }
    }
}
