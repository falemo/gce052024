using System;
using System.Data;
using MySql.Data.MySqlClient;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class TbCampanhaDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public TbCampanhaDAL()
        {
            SqlConnection.Open();
        }

        public int InserirCampanha(decimal vlrCampanha, DateTime dtInicio, DateTime dtFim, bool flAtiva, string dsPix, string dsPixInfo, int idPessoa, string filePath, decimal vlrMinimoSorte)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@vlrCampanha", MySqlDbType.Decimal, vlrCampanha);
            SqlConnection.AdicionarParametro("@dtInicio", MySqlDbType.DateTime, dtInicio);
            SqlConnection.AdicionarParametro("@dtFim", MySqlDbType.DateTime, dtFim);
            SqlConnection.AdicionarParametro("@flAtiva", MySqlDbType.Bit, flAtiva);
            SqlConnection.AdicionarParametro("@dsPix", MySqlDbType.VarChar, dsPix);
            SqlConnection.AdicionarParametro("@dsPixInfo", MySqlDbType.VarChar, dsPixInfo);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@filePath", MySqlDbType.Text, filePath);
            SqlConnection.AdicionarParametro("@vlrMinimoSorte", MySqlDbType.Decimal, vlrMinimoSorte);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbCampanha (vlrCampanha, dtInicio, dtFim, flAtiva, dsPix, dsPixInfo, idPessoa, file_path, vlrMinimoSorte) " +
                                                     "VALUES (@vlrCampanha, @dtInicio, @dtFim, @flAtiva, @dsPix, @dsPixInfo, @idPessoa, @filePath, @vlrMinimoSorte)");
        }

        public int AtualizarCampanha(int id, decimal vlrCampanha, DateTime dtInicio, DateTime dtFim, bool flAtiva, string dsPix, string dsPixInfo, int idPessoa, string filePath, decimal vlrMinimoSorte)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            SqlConnection.AdicionarParametro("@vlrCampanha", MySqlDbType.Decimal, vlrCampanha);
            SqlConnection.AdicionarParametro("@dtInicio", MySqlDbType.DateTime, dtInicio);
            SqlConnection.AdicionarParametro("@dtFim", MySqlDbType.DateTime, dtFim);
            SqlConnection.AdicionarParametro("@flAtiva", MySqlDbType.Bit, flAtiva);
            SqlConnection.AdicionarParametro("@dsPix", MySqlDbType.VarChar, dsPix);
            SqlConnection.AdicionarParametro("@dsPixInfo", MySqlDbType.VarChar, dsPixInfo);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@filePath", MySqlDbType.Text, filePath);
            SqlConnection.AdicionarParametro("@vlrMinimoSorte", MySqlDbType.Decimal, vlrMinimoSorte);

            return SqlConnection.ExecutaAtualizacao("UPDATE TbCampanha SET vlrCampanha = @vlrCampanha, dtInicio = @dtInicio, dtFim = @dtFim, flAtiva = @flAtiva, " +
                                                     "dsPix = @dsPix, dsPixInfo = @dsPixInfo, idPessoa = @idPessoa, file_path = @filePath, vlrMinimoSorte = @vlrMinimoSorte WHERE id = @id");
        }

        public int ExcluirCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);

            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbCampanha WHERE id = @id");
        }

        public DataTable ConsultarCampanhas()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbCampanha");
        }

        public DataTable ConsultarCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbCampanha WHERE id = @id");
        }
    }
}
