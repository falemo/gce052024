using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using MySql.Data.MySqlClient;



namespace APIDemolaySergipe
{
    public class campanhaDAL
    {

        private SQLServerConexion SqlConnection; // = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public campanhaDAL(string stringcnx)
        {
            SqlConnection = new SQLServerConexion(stringcnx);
            SqlConnection.Open();
        }   


        public int InserirCampanha(decimal vlrCampanha, DateTime dtInicio, DateTime dtFim, bool flAtiva, string dsPix, string dsPixInfo, int idPessoa, string file_path, decimal vlrMinimoSorte)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@vlrCampanha", MySqlDbType.Decimal, vlrCampanha);
            SqlConnection.AdicionarParametro("@dtInicio", MySqlDbType.DateTime, dtInicio);
            SqlConnection.AdicionarParametro("@dtFim", MySqlDbType.Int64, dtFim);
            SqlConnection.AdicionarParametro("@flAtiva", MySqlDbType.Bit, flAtiva);
            SqlConnection.AdicionarParametro("@dsPix", MySqlDbType.VarChar, dsPix);
            SqlConnection.AdicionarParametro("@dsPixInfo", MySqlDbType.VarChar, dsPixInfo);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@file_path", MySqlDbType.VarChar, file_path);
            SqlConnection.AdicionarParametro("@vlrMinimoSorte", MySqlDbType.Decimal, vlrMinimoSorte);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbCampanha (vlrCampanha, dtInicio, dtFim, flAtiva, dsPix, dsPixInfo, idPessoa, file_path, vlrMinimoSorte) " +
                                  "VALUES (@vlrCampanha, @dtInicio, @dtFim, @flAtiva, @dsPix, @dsPixInfo, @idPessoa, @file_path, @vlrMinimoSorte)");
        }
        public int AtualizarCampanha(int id, decimal vlrCampanha, DateTime dtInicio, DateTime dtFim, bool flAtiva, string dsPix, string dsPixInfo, int idPessoa, string file_path, decimal vlrMinimoSorte)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@vlrCampanha", MySqlDbType.Decimal, vlrCampanha);
            SqlConnection.AdicionarParametro("@dtInicio", MySqlDbType.DateTime, dtInicio);
            SqlConnection.AdicionarParametro("@dtFim", MySqlDbType.Int64, dtFim);
            SqlConnection.AdicionarParametro("@flAtiva", MySqlDbType.Bit, flAtiva);
            SqlConnection.AdicionarParametro("@dsPix", MySqlDbType.VarChar, dsPix);
            SqlConnection.AdicionarParametro("@dsPixInfo", MySqlDbType.VarChar, dsPixInfo);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@file_path", MySqlDbType.VarChar, file_path);
            SqlConnection.AdicionarParametro("@vlrMinimoSorte", MySqlDbType.Decimal, vlrMinimoSorte);
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("UPDATE TbCampanha SET vlrCampanha = @vlrCampanha, dtInicio = @dtInicio, dtFim = @dtFim, flAtiva = @flAtiva, " +
                                  "dsPix = @dsPix, dsPixInfo = @dsPixInfo, idPessoa = @idPessoa, file_path = @file_path, vlrMinimoSorte = @vlrMinimoSorte " +
                                  "WHERE id = @id");

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
            return SqlConnection.ExecutaConsulta("SELECT C.*, P.nome FROM TbCampanha C Join TbPessoas P on C.idPessoa = P.id order by dtInicio desc");
        }
        public DataTable ConsultarCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbCampanha WHERE id = @id");
        }
    }
}
