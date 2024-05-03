using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;using MySql.Data.MySqlClient;

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
            SqlConnection.AdicionarParametro("@dsMenu", MySqlDbType.VarChar, dsMenu);
            SqlConnection.AdicionarParametro("@flProfessional", MySqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@flHabilitado", MySqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@nrOrdem", MySqlDbType.Int64, nrOrdem);
            SqlConnection.AdicionarParametro("@grupo", MySqlDbType.VarChar, grupo);
            SqlConnection.AdicionarParametro("@fladministrador", MySqlDbType.Bit, Fladministrador);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbMenu (dsMenu, flProfessional, flHabilitado, nrOrdem, grupo, fladministrador) " +
                                                                   "VALUES (@dsMenu, @flProfessional, @flHabilitado, @nrOrdem, @grupo, @fladministrador)");
        }

        public int AtualizarMenu(int id, string dsMenu, bool flProfessional, bool flHabilitado, int nrOrdem, string grupo, bool Fladministrador)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsMenu", MySqlDbType.VarChar, dsMenu);
            SqlConnection.AdicionarParametro("@flProfessional", MySqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@flHabilitado", MySqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@nrOrdem", MySqlDbType.Int64, nrOrdem); 
            SqlConnection.AdicionarParametro("@grupo", MySqlDbType.VarChar, grupo);
            SqlConnection.AdicionarParametro("@Fladministrador", MySqlDbType.Bit, Fladministrador);
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbMenu SET dsMenu = @dsMenu, flProfessional = @flProfessional, " +
                                                                "flHabilitado = @flHabilitado, grupo = @grupo, nrOrdem = @nrOrdem, Fladministrador = @Fladministrador WHERE Id = @id");
        }

        public int ExcluirMenu(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
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
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbMenu WHERE Id = @id order by grupo");
        }
    }
}
