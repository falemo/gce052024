using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class PlanosDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public PlanosDAL()
        {
            SqlConnection.Open();
        }

        public int InserirPlanos(string dsPlano, int idTipoPlano, int qtdDiasPlano, bool Flativo, int diasParaPagamento, int idPersonal, bool flHabilitado)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsPlano", SqlDbType.VarChar, dsPlano);
            SqlConnection.AdicionarParametro("@idTipoPlano", SqlDbType.Int, idTipoPlano);
            SqlConnection.AdicionarParametro("@qtdDiasPlano", SqlDbType.Int, qtdDiasPlano);
            SqlConnection.AdicionarParametro("@Flativo", SqlDbType.Bit, Flativo);
            SqlConnection.AdicionarParametro("@diasParaPagamento", SqlDbType.Int, diasParaPagamento);
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            SqlConnection.AdicionarParametro("@flHabilitado", SqlDbType.Bit, flHabilitado);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbPlanos (dsPlano, idTipoPlano, qtdDiasPlano, Flativo, diasParaPagamento, idPersonal, flHabilitado) " +
                                                         "VALUES (@dsPlano, @idTipoPlano, @qtdDiasPlano, @Flativo, @diasParaPagamento, @idPersonal, @flHabilitado)");
        }

        public int ExcluirPlanos(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbPlanos WHERE Id = @id");
        }

        public DataTable ConsultarPlanos()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPlanos");
        }
        public DataTable ConsultarPlanos(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPlanos where id = @id");
        }
        public DataTable ConsultarPlanosPorPersonal(int idPersonal)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idPersonal", SqlDbType.Int, idPersonal);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPlanos WHERE idPersonal = @idPersonal");
        }
    }
}
