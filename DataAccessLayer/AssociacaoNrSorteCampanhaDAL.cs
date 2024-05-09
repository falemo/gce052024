using System;
using System.Data;
using MySql.Data.MySqlClient;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class AssociacaoNrSorteCampanhaDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public AssociacaoNrSorteCampanhaDAL()
        {
            SqlConnection.Open();
        }

        public int InserirAssociacaoNrSorteCampanha(int idNrSorte, int idSortePai, DateTime dtCadastro, decimal vlrConvervacao, decimal vlrSaldo )
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idNrSorte", MySqlDbType.Int64, idNrSorte);
            SqlConnection.AdicionarParametro("@idSortePai", MySqlDbType.Int64, idSortePai);
            SqlConnection.AdicionarParametro("@dtCadastro", MySqlDbType.DateTime, dtCadastro);
            SqlConnection.AdicionarParametro("@vlrConvervacao", MySqlDbType.Decimal, vlrConvervacao);
            SqlConnection.AdicionarParametro("@vlrSaldo", MySqlDbType.Decimal, vlrSaldo);

            return SqlConnection.ExecutaAtualizacao("INSERT INTO TbAssociacaoNrSorteCampanha (idNrSorte ,idSortePai ,dtCadastro  ,vlrConvervacao ,vlrSaldo ) " +
                                                     "VALUES (@idNrSorte ,@idSortePai ,@dtCadastro,@vlrConvervacao ,@vlrSaldo )");
        }

        public int AtualizarAssociacaoNrSorteCampanha(int idNrSorte, int idSortePai, DateTime dtCadastro, decimal vlrConvervacao, decimal vlrSaldo)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idNrSorte", MySqlDbType.Int64, idNrSorte);
            SqlConnection.AdicionarParametro("@idSortePai", MySqlDbType.Int64, idSortePai);
            SqlConnection.AdicionarParametro("@dtCadastro", MySqlDbType.DateTime, dtCadastro);
            SqlConnection.AdicionarParametro("@vlrConvervacao", MySqlDbType.Decimal, vlrConvervacao);
            SqlConnection.AdicionarParametro("@vlrSaldo", MySqlDbType.Decimal, vlrSaldo);

            return SqlConnection.ExecutaAtualizacao("UPDATE TbAssociacaoNrSorteCampanha SET dtCadastro = @dtCadastro, vlrConvervacao = @vlrConvervacao, vlrSaldo = @vlrSaldo " +
                                                     " WHERE idNrSorte = @idNrSorte And idSortePai= @idSortePai");
        } 

        public int ExcluirAssociacaoNrSorteCampanha(int idNrSorte, int idSortePai)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idNrSorte", MySqlDbType.Int64, idNrSorte);
            SqlConnection.AdicionarParametro("@idSortePai", MySqlDbType.Int64, idSortePai);

            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbAssociacaoNrSorteCampanha WHERE idNrSorte = @idNrSorte And idSortePai= @idSortePai");
        }

        public DataTable ConsultarAssociacaoNrSorteCampanha()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbAssociacaoNrSorteCampanha");
        }

        public DataTable ConsultarAssociacaoNrSorteCampanha(int idNrSorte, int idSortePai)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idNrSorte", MySqlDbType.Int64, idNrSorte);
            SqlConnection.AdicionarParametro("@idSortePai", MySqlDbType.Int64, idSortePai);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbAssociacaoNrSorteCampanha WHERE idNrSorte = @idNrSorte And idSortePai= @idSortePai");
        }

        public DataTable ConsultarAssociacaoNrSorteCampanha(int idSortePai)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idSortePai", MySqlDbType.Int64, idSortePai);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbAssociacaoNrSorteCampanha WHERE idSortePai= @idSortePai");
        }

    }
}
