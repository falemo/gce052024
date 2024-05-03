using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class ReservasDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public ReservasDAL()
        {
            SqlConnection.Open();
        }

        public int InserirReservas(int idaluno, int idPersonal, DateTime dtReserva, DateTime dtregistro, int idHorarioTreino, int nrAvaliacao, bool flRealizado)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idaluno", SqlDbType.Int, idaluno);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@dtReserva", SqlDbType.SmallDateTime, dtReserva);
            SqlConnection.AdicionarParametro("@dtregistro", SqlDbType.SmallDateTime, dtregistro);
            SqlConnection.AdicionarParametro("@idHorarioTreino", SqlDbType.Int, idHorarioTreino);
            SqlConnection.AdicionarParametro("@nrAvaliacao", SqlDbType.Int, nrAvaliacao);
            SqlConnection.AdicionarParametro("@flRealizado", SqlDbType.Bit, flRealizado);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbReservas (idaluno, idPersonal, dtReserva, dtregistro, idHorarioTreino, nrAvaliacao, flRealizado) " +
                                                         "VALUES (@idaluno, @idPersonal, @dtReserva, @dtregistro, @idHorarioTreino, @nrAvaliacao, @flRealizado)");
        }

        public int ExcluirReservas(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbReservas WHERE Id = @id");
        }

        public DataTable ConsultarReservas()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbReservas");
        }
        public DataTable ConsultarReservas(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbReservas Where id = @id");
        }
        public DataTable ConsultarReservasPorAluno(int idaluno)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idaluno", SqlDbType.Int, idaluno);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbReservas WHERE idaluno = @idaluno");
        }
    }
}
