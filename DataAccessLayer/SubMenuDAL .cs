using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;
using System.Data.SqlTypes;

namespace DataAccessLayer
{
    public class SubMenuDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public SubMenuDAL()
        {
            SqlConnection.Open();
        }

        public int InserirSubMenu(string dsSubMenu, bool flProfessional, bool flHabilitado, int nrOrdem, int idMenu, bool Fladministrador, string dsLink)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsSubMenu", SqlDbType.VarChar, dsSubMenu);
            SqlConnection.AdicionarParametro("@flProfessional", SqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@flHabilitado", SqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@nrOrdem", SqlDbType.Int, nrOrdem);
            SqlConnection.AdicionarParametro("@idMenu", SqlDbType.Int, idMenu);
            SqlConnection.AdicionarParametro("@Fladministrador", SqlDbType.Bit, Fladministrador); 
            SqlConnection.AdicionarParametro("@dsLink", SqlDbType.VarChar, dsLink);
            
            return SqlConnection.ExecutaAtualizacaoWithIdentityColuna("INSERT INTO TbSubMenu (dsSubMenu, flProfissional, flHabilitado, NrOrdem, idMenu, Fladministrador,dsLink) " +
                                                               "VALUES (@dsSubMenu, @flProfessional, @flHabilitado, @nrOrdem, @idMenu, @Fladministrador,@dsLink)", "idSubMenu");
        }

        public int AtualizarSubMenu(int idSubMenu, string dsSubMenu, bool flProfessional, bool flHabilitado, int nrOrdem, int idMenu, bool Fladministrador, string dsLink)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsSubMenu", SqlDbType.VarChar, dsSubMenu);
            SqlConnection.AdicionarParametro("@flProfessional", SqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@flHabilitado", SqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@nrOrdem", SqlDbType.Int, nrOrdem);
            SqlConnection.AdicionarParametro("@fladministrador", SqlDbType.Bit, Fladministrador);
            SqlConnection.AdicionarParametro("@idSubMenu", SqlDbType.Int, idSubMenu);
            SqlConnection.AdicionarParametro("@idMenu", SqlDbType.Int, idMenu);
            SqlConnection.AdicionarParametro("@dsLink", SqlDbType.VarChar, dsLink);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbSubMenu SET dsSubMenu = @dsSubMenu, flProfissional = @flProfessional, " +
                                                            "flHabilitado = @flHabilitado, NrOrdem = @nrOrdem, idMenu = @idMenu, Fladministrador = @fladministrador, dsLink = @dsLink WHERE IdSubMenu = @idSubMenu");
        }

        public int ExcluirSubMenu(int idSubMenu)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idSubMenu", SqlDbType.Int, idSubMenu);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbSubMenu WHERE IdSubMenu = @idSubMenu");
        }

        public DataTable ConsultarSubMenus()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT S.*, M.dsMenu FROM TbSubMenu S join TbMenu M on S.idMenu = M.id order by idMenu,NrOrdem");
        }

        public DataTable ConsultarSubMenus(int idMenu)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idMenu", SqlDbType.Int, idMenu);
            return SqlConnection.ExecutaConsulta("SELECT S.*, M.dsMenu FROM TbSubMenu S join TbMenu M on S.idMenu = M.id WHERE idMenu = @idMenu order by NrOrdem");
        }

    }
}
