using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class CidadeDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public CidadeDAL()
        {
            SqlConnection.Open();
        }

        public int InserirCidade(string nmCidade, int idEstado)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nmCidade", SqlDbType.VarChar, nmCidade);
            SqlConnection.AdicionarParametro("@idEstado", SqlDbType.Int, idEstado);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbCidade (nmCidade, idEstado) " +
                                                         "VALUES (@nmCidade, @idEstado)");
        }

        public int AtualizarCidade(int id, string nmCidade, int idEstado)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nmCidade", SqlDbType.VarChar, nmCidade);
            SqlConnection.AdicionarParametro("@idEstado", SqlDbType.Int, idEstado);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbCidade SET nmCidade = @nmCidade, idEstado = @idEstado WHERE Id = @id");
        }

        public int ExcluirCidade(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbCidade WHERE Id = @id");
        }

        public DataTable ConsultarCidades(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
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
            SqlConnection.AdicionarParametro("@idEstado", SqlDbType.Int, idEstado);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbCidade WHERE idEstado = @idEstado");
        }
    }
}
