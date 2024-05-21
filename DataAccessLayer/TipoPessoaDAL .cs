using System;
using System.Data;
using MySql.Data.MySqlClient;

using DataAccessLayer;

namespace APIDemolaySergipe
{
    public class TbTipoPessoaDAL
    {
        private SQLServerConexion SqlConnection;

        public TbTipoPessoaDAL(string stringcnx)
        {
            SqlConnection = new SQLServerConexion(stringcnx);
            SqlConnection.Open();
        }

        public int InserirTipoPessoa(string dsTipo, bool flAtivo)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsTipo", MySqlDbType.VarChar, dsTipo);
            SqlConnection.AdicionarParametro("@flAtivo", MySqlDbType.Bit, flAtivo);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbTipoPessoa (dsTipo, flAtivo) VALUES (@dsTipo, @flAtivo)");
        }

        public int AtualizarTipoPessoa(int id, string dsTipo, bool flAtivo)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            SqlConnection.AdicionarParametro("@dsTipo", MySqlDbType.VarChar, dsTipo);
            SqlConnection.AdicionarParametro("@flAtivo", MySqlDbType.Bit, flAtivo);

            return SqlConnection.ExecutaAtualizacao("UPDATE TbTipoPessoa SET dsTipo = @dsTipo, flAtivo = @flAtivo WHERE id = @id");
        }

        public int ExcluirTipoPessoa(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);

            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbTipoPessoa WHERE id = @id");
        }

        public DataTable ConsultarTiposPessoa()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoPessoa");
        }
        public DataTable ConsultarTiposPessoa(bool flAtivo)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@flAtivo", MySqlDbType.Bit, flAtivo);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoPessoa Where flAtivo = @flAtivo");
        }
        public DataTable ConsultarTipoPessoa(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbTipoPessoa WHERE id = @id");
        }
    }
}
