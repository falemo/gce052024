using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using ModelLayer;

namespace ToolAccessLayer
{

    public class SessionManagers
    {
        private readonly IDictionary<string, Sessions> _sessions = new Dictionary<string, Sessions>();

        public static string GenerateRandomSessionId()
        {
            // Gera um valor aleatório de 32 bytes
            byte[] bytes = new byte[32];
            Random rand = new Random();
            rand.NextBytes(bytes);

            // Criptografa os bytes com o algoritmo SHA-256
            string sessionId = Convert.ToBase64String(bytes);

            // Retorna o ID de sessão criptografado
            return sessionId;
        }
        public Sessions GetSession(TbPessoas userId)
        {
            if (!_sessions.ContainsKey(userId.Email))
            {
                _sessions.Add(userId.Email, new Sessions
                {
                    UserId = userId,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(-30)
                }); ; ;
            }

            return _sessions[userId.Email];
        }

        public void InvalidateSession(TbPessoas userId)
        {
            _sessions.Remove(userId.Email);
        }
    }
}