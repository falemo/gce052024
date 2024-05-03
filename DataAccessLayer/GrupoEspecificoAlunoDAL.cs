using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class GrupoEspecificoAlunoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public GrupoEspecificoAlunoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirGrupoEspecificoAluno(int idGrupoEspecifico, int idAluno, int idPersonal, DateTime dtCadastro)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idGrupoEspecifico", SqlDbType.Int, idGrupoEspecifico);
            SqlConnection.AdicionarParametro("@idAluno", SqlDbType.Int, idAluno);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@dtCadastro", SqlDbType.SmallDateTime, dtCadastro);
            return SqlConnection.ExecutaAtualizacao("INSERT INTO TbGrupoEspecificoAluno (IdGrupoEspecifico, idAluno, idPersonal, dtCadastro) " +
                                                         "VALUES (@idGrupoEspecifico, @idAluno, @idPersonal, @dtCadastro)");
        }

        public int ExcluirGrupoEspecificoAluno(int idGrupoEspecifico, int idAluno)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idGrupoEspecifico", SqlDbType.Int, idGrupoEspecifico);
            SqlConnection.AdicionarParametro("@idAluno", SqlDbType.Int, idAluno);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbGrupoEspecificoAluno WHERE IdGrupoEspecifico = @idGrupoEspecifico AND idAluno = @idAluno");
        }

        public DataTable ConsultarGruposEspecificosAlunos()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbGrupoEspecificoAluno");
        }

        public DataTable ConsultarGruposEspecificosAlunosPorAluno(int idAluno)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idAluno", SqlDbType.Int, idAluno);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbGrupoEspecificoAluno WHERE idAluno = @idAluno");
        }
    }
}
