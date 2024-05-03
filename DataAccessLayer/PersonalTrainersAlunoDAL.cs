using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class PersonalTrainersAlunoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public PersonalTrainersAlunoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirPersonalTrainersAluno(int idPersonal, int idAluno, DateTime DtCadastro, int idSituacao, int idPlano)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@idAluno", SqlDbType.Int, idAluno);
            SqlConnection.AdicionarParametro("@DtCadastro", SqlDbType.DateTime, DtCadastro);
            SqlConnection.AdicionarParametro("@idSituacao", SqlDbType.Int, idSituacao);
            SqlConnection.AdicionarParametro("@idPlano", SqlDbType.Int, idPlano);
            return SqlConnection.ExecutaAtualizacao("INSERT INTO TbPersonalTrainersAluno (idPersonal, idAluno, DtCadastro, idSituacao, idPlano) " +
                                                         "VALUES (@idPersonal, @idAluno, @DtCadastro, @idSituacao, @idPlano)");
        }

        public int ExcluirPersonalTrainersAluno(int idPersonal, int idAluno)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@idAluno", SqlDbType.Int, idAluno);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbPersonalTrainersAluno WHERE idPersonal = @idPersonal AND idAluno = @idAluno");
        }

        public DataTable ConsultarPersonalTrainersAlunos()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPersonalTrainersAluno");
        }
        public DataTable ConsultarPersonalTrainersAlunos(int idPersonal, int idAluno)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@idAluno", SqlDbType.Int, idAluno);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPersonalTrainersAluno  WHERE idPersonal = @idPersonal AND idAluno = @idAluno");
        }
    }
}
