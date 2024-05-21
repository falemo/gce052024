using System;
using System.Data;
using MySql.Data.MySqlClient;
using DataAccessLayer;

namespace APIDemolaySergipe
{
    public class NrSorteCampanhaDAL
    {
        private SQLServerConexion SqlConnection;

        public NrSorteCampanhaDAL(string stringcnx)
        {
            SqlConnection = new SQLServerConexion(stringcnx);
            SqlConnection.Open();
        }

        public int InserirNrSorteCampanha(string nrCupom, DateTime dtCriacao, int idPessoa, decimal vlrAportado, string nmarqComprovante, bool flValidado, bool flProcesado, bool flCupom, int idCampanha)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nrCupom", MySqlDbType.VarChar, nrCupom);
            SqlConnection.AdicionarParametro("@dtCriacao", MySqlDbType.DateTime, dtCriacao);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@vlrAportado", MySqlDbType.Decimal, vlrAportado);
            SqlConnection.AdicionarParametro("@nmarqComprovante", MySqlDbType.VarChar, nmarqComprovante);
            SqlConnection.AdicionarParametro("@flValidado", MySqlDbType.Bit, flValidado);
            SqlConnection.AdicionarParametro("@flProcesado", MySqlDbType.Bit, flProcesado);
            SqlConnection.AdicionarParametro("@flCupom", MySqlDbType.Bit, flCupom);
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbNrSorteCampanha (nrCupom, dtCriacao, idPessoa, vlrAportado, nmarqComprovante, flValidado, flProcesado, flCupom, idCampanha) " +
                                                     "VALUES (@nrCupom, @dtCriacao, @idPessoa, @vlrAportado, @nmarqComprovante, @flValidado, @flProcesado, @flCupom, @idCampanha)");


        }

        public int AtualizarNrSorteCampanha(int id, string nrCupom, DateTime dtCriacao, int idPessoa, decimal vlrAportado, string nmarqComprovante, bool flValidado, bool flProcesado, bool flCupom, int idCampanha)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            SqlConnection.AdicionarParametro("@nrCupom", MySqlDbType.VarChar, string.IsNullOrEmpty(nrCupom) ? (object)DBNull.Value : nrCupom);
            SqlConnection.AdicionarParametro("@dtCriacao", MySqlDbType.DateTime, dtCriacao);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@vlrAportado", MySqlDbType.Decimal, vlrAportado);
            SqlConnection.AdicionarParametro("@nmarqComprovante", MySqlDbType.VarChar, nmarqComprovante);
            SqlConnection.AdicionarParametro("@flValidado", MySqlDbType.Bit, flValidado);
            SqlConnection.AdicionarParametro("@flProcesado", MySqlDbType.Bit, flProcesado);
            SqlConnection.AdicionarParametro("@flCupom", MySqlDbType.Bit, flCupom);
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);

            return SqlConnection.ExecutaAtualizacao("UPDATE TbNrSorteCampanha SET nrCupom = @nrCupom, dtCriacao = @dtCriacao, idPessoa = @idPessoa, " +
                                                     "vlrAportado = @vlrAportado, nmarqComprovante = @nmarqComprovante, flValidado = @flValidado, " +
                                                     "flProcesado = @flProcesado, flCupom = @flCupom, idCampanha = @idCampanha WHERE id = @id");
        }

        public int ExcluirNrSorteCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);

            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbNrSorteCampanha WHERE id = @id");
        }

        public DataTable ConsultarNrSorteCampanhas()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbNrSorteCampanha");
        }
        public DataTable ConsultarNrSorteCampanhasDuplicadaporCampanha(int idCampanha,string nrCupom)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nrCupom", MySqlDbType.VarChar, nrCupom);
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbNrSorteCampanha where nrCupom = @nrCupom And idCampanha = @idCampanha");
        }
        public DataTable ConsultarListadeNrSorteaProcessar(int idCampanha, int idPessoa)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbNrSorteCampanha where idPessoa = @idPessoa And idCampanha = @idCampanha And flProcesado = 0 Order by dtCriacao");
        }
        public DataTable ConsultarNrSorteCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbNrSorteCampanha WHERE id = @id");
        }
        public DataTable ConsultarNrSorteCampanhas(int idCampanha)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbNrSorteCampanha WHERE idCampanha = @idCampanha");
        }
        public DataTable ConsultarNrSorteCampanhasPessoa(int idCampanha)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            return SqlConnection.ExecutaConsulta("SELECT distinct idPessoa  FROM TbNrSorteCampanha WHERE idCampanha = @idCampanha");
        }
        public DataTable ConsultarLancamentoDisponivel(int idCampanha, int idPessoa)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            return SqlConnection.ExecutaConsulta(@"SELECT idPessoa , idCampanha , SUM(IFNULL(vlrAportado, 0)) as vlrAportado 
                                                   FROM TbNrSorteCampanha 
                                                   where idPessoa = @idPessoa And idCampanha = @idCampanha And flProcesado = 0
                                                   Group by idPessoa , idCampanha");
        }
        public DataTable ListaLancamentoDisponivel(int idCampanha, int idPessoa)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            return SqlConnection.ExecutaConsulta(@"SELECT * 
                                                   FROM TbidPessoaNrSorteCampanha 
                                                   where idPessoa = @idPessoa And idCampanha = @idCampanha And flProcesado = 0 Order by dtCriacao desc");
        }
        public int UPDATECupom(int id, string nrCupom)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            SqlConnection.AdicionarParametro("@nrCupom", MySqlDbType.VarChar, nrCupom);
            return SqlConnection.ExecutaAtualizacao(@"UPDATE TbNrSorteCampanha 
                                                   SET nrCupom = @nrCupom
                                                   where id = @id");
        }
        public int UPDATEFlagCupom(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao(@"UPDATE TbNrSorteCampanha 
                                                   SET flCupom = 1
                                                   where id = @id");
        }
        public int UPDATELancamentoDisponivel(int idCampanha, int idPessoa)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            return SqlConnection.ExecutaAtualizacao(@"UPDATE TbNrSorteCampanha 
                                                   SET flProcesado = 1
                                                   where idPessoa = @idPessoa And idCampanha = @idCampanha And flProcesado = 0");
        }
        public int UPDATELancamentoDisponivel(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao(@"UPDATE TbNrSorteCampanha 
                                                   SET flProcesado = 1
                                                   where id = @id And flProcesado = 0");
        }
    }
}
