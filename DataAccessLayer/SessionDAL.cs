using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DataAccessLayer;

namespace APIDemolaySergipe
{
    public class SessionDAL
    {
        private SQLServerConexion SqlConnection;

        public SessionDAL(string stringcnx)
        {
            SqlConnection = new SQLServerConexion(stringcnx);
            SqlConnection.Open();
        }

        public int InserirSession(string sessionId, int userId, bool flLogin)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@sessionId", MySqlDbType.VarChar, sessionId);
            SqlConnection.AdicionarParametro("@userId", MySqlDbType.Int64, userId);
            SqlConnection.AdicionarParametro("@flLogin", MySqlDbType.Bit, flLogin);

            SqlConnection.AdicionarParametro("@created_at", MySqlDbType.DateTime, DateTime.Now);
            SqlConnection.AdicionarParametro("@updated_at", MySqlDbType.DateTime, DateTime.Now);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO sessions (session_Id, user_Id, created_at, updated_at,flLogin) " +
                                              "VALUES (@sessionId, @userId, @created_at, @updated_at,@flLogin)");
        }

        public int AtualizarSession(int id, string sessionId, int userId, bool flLogin)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@sessionId", MySqlDbType.VarChar, sessionId);
            SqlConnection.AdicionarParametro("@userId", MySqlDbType.Int64, userId);
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            SqlConnection.AdicionarParametro("@flLogin", MySqlDbType.Bit, flLogin);

            SqlConnection.AdicionarParametro("@updated_at", MySqlDbType.DateTime, DateTime.Now);

            return SqlConnection.ExecutaAtualizacao("UPDATE sessions SET session_Id = @sessionId, user_Id = @userId, updated_at = @updated_at, flLogin = @flLogin " +
                                                             "WHERE Id = @id");
        }
        public int AtualizarSessionUltimaData(int id, string sessionId, int userId, bool flLogin)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            SqlConnection.AdicionarParametro("@flLogin", MySqlDbType.Bit, flLogin);
            SqlConnection.AdicionarParametro("@updated_at", MySqlDbType.DateTime, DateTime.Now);

            return SqlConnection.ExecutaAtualizacao("UPDATE sessions SET updated_at = @updated_at, flLogin = @flLogin " +
                                                             "WHERE Id = @id");
        }
        public int AtualizarSessionID(int id, string sessionId)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            SqlConnection.AdicionarParametro("@sessionId", MySqlDbType.VarChar, sessionId);
            SqlConnection.AdicionarParametro("@updated_at", MySqlDbType.DateTime, DateTime.Now);
            return SqlConnection.ExecutaAtualizacao("UPDATE sessions SET session_Id = @sessionId, updated_at = @updated_at " +
                                                             "WHERE Id = @id");
        }
        public int ExcluirSession(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM sessions WHERE Id = @id");
        }

        public DataTable ConsultarSessions()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM sessions");
        }
        public DataTable ConsultarSessions(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM sessions WHERE Id = @id");
        }
        public DataTable ConsultarSessionsUserID(int user_id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@user_id", MySqlDbType.Int64, user_id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM sessions WHERE user_id = @user_id");
        }
        public DataTable ConsultarSessionsSessionID(string session_id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@session_id", MySqlDbType.VarChar, session_id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM sessions WHERE session_id = @session_id");
        }
        // Adicione outros métodos conforme necessário
    }
}
