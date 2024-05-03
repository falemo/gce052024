using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class HorarioTreinoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public HorarioTreinoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirHorarioTreino(string dsHorario, int diaDaSemana, TimeSpan horaInicio, TimeSpan horaFim, int idPersonal, bool flHabilitado)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsHorario", SqlDbType.VarChar, dsHorario);
            SqlConnection.AdicionarParametro("@diaDaSemana", SqlDbType.Int, diaDaSemana);
            SqlConnection.AdicionarParametro("@HoraInicio", SqlDbType.Time, horaInicio);
            SqlConnection.AdicionarParametro("@HoraFim", SqlDbType.Time, horaFim);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@flHabilitado", SqlDbType.Bit, flHabilitado);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbHorarioTreino (dsHorario, diaDaSemana, HoraInicio, HoraFim, idPersonal, flHabilitado) " +
                                                         "VALUES (@dsHorario, @diaDaSemana, @HoraInicio, @HoraFim, @idPersonal, @flHabilitado)");
        }

        public int ExcluirHorarioTreino(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbHorarioTreino WHERE Id = @id");
        }

        public DataTable ConsultarHorariosTreinos()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbHorarioTreino");
        }
        public DataTable ConsultarHorariosTreinos(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbHorarioTreino where id = @id");
        }
        public DataTable ConsultarHorariosTreinosPorPersonal(int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbHorarioTreino WHERE idPersonal = @idPersonal");
        }
    }
}
