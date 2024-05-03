using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class MenuDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public MenuDAL()
        {
            SqlConnection.Open();
        }


        public int InserirMenu(string dsMenu, bool flProfessional, bool flHabilitado, int nrOrdem, string grupo,bool Fladministrador)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsMenu", SqlDbType.VarChar, dsMenu);
            SqlConnection.AdicionarParametro("@flProfessional", SqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@flHabilitado", SqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@nrOrdem", SqlDbType.Int, nrOrdem);
            SqlConnection.AdicionarParametro("@grupo", SqlDbType.VarChar, grupo);
            SqlConnection.AdicionarParametro("@fladministrador", SqlDbType.Bit, Fladministrador);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbMenu (dsMenu, flProfessional, flHabilitado, nrOrdem, grupo, fladministrador) " +
                                                                   "VALUES (@dsMenu, @flProfessional, @flHabilitado, @nrOrdem, @grupo, @fladministrador)");
        }

        public int AtualizarMenu(int id, string dsMenu, bool flProfessional, bool flHabilitado, int nrOrdem, string grupo, bool Fladministrador)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsMenu", SqlDbType.VarChar, dsMenu);
            SqlConnection.AdicionarParametro("@flProfessional", SqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@flHabilitado", SqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@nrOrdem", SqlDbType.Int, nrOrdem); 
            SqlConnection.AdicionarParametro("@grupo", SqlDbType.VarChar, grupo);
            SqlConnection.AdicionarParametro("@Fladministrador", SqlDbType.Bit, Fladministrador);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbMenu SET dsMenu = @dsMenu, flProfessional = @flProfessional, " +
                                                                "flHabilitado = @flHabilitado, grupo = @grupo, nrOrdem = @nrOrdem, Fladministrador = @Fladministrador WHERE Id = @id");
        }

        public int ExcluirMenu(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbMenu WHERE Id = @id");
        }

        public DataTable ConsultarMenus()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbMenu order by grupo, nrOrdem ");
        }

        public DataTable ConsultarMenus(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbMenu WHERE Id = @id order by grupo");
        }
    }
}
