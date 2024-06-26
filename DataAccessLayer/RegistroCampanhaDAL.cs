﻿using System;
using System.Data;
using MySql.Data.MySqlClient;
using DataAccessLayer;

namespace APIDemolaySergipe
{
    public class TbRegistroCampanhaDAL
    {
        private SQLServerConexion SqlConnection;

        public TbRegistroCampanhaDAL(string stringcnx)
        {
            SqlConnection = new SQLServerConexion(stringcnx);
            SqlConnection.Open();
        }

        public int InserirRegistroCampanha(int idCampanha, DateTime dtRegistro, decimal vlrRegistrado, bool flNegativo, int idPessoa, string dsResumo)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            SqlConnection.AdicionarParametro("@dtRegistro", MySqlDbType.DateTime, dtRegistro);
            SqlConnection.AdicionarParametro("@vlrRegistrado", MySqlDbType.Decimal, vlrRegistrado);
            SqlConnection.AdicionarParametro("@flNegativo", MySqlDbType.Bit, flNegativo);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@dsResumo", MySqlDbType.VarChar, dsResumo);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbRegistroCampanha (idCampanha, dtRegistro, vlrRegistrado, flNegativo, idPessoa, dsResumo) " +
                                                     "VALUES (@idCampanha, @dtRegistro, @vlrRegistrado, @flNegativo, @idPessoa, @dsResumo)");
        }

        public int AtualizarRegistroCampanha(int id, int idCampanha, DateTime dtRegistro, decimal vlrRegistrado, bool flNegativo, int idPessoa, string dsResumo)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            SqlConnection.AdicionarParametro("@dtRegistro", MySqlDbType.DateTime, dtRegistro);
            SqlConnection.AdicionarParametro("@vlrRegistrado", MySqlDbType.Decimal, vlrRegistrado);
            SqlConnection.AdicionarParametro("@flNegativo", MySqlDbType.Bit, flNegativo);
            SqlConnection.AdicionarParametro("@idPessoa", MySqlDbType.Int64, idPessoa);
            SqlConnection.AdicionarParametro("@dsResumo", MySqlDbType.VarChar, dsResumo);

            return SqlConnection.ExecutaAtualizacao("UPDATE TbRegistroCampanha SET idCampanha = @idCampanha, dtRegistro = @dtRegistro, " +
                                                     "vlrRegistrado = @vlrRegistrado, flNegativo = @flNegativo, idPessoa = @idPessoa, dsResumo = @dsResumo WHERE id = @id");
        }

        public int ExcluirRegistroCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);

            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbRegistroCampanha WHERE id = @id");
        }

        public DataTable ConsultarRegistrosCampanha()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbRegistroCampanha");
        }
        public DataTable ConsultarValorRegistrosCampanha(int idCampanha)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            return SqlConnection.ExecutaConsulta("select id,  IFNULL(SUM(vlrRegistrado), 0) as vlracumulado from TbRegistroCampanha where idCampanha = @idCampanha group by id");
        }

        public DataTable ConsultarRegistroCampanha(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbRegistroCampanha WHERE id = @id");
        }

        public DataTable ConsultarRegistroPorCampanha(int idCampanha)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idCampanha", MySqlDbType.Int64, idCampanha);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbRegistroCampanha WHERE idCampanha = @idCampanha");
        }
    }
}
