using BusinessLayer;
using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class SubMenuBL
    {
        private readonly SubMenuDAL _subMenuDAL = new SubMenuDAL();
        public SubMenuBL()
        {
        }

        public int InserirSubMenu(string dsSubMenu, bool flProfessional, bool flHabilitado, int nrOrdem, int idMenu, bool Fladministrador, string dsLink)
        {
            return _subMenuDAL.InserirSubMenu(dsSubMenu, flProfessional, flHabilitado, nrOrdem, idMenu, Fladministrador, dsLink);
        }

        public int AtualizarSubMenu(int id, string dsSubMenu, bool flProfessional, bool flHabilitado, int nrOrdem, int idMenu, bool Fladministrador, string dsLink)
        {
            return _subMenuDAL.AtualizarSubMenu(id, dsSubMenu, flProfessional, flHabilitado, nrOrdem, idMenu, Fladministrador, dsLink);
        }

        public int ExcluirSubMenu(int id)
        {
            return _subMenuDAL.ExcluirSubMenu(id);
        }

        public DataTable ConsultarSubMenus()
        {
            return _subMenuDAL.ConsultarSubMenus();
        }
        public DataTable ConsultarSubMenus(int id)
        {
            return _subMenuDAL.ConsultarSubMenus(id);
        }
        public TbSubMenu ObterSubMenu(int id)
        {
            DataTable dataTable = _subMenuDAL.ConsultarSubMenus(id);
            TbSubMenu subMenu = new TbSubMenu();
            foreach (DataRow row in dataTable.Rows)
            {
                subMenu.IdSubMenu = (int)row["idSubMenu"];
                subMenu.DsSubMenu = (string)row["DsSubMenu"];
                subMenu.Flhabilitado = (bool)row["flProfissional"];
                subMenu.FlProfissional = (bool)row["FlHabilitado"];
                subMenu.NrOrdem = (int)row["NrOrdem"];
                subMenu.IdMenu = new MenuBL().ObterMenu((int)row["IdMenu"]);
                subMenu.Fladministrador = (bool)row["Fladministrador"];
                subMenu.DsLink = (string)row["DsLink"];
            }
            return subMenu;
        }
    }
}
