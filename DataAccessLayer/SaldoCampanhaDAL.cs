using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Security.Cryptography;

using DataAccessLayer;

namespace APIDemolaySergipe
{
    public class SaldoCampanhaDAL
    {
        private SQLServerConexion SqlConnection;

        public SaldoCampanhaDAL(string stringcnx)
        {
            SqlConnection = new SQLServerConexion(stringcnx);
            SqlConnection.Open();
        }

        public int InserirSaldoCampanha(int idPessoa, int idCampanha, decimal vlrSaldo, DateTime dtCarga, bool flUso)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int32, idPessoa);
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int32, idCampanha);
            SqlConnection.AdicionarParametro("@vlrSaldo", MySqlDbType.Decimal, vlrSaldo);
            SqlConnection.AdicionarParametro("@dtCarga", MySqlDbType.DateTime, dtCarga);
            SqlConnection.AdicionarParametro("@flUso", MySqlDbType.Bit, flUso);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbSaldoCampanha (idPessoa, idCampanha, vlrSaldo, dtCarga, flUso) " +
                                              "VALUES (@idPessoa, @idCampanha, @vlrSaldo, @dtCarga, @flUso)");
        }

        public int AtualizarSaldoCampanha(int id, int idPessoa, int idCampanha, decimal vlrSaldo, DateTime dtCarga, bool flUso)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int32, id);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int32, idPessoa);
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int32, idCampanha);
            SqlConnection.AdicionarParametro("@vlrSaldo", MySqlDbType.Decimal, vlrSaldo);
            SqlConnection.AdicionarParametro("@dtCarga", MySqlDbType.DateTime, dtCarga);
            SqlConnection.AdicionarParametro("@flUso", MySqlDbType.Bit, flUso);

            return SqlConnection.ExecutaAtualizacao("UPDATE TbSaldoCampanha SET idPessoa = @idPessoa, idCampanha = @idCampanha, vlrSaldo = @vlrSaldo, dtCarga = @dtCarga, flUso = @flUso WHERE id = @id");
        }
        public int AtualizarSaldoCampanha(int id, decimal vlrSaldo, bool flUso)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int32, id);
            SqlConnection.AdicionarParametro("@vlrSaldo", MySqlDbType.Decimal, vlrSaldo);
            SqlConnection.AdicionarParametro("@flUso", MySqlDbType.Bit, flUso);

            return SqlConnection.ExecutaAtualizacao("UPDATE TbSaldoCampanha SET vlrSaldo = @vlrSaldo, flUso = @flUso WHERE id = @id");
        }
        public int ExcluirSaldoCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int32, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbSaldoCampanha WHERE id = @id");
        }

        public DataTable ConsultarSaldoCampanha()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbSaldoCampanha");
        }

        public DataTable ConsultarSaldoCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int32, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbSaldoCampanha WHERE id = @id");
        }

        public DataTable ConsultarSaldoCampanha(int idPessoa, int idCampanha)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int32, idPessoa);
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int32, idCampanha);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbSaldoCampanha Where fluso = 0 And idPessoa = @idPessoa and idCampanha = @idCampanha Order by dtcarga desc");
        }

        // Adicione outros métodos conforme necessário
    }
}
