using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class AvaliacaoPersonalTrainersDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public AvaliacaoPersonalTrainersDAL()
        {
            SqlConnection.Open();
        }

        public int InserirAvaliacaoPersonalTrainers(int mes, int ano, double avgAvaliacao, int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@mes", SqlDbType.Int, mes);
            SqlConnection.AdicionarParametro("@ano", SqlDbType.Int, ano);
            SqlConnection.AdicionarParametro("@avgAvaliacao", SqlDbType.Decimal, avgAvaliacao);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbAvaliacaoPersonalTrainers (mes, ano, avgAvaliacao, idPersonal) " +
                                                         "VALUES (@mes, @ano, @avgAvaliacao, @idPersonal)");
        }

        public int AtualizarAvaliacaoPersonalTrainers(int id, int mes, int ano, double avgAvaliacao, int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@mes", SqlDbType.Int, mes);
            SqlConnection.AdicionarParametro("@ano", SqlDbType.Int, ano);
            SqlConnection.AdicionarParametro("@avgAvaliacao", SqlDbType.Decimal, avgAvaliacao);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbAvaliacaoPersonalTrainers SET mes = @mes, ano = @ano, avgAvaliacao = @avgAvaliacao, idPersonal = @idPersonal WHERE Id = @id");
        }

        public int ExcluirAvaliacaoPersonalTrainers(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbAvaliacaoPersonalTrainers WHERE Id = @id");
        }

        public DataTable ConsultarAvaliacaoPersonalTrainers()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbAvaliacaoPersonalTrainers");
        }
        public DataTable ConsultarAvaliacaoPersonalTrainers(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbAvaliacaoPersonalTrainers  WHERE Id = @id");
        }
        public DataTable ConsultarAvaliacaoPersonalTrainersPorAno(int ano)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@ano", SqlDbType.Int, ano);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbAvaliacaoPersonalTrainers WHERE ano = @ano");
        }

        public DataTable ConsultarAvaliacaoPersonalTrainersPorPersonal(int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbAvaliacaoPersonalTrainers WHERE idPersonal = @idPersonal");
        }
    }
}
