using System;
using System.Data;
using MySql.Data.MySqlClient;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class NrSorteCampanhaDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public NrSorteCampanhaDAL()
        {
            SqlConnection.Open();
        }

        public int InserirNrSorteCampanha(string nrCupom, DateTime dtCriacao, int idPessoa, decimal vlrAportado, string nmarqComprovante, bool flValidado, bool flProcesado, bool flCupom, int idCampanha)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nrCupom", MySqlDbType.VarChar, nrCupom);
            SqlConnection.AdicionarParametro("@dtCriacao", MySqlDbType.DateTime, dtCriacao);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@vlrAportado", MySqlDbType.Decimal, vlrAportado);
            SqlConnection.AdicionarParametro("@nmarqComprovante", MySqlDbType.VarChar, nmarqComprovante);
            SqlConnection.AdicionarParametro("@flValidado", MySqlDbType.Bit, flValidado);
            SqlConnection.AdicionarParametro("@flProcesado", MySqlDbType.Bit, flProcesado);
            SqlConnection.AdicionarParametro("@flCupom", MySqlDbType.Bit, flCupom);
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbNrSorteCampanha (nrCupom, dtCriacao, idPessoa, vlrAportado, nmarqComprovante, flValidado, flProcesado, flCupom, idCampanha) " +
                                                     "VALUES (@nrCupom, @dtCriacao, @idPessoa, @vlrAportado, @nmarqComprovante, @flValidado, @flProcesado, @flCupom, @idCampanha)");
        }

        public int AtualizarNrSorteCampanha(int id, string nrCupom, DateTime dtCriacao, int idPessoa, decimal vlrAportado, string nmarqComprovante, bool flValidado, bool flProcesado, bool flCupom, int idCampanha)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            SqlConnection.AdicionarParametro("@nrCupom", MySqlDbType.VarChar, nrCupom);
            SqlConnection.AdicionarParametro("@dtCriacao", MySqlDbType.DateTime, dtCriacao);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@vlrAportado", MySqlDbType.Decimal, vlrAportado);
            SqlConnection.AdicionarParametro("@nmarqComprovante", MySqlDbType.VarChar, nmarqComprovante);
            SqlConnection.AdicionarParametro("@flValidado", MySqlDbType.Bit, flValidado);
            SqlConnection.AdicionarParametro("@flProcesado", MySqlDbType.Bit, flProcesado);
            SqlConnection.AdicionarParametro("@flCupom", MySqlDbType.Bit, flCupom);
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);

            return SqlConnection.ExecutaAtualizacao("UPDATE TbNrSorteCampanha SET nrCupom = @nrCupom, dtCriacao = @dtCriacao, idPessoa = @idPessoa, " +
                                                     "vlrAportado = @vlrAportado, nmarqComprovante = @nmarqComprovante, flValidado = @flValidado, " +
                                                     "flProcesado = @flProcesado, flCupom = @flCupom, idCampanha = @idCampanha WHERE id = @id");
        }

        public int ExcluirNrSorteCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);

            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbNrSorteCampanha WHERE id = @id");
        }

        public DataTable ConsultarNrSorteCampanhas()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbNrSorteCampanha");
        }

        public DataTable ConsultarNrSorteCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbNrSorteCampanha WHERE id = @id");
        }
        public DataTable ConsultarNrSorteCampanhas(int idCampanha)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbNrSorteCampanha WHERE idCampanha = @idCampanha");
        }
    }
}
