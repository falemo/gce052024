using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class EstadoDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public EstadoDAL()
        {
            SqlConnection.Open();
        }

        public int InserirEstado(string nmEstado, string sigla, int idPais)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nmEstado", SqlDbType.VarChar, nmEstado);
            SqlConnection.AdicionarParametro("@sigla", SqlDbType.VarChar, sigla);
            SqlConnection.AdicionarParametro("@idPais", SqlDbType.Int, idPais);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbEstado (nmEstado, sigla, idPais) " +
                                                         "VALUES (@nmEstado, @sigla, @idPais)");
        }

        public int AtualizarEstado(int id, string nmEstado, string sigla, int idPais)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nmEstado", SqlDbType.VarChar, nmEstado);
            SqlConnection.AdicionarParametro("@sigla", SqlDbType.VarChar, sigla);
            SqlConnection.AdicionarParametro("@idPais", SqlDbType.Int, idPais);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbEstado SET nmEstado = @nmEstado, sigla = @sigla, idPais = @idPais WHERE Id = @id");
        }

        public int ExcluirEstado(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbEstado WHERE Id = @id");
        }

        public DataTable ConsultarEstados()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbEstado");
        }
        public DataTable ConsultarEstadosGrid()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT E.*, P.nmPais + ' ('+ cast(P.codPais as varchar)+')' as NmPais,  P.nmPais + ' ('+ cast(P.codPais as varchar)+')' + ' - ' +E.nmEstado as NmEstadoG  FROM TbEstado E Join TbPais P on P.Id = E.idPais Order by P.NmPais, E.nmEstado desc");
        }
        public DataTable ConsultarEstados(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbEstado where id = @id");
        }
        public DataTable ConsultarEstadosPorPais(int idPais)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPais", SqlDbType.Int, idPais);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbEstado WHERE idPais = @idPais");
        }
    }
}
