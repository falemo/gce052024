using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlTypes;
using DataAccessLayer;

namespace APIDemolaySergipe
{
    public class SubMenuDAL
    {
        private SQLServerConexion SqlConnection;

        public SubMenuDAL(string stringcnx)
        {
            SqlConnection = new SQLServerConexion(stringcnx);
            SqlConnection.Open();
        }

        public int InserirSubMenu(string dsSubMenu, bool flProfessional, bool flHabilitado, int nrOrdem, int idMenu, bool Fladministrador, string dsLink)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsSubMenu", MySqlDbType.VarChar, dsSubMenu);
            SqlConnection.AdicionarParametro("@flProfessional", MySqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@flHabilitado", MySqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@nrOrdem", MySqlDbType.Int64, nrOrdem);
            SqlConnection.AdicionarParametro("@idMenu", MySqlDbType.Int64, idMenu);
            SqlConnection.AdicionarParametro("@Fladministrador", MySqlDbType.Bit, Fladministrador); 
            SqlConnection.AdicionarParametro("@dsLink", MySqlDbType.VarChar, dsLink);
            
            return SqlConnection.ExecutaAtualizacaoWithIdentityColuna("INSERT INTO TbSubMenu (dsSubMenu, flProfissional, flHabilitado, NrOrdem, idMenu, Fladministrador,dsLink) " +
                                                               "VALUES (@dsSubMenu, @flProfessional, @flHabilitado, @nrOrdem, @idMenu, @Fladministrador,@dsLink)", "idSubMenu");
        }

        public int AtualizarSubMenu(int idSubMenu, string dsSubMenu, bool flProfessional, bool flHabilitado, int nrOrdem, int idMenu, bool Fladministrador, string dsLink)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@dsSubMenu", MySqlDbType.VarChar, dsSubMenu);
            SqlConnection.AdicionarParametro("@flProfessional", MySqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@flHabilitado", MySqlDbType.Bit, flHabilitado);
            SqlConnection.AdicionarParametro("@nrOrdem", MySqlDbType.Int64, nrOrdem);
            SqlConnection.AdicionarParametro("@fladministrador", MySqlDbType.Bit, Fladministrador);
            SqlConnection.AdicionarParametro("@idSubMenu", MySqlDbType.Int64, idSubMenu);
            SqlConnection.AdicionarParametro("@idMenu", MySqlDbType.Int64, idMenu);
            SqlConnection.AdicionarParametro("@dsLink", MySqlDbType.VarChar, dsLink);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbSubMenu SET dsSubMenu = @dsSubMenu, flProfissional = @flProfessional, " +
                                                            "flHabilitado = @flHabilitado, NrOrdem = @nrOrdem, idMenu = @idMenu, Fladministrador = @fladministrador, dsLink = @dsLink WHERE IdSubMenu = @idSubMenu");
        }

        public int ExcluirSubMenu(int idSubMenu)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idSubMenu", MySqlDbType.Int64, idSubMenu);
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
            SqlConnection.AdicionarParametro("@idMenu", MySqlDbType.Int64, idMenu);
            return SqlConnection.ExecutaConsulta("SELECT S.*, M.dsMenu FROM TbSubMenu S join TbMenu M on S.idMenu = M.id WHERE idMenu = @idMenu order by NrOrdem");
        }

    }
}
