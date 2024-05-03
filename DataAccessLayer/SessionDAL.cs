using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class SessionDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public SessionDAL()
        {
            SqlConnection.Open();
        }

        public int InserirSession(string sessionId, int userId, bool flLogin)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@sessionId", SqlDbType.VarChar, sessionId);
            SqlConnection.AdicionarParametro("@userId", SqlDbType.Int, userId);
            SqlConnection.AdicionarParametro("@flLogin", SqlDbType.Bit, flLogin);

            SqlConnection.AdicionarParametro("@created_at", SqlDbType.SmallDateTime, DateTime.Now);
            SqlConnection.AdicionarParametro("@updated_at", SqlDbType.SmallDateTime, DateTime.Now);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO sessions (session_Id, user_Id, created_at, updated_at,flLogin) " +
                                              "VALUES (@sessionId, @userId, @created_at, @updated_at,@flLogin)");
        }

        public int AtualizarSession(int id, string sessionId, int userId, bool flLogin)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@sessionId", SqlDbType.VarChar, sessionId);
            SqlConnection.AdicionarParametro("@userId", SqlDbType.Int, userId);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            SqlConnection.AdicionarParametro("@flLogin", SqlDbType.Bit, flLogin);

            SqlConnection.AdicionarParametro("@updated_at", SqlDbType.SmallDateTime, DateTime.Now);

            return SqlConnection.ExecutaAtualizacao("UPDATE sessions SET session_Id = @sessionId, user_Id = @userId, updated_at = @updated_at, flLogin = @flLogin " +
                                                             "WHERE Id = @id");
        }
        public int AtualizarSessionUltimaData(int id, string sessionId, int userId, bool flLogin)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            SqlConnection.AdicionarParametro("@flLogin", SqlDbType.Bit, flLogin);
            SqlConnection.AdicionarParametro("@updated_at", SqlDbType.SmallDateTime, DateTime.Now);

            return SqlConnection.ExecutaAtualizacao("UPDATE sessions SET updated_at = @updated_at, flLogin = @flLogin " +
                                                             "WHERE Id = @id");
        }
        public int AtualizarSessionID(int id, string sessionId)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            SqlConnection.AdicionarParametro("@sessionId", SqlDbType.VarChar, sessionId);
            SqlConnection.AdicionarParametro("@updated_at", SqlDbType.DateTime, DateTime.Now);
            return SqlConnection.ExecutaAtualizacao("UPDATE sessions SET session_Id = @sessionId, updated_at = @updated_at " +
                                                             "WHERE Id = @id");
        }
        public int ExcluirSession(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
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
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM sessions WHERE Id = @id");
        }
        public DataTable ConsultarSessionsUserID(int user_id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@user_id", SqlDbType.Int, user_id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM sessions WHERE user_id = @user_id");
        }
        public DataTable ConsultarSessionsSessionID(string session_id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@session_id", SqlDbType.VarChar, session_id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM sessions WHERE session_id = @session_id");
        }
        // Adicione outros métodos conforme necessário
    }
}
