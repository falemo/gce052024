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
    public class AlunoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public AlunoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirAluno(DateTime dtAluno, int idSituacao, int? idPessoa)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dtAluno", SqlDbType.SmallDateTime, dtAluno);
            SqlConnection.AdicionarParametro("@idSituacao", SqlDbType.Int, idSituacao);
            SqlConnection.AdicionarParametro("@idPessoa", SqlDbType.Int, idPessoa ?? (object)DBNull.Value);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbAluno (dtaluno, idSituacao, idPessoa) " +
                                              "VALUES (@dtAluno, @idSituacao, @idPessoa)");      
        }

        public int AtualizarAluno(int id, DateTime dtAluno, int idSituacao, int? idPessoa)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dtAluno", SqlDbType.SmallDateTime, dtAluno);
            SqlConnection.AdicionarParametro("@idSituacao", SqlDbType.Int, idSituacao);
            SqlConnection.AdicionarParametro("@idPessoa", SqlDbType.Int, idPessoa ?? (object)DBNull.Value);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbAluno SET dtaluno = @dtAluno, idSituacao = @idSituacao, idPessoa = @idPessoa " +
                                                             "WHERE Id = @id");                            
        }

        public int ExcluirAluno(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbAluno WHERE Id = @id");
        }

        public DataTable ConsultarAlunos()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbAluno A Join TbPessoas P on A.idPessoa = P.Id Join TbSituacao S on S.Id = A.idSituacao Join TbCidade C on C.Id = P.idCidade Join TbEstado E on E.Id = C.idEstado Join TbPais Pa on Pa.Id = E.idPais");
        }
        public DataTable ConsultarAlunos(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbAluno A Join TbPessoas P on A.idPessoa = P.Id Join TbSituacao S on S.Id = A.idSituacao Join TbCidade C on C.Id = P.idCidade Join TbEstado E on E.Id = C.idEstado Join TbPais Pa on Pa.Id = E.idPais Where A.id = @id");
        }

        // Adicione outros métodos conforme necessário
    }
}
