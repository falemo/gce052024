using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class MensalidadeAlunoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public MensalidadeAlunoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirMensalidadeAluno(int idStatusPagamento, int idPersonal, int idAluno, DateTime dtVencimento, float valor, DateTime? dtPagto, float? valorPago, float? valorDesconto, int idPlano)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idStatusPagamento", SqlDbType.Int, idStatusPagamento);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@idAluno", SqlDbType.Int, idAluno);
            SqlConnection.AdicionarParametro("@dtVencimento", SqlDbType.SmallDateTime, dtVencimento);
            SqlConnection.AdicionarParametro("@valor", SqlDbType.Float, valor);
            SqlConnection.AdicionarParametro("@DtPagto", SqlDbType.SmallDateTime, dtPagto);
            SqlConnection.AdicionarParametro("@valorPago", SqlDbType.Float, valorPago);
            SqlConnection.AdicionarParametro("@valorDesconto", SqlDbType.Float, valorDesconto);
            SqlConnection.AdicionarParametro("@idPlano", SqlDbType.Int, idPlano);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbMensalidadeAluno (idStatusPagamento, idPersonal, idAluno, dtVencimento, valor, DtPagto, valorPago, valorDesconto, idPlano) " +
                                                         "VALUES (@idStatusPagamento, @idPersonal, @idAluno, @dtVencimento, @valor, @DtPagto, @valorPago, @valorDesconto, @idPlano)");
        }

        public int ExcluirMensalidadeAluno(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbMensalidadeAluno WHERE Id = @id");
        }

        public DataTable ConsultarMensalidadesAlunos()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbMensalidadeAluno");
        }
        public DataTable ConsultarMensalidadesAlunos(int id)
        { 
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbMensalidadeAluno where id = @id");
        }
        public DataTable ConsultarMensalidadesAlunosPorAluno(int idAluno)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idAluno", SqlDbType.Int, idAluno);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbMensalidadeAluno WHERE idAluno = @idAluno");
        }
    }
}
