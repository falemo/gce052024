using APIDemolaySergipe;
using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SessionBL
    {
        private readonly SessionDAL _SessionDAL = new SessionDAL("");

        public SessionBL()
        {
        }

        public int InserirSession(int user_id, string session_id, bool flLogin)
        {
            return _SessionDAL.InserirSession(session_id,user_id,flLogin);
        }

        public int ExcluirSession(int id)
        {
            return _SessionDAL.ExcluirSession(id);
        }
        public int AtualizarSession(int id, string session_id, int user_id, bool flLogin )
        {
            return _SessionDAL.AtualizarSession(id, session_id, user_id, flLogin);
        }
        public DataTable ConsultarSessiones()
        {
            return _SessionDAL.ConsultarSessions();
        }
        public DataTable ConsultarSessionsUserID(int user_id)
        {
            return _SessionDAL.ConsultarSessionsUserID(user_id);
        }

        public Session[] ObterSession(int user_id)
        {
            DataTable dataTable = _SessionDAL.ConsultarSessionsUserID(user_id);
            Session[] sessionarray = new Session[dataTable.Rows.Count];
            int conta = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["user_id"].Equals(user_id))
                {
                    Session session = new Session();

                    sessionarray[conta] = new Session();
                    session.Id = (int)row["Id"];
                    session.UserId = (int)row["user_id"];
                    session.SessionID = row["session_id"].ToString();
                    session.CreatedAt = (DateTime)row["created_at"];
                    session.UpdatedAt = (DateTime)row["updated_at"];
                    session.FlLogin = Convert.ToBoolean(row["FlLogin"]);
                    sessionarray[conta] = session;
                    conta++;
                }
            }
            return sessionarray;
        }
        public Session ObterSessionSessionID(string session_id)
        {
            DataTable dataTable = _SessionDAL.ConsultarSessionsSessionID(session_id);
            Session session = new Session();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["session_id"].Equals(session_id))
                {
                    session.Id = (int)row["Id"];
                    session.UserId = (int)row["user_id"];
                    session.SessionID = row["session_id"].ToString();
                    session.CreatedAt = (DateTime)row["created_at"];
                    session.UpdatedAt = (DateTime)row["updated_at"];
                    session.FlLogin = Convert.ToBoolean(row["FlLogin"]);
                }
            }
            return session;
        }
    }
}
