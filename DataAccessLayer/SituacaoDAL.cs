﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using DataAccessLayer;

namespace APIDemolaySergipe
{
    public class SituacaoDAL
    {
        private SQLServerConexion SqlConnection;

        public SituacaoDAL(string stringcnx)
        {
            SqlConnection = new SQLServerConexion(stringcnx);
            SqlConnection.Open();
        }

        public int InserirSituacao(string descricao, bool flBloqueado, bool flNovo, bool flSuspenso, bool flAtivo, int idGrupo, bool flEstadoFinal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@descricao", MySqlDbType.VarChar, descricao);
            SqlConnection.AdicionarParametro("@flBloqueado", MySqlDbType.Bit, flBloqueado);
            SqlConnection.AdicionarParametro("@flNovo", MySqlDbType.Bit, flNovo);
            SqlConnection.AdicionarParametro("@flSuspenso", MySqlDbType.Bit, flSuspenso);
            SqlConnection.AdicionarParametro("@flAtivo", MySqlDbType.Bit, flAtivo);
            SqlConnection.AdicionarParametro("@idGrupo", MySqlDbType.Int64, idGrupo);
            SqlConnection.AdicionarParametro("@flEstadoFinal", MySqlDbType.Bit, flEstadoFinal);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbSituacao (descricao, flBloqueado, flNovo, flSuspenso, flAtivo,idGrupo,flEstadoFinal) " +
                                                         "VALUES (@descricao, @flBloqueado, @flNovo, @flSuspenso, @flAtivo,@idGrupo,@flEstadoFinal)");
        }

        public int AtualizarSituacao(int id, string descricao, bool flBloqueado, bool flNovo, bool flSuspenso, bool flAtivo, int idGrupo, bool flEstadoFinal)
        {

            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@descricao", MySqlDbType.VarChar, descricao);
            SqlConnection.AdicionarParametro("@flBloqueado", MySqlDbType.Bit, flBloqueado);
            SqlConnection.AdicionarParametro("@flNovo", MySqlDbType.Bit, flNovo);
            SqlConnection.AdicionarParametro("@flSuspenso", MySqlDbType.Bit, flSuspenso);
            SqlConnection.AdicionarParametro("@flAtivo", MySqlDbType.Bit, flAtivo);
            SqlConnection.AdicionarParametro("@idGrupo", MySqlDbType.Int64, flAtivo);
            SqlConnection.AdicionarParametro("@flEstadoFinal", MySqlDbType.Bit, flAtivo);
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("UPDATE TbSituacao SET descricao = @descricao, flBloqueado = @flBloqueado, flNovo = @flNovo, " +
                                  "flSuspenso = @flSuspenso, flAtivo = @flAtivo, idGrupo = @idGrupo, flEstadoFinal = @flEstadoFinal " +
                                  "WHERE Id = @id");
        }

        public int ExcluirSituacao(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbSituacao WHERE Id = @id");
        }

        public DataTable ConsultarSituacoes()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbSituacao");
        }
        public DataTable ConsultarSituacoes(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbSituacao WHERE Id = @id");
        }
    }
}
