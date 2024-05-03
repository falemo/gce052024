using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class GrupoEspecificoAlunoHistoricoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public GrupoEspecificoAlunoHistoricoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirGrupoEspecificoAlunoHistorico(int idGrupoEspecifico, int idAluno, int idPersonal, DateTime dtRegistro, float? vlrModificadoNum, string vlrModificadoTxt)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idGrupoEspecifico", SqlDbType.Int, idGrupoEspecifico);
            SqlConnection.AdicionarParametro("@idAluno", SqlDbType.Int, idAluno);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@dtRegistro", SqlDbType.SmallDateTime, dtRegistro);
            SqlConnection.AdicionarParametro("@VlrModificadoNum", SqlDbType.Float, vlrModificadoNum);
            SqlConnection.AdicionarParametro("@VlrModificadoTxt", SqlDbType.VarChar, vlrModificadoTxt);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbGrupoEspecificoAlunoHistorico (IdGrupoEspecifico, idAluno, idPersonal, dtRegistro, VlrModificadoNum, VlrModificadoTxt) " +
                                                         "VALUES (@idGrupoEspecifico, @idAluno, @idPersonal, @dtRegistro, @VlrModificadoNum, @VlrModificadoTxt)");
        }

        public DataTable ConsultarGruposEspecificosAlunosHistorico()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbGrupoEspecificoAlunoHistorico");
        }

        public DataTable ConsultarGruposEspecificosAlunosHistoricoPorAluno(int idAluno)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idAluno", SqlDbType.Int, idAluno);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbGrupoEspecificoAlunoHistorico WHERE idAluno = @idAluno");
        }
    }
}
