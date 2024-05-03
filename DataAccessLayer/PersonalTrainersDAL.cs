using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class PersonalTrainersDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public PersonalTrainersDAL()
        {
            SqlConnection.Open();
        }

        public int InserirPersonalTrainers(DateTime dtprofissional, int idSituacao, int idPessoa, string ChavePix1, string ChavePix2)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dtprofissional", SqlDbType.SmallDateTime, dtprofissional);
            SqlConnection.AdicionarParametro("@idSituacao", SqlDbType.Int, idSituacao);
            SqlConnection.AdicionarParametro("@idPessoa", SqlDbType.Int, idPessoa);
            SqlConnection.AdicionarParametro("@ChavePix1", SqlDbType.VarChar, ChavePix1);
            SqlConnection.AdicionarParametro("@ChavePix2", SqlDbType.VarChar, ChavePix2);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbPersonalTrainers (dtprofissional, idSituacao, idPessoa, ChavePix1, ChavePix2) " +
                                                         "VALUES (@dtprofissional, @idSituacao, @idPessoa, @ChavePix1, @ChavePix2)");
        }

        public int ExcluirPersonalTrainers(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbPersonalTrainers WHERE Id = @id");
        }

        public DataTable ConsultarPersonalTrainers()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPersonalTrainers");
        }
        public DataTable ConsultarPersonalTrainers(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPersonalTrainers WHERE Id = @id");
        }
        public DataTable ConsultarPersonalTrainersPorPessoa(int idPessoa)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPessoa", SqlDbType.Int, idPessoa);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPersonalTrainers WHERE idPessoa = @idPessoa");
        }
    }
}
