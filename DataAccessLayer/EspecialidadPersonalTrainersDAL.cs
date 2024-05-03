using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class EspecialidadPersonalTrainersDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public EspecialidadPersonalTrainersDAL()
        {
            SqlConnection.Open();
        }

        public int InserirEspecialidadPersonalTrainers(int idEspecialidade, DateTime dtHabilitacao, bool flHabilitado, DateTime dtAtualizacao, int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idEspecialidade", SqlDbType.Int, idEspecialidade);
            SqlConnection.AdicionarParametro("@dtHabilitacao", SqlDbType.SmallDateTime, dtHabilitacao);
            SqlConnection.AdicionarParametro("@flHabilitado", SqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@dtAtualizacao", SqlDbType.SmallDateTime, dtAtualizacao);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbEspecialidadPersonalTrainers (idEspecialidade, dtHabilitacao, flHabilitado, dtAtualizacao, idPersonal) " +
                                                         "VALUES (@idEspecialidade, @dtHabilitacao, @flHabilitado, @dtAtualizacao, @idPersonal)");
        }

        public int AtualizarEspecialidadPersonalTrainers(int id, int idEspecialidade, DateTime dtHabilitacao, bool flHabilitado, DateTime dtAtualizacao, int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idEspecialidade", SqlDbType.Int, idEspecialidade);
            SqlConnection.AdicionarParametro("@dtHabilitacao", SqlDbType.SmallDateTime, dtHabilitacao);
            SqlConnection.AdicionarParametro("@flHabilitado", SqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@dtAtualizacao", SqlDbType.SmallDateTime, dtAtualizacao);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbEspecialidadPersonalTrainers SET idEspecialidade = @idEspecialidade, dtHabilitacao = @dtHabilitacao, flHabilitado = @flHabilitado, dtAtualizacao = @dtAtualizacao, idPersonal = @idPersonal WHERE Id = @id");
        }

        public int ExcluirEspecialidadPersonalTrainers(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbEspecialidadPersonalTrainers WHERE Id = @id");
        }

        public DataTable ConsultarEspecialidadPersonalTrainers()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbEspecialidadPersonalTrainers");
        }
        public DataTable ConsultarEspecialidadPersonalTrainers(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbEspecialidadPersonalTrainers WHERE Id = @id");
        }
        public DataTable ConsultarEspecialidadPersonalTrainersPorPersonal(int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbEspecialidadPersonalTrainers WHERE idPersonal = @idPersonal");
        }
    }
}
