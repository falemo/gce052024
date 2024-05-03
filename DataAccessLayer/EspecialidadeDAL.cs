using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class EspecialidadeDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public EspecialidadeDAL()
        {
            SqlConnection.Open();
        }

        public int InserirEspecialidade(string dsEspecialidade, int idTipoEspecialidade)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsEspecialidade", SqlDbType.VarChar, dsEspecialidade);
            SqlConnection.AdicionarParametro("@idTipoEspecialidade", SqlDbType.Int, idTipoEspecialidade);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbEspecialidade (dsEspecialidade, idTipoEspecialidade) " +
                                                         "VALUES (@dsEspecialidade, @idTipoEspecialidade)");
        }

        public int AtualizarEspecialidade(int id, string dsEspecialidade, int idTipoEspecialidade)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsEspecialidade", SqlDbType.VarChar, dsEspecialidade);
            SqlConnection.AdicionarParametro("@idTipoEspecialidade", SqlDbType.Int, idTipoEspecialidade);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbEspecialidade SET dsEspecialidade = @dsEspecialidade, idTipoEspecialidade = @idTipoEspecialidade WHERE Id = @id");
        }

        public int ExcluirEspecialidade(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbEspecialidade WHERE Id = @id");
        }

        public DataTable ConsultarEspecialidades()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbEspecialidade");
        }
        public DataTable ConsultarEspecialidades(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbEspecialidade Where id = @id");
        }
        public DataTable ConsultarEspecialidadesPorTipoEspecialidade(int idTipoEspecialidade)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idTipoEspecialidade", SqlDbType.Int, idTipoEspecialidade);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbEspecialidade WHERE idTipoEspecialidade = @idTipoEspecialidade");
        }
    }
}
