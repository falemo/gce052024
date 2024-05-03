using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class FormacaoPersonalTrainersDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public FormacaoPersonalTrainersDAL()
        {
            SqlConnection.Open();
        }

        public int InserirFormacaoPersonalTrainers(int idFormacao, DateTime dtConclusao, bool flFinalizado, int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idFormacao", SqlDbType.Int, idFormacao);
            SqlConnection.AdicionarParametro("@dtConclusao", SqlDbType.SmallDateTime, dtConclusao);
            SqlConnection.AdicionarParametro("@flFinalizado", SqlDbType.Bit, flFinalizado);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbFormacaoPersonalTrainers (idFormacao, dtConclusao, flFinalizado, idPersonal) " +
                                                         "VALUES (@idFormacao, @dtConclusao, @flFinalizado, @idPersonal)");
        }

        public int AtualizarFormacaoPersonalTrainers(int id, int idFormacao, DateTime dtConclusao, bool flFinalizado, int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idFormacao", SqlDbType.Int, idFormacao);
            SqlConnection.AdicionarParametro("@dtConclusao", SqlDbType.SmallDateTime, dtConclusao);
            SqlConnection.AdicionarParametro("@flFinalizado", SqlDbType.Bit, flFinalizado);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbFormacaoPersonalTrainers SET idFormacao = @idFormacao, dtConclusao = @dtConclusao, flFinalizado = @flFinalizado, idPersonal = @idPersonal WHERE Id = @id");
        }

        public int ExcluirFormacaoPersonalTrainers(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbFormacaoPersonalTrainers WHERE Id = @id");
        }

        public DataTable ConsultarFormacaoPersonalTrainers()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbFormacaoPersonalTrainers");
        }

        public DataTable ConsultarFormacaoPersonalTrainersPorPersonal(int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbFormacaoPersonalTrainers WHERE idPersonal = @idPersonal");
        }
    }
}
