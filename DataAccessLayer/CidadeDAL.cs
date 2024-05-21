using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using DataAccessLayer;

namespace APIDemolaySergipe
{
    public class CidadeDAL
    {
        private SQLServerConexion SqlConnection;

        public CidadeDAL(string stringcnx)
        {
            SqlConnection = new SQLServerConexion(stringcnx);
            SqlConnection.Open();
        }

        public int InserirCidade(string nmCidade, int idEstado)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nmCidade", MySqlDbType.VarChar, nmCidade);
            SqlConnection.AdicionarParametro("@idEstado", MySqlDbType.Int64, idEstado);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbCidade (nmCidade, idEstado) " +
                                                         "VALUES (@nmCidade, @idEstado)");
        }

        public int AtualizarCidade(int id, string nmCidade, int idEstado)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nmCidade", MySqlDbType.VarChar, nmCidade);
            SqlConnection.AdicionarParametro("@idEstado", MySqlDbType.Int64, idEstado);
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbCidade SET nmCidade = @nmCidade, idEstado = @idEstado WHERE Id = @id");
        }

        public int ExcluirCidade(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbCidade WHERE Id = @id");
        }

        public DataTable ConsultarCidades(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbCidade where id = @id");
        }
        public DataTable ConsultarCidades()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbCidade");
        }
        public DataTable ConsultarCidadesGrid()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT C.*,P.nmPais+'.' + E.nmEstado as nmEstado, E.sigla, P.Id as idPais, P.nmPais, P.codPais FROM TbCidade C Join TbEstado E on E.id = C.idEstado Join TbPais P on P.id = E.idPais Order by P.nmPais, E.NmEstado");
        }
        public DataTable ConsultarCidadesPorEstado(int idEstado)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idEstado", MySqlDbType.Int64, idEstado);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbCidade WHERE idEstado = @idEstado");
        }
    }
}
