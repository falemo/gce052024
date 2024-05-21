using APIDemolaySergipe;
using BusinessLayer;
using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public class MenuBL
    {
        private readonly MenuDAL _menuDAL = new MenuDAL("");
        public MenuBL()
        {
        }

        public int InserirMenu(string dsMenu, bool flProfessional, bool flHabilitado, int nrOrdem, string grupo, bool Fladministrador)
        {
            return _menuDAL.InserirMenu(dsMenu, flProfessional, flHabilitado, nrOrdem, grupo, Fladministrador);
        }

        public int AtualizarMenu(int id, string dsMenu, bool flProfessional, bool flHabilitado, int nrOrdem, string grupo, bool Fladministrador)
        {
            return _menuDAL.AtualizarMenu(id, dsMenu, flProfessional, flHabilitado, nrOrdem, grupo, Fladministrador);
        }

        public int ExcluirMenu(int id)
        {
            return _menuDAL.ExcluirMenu(id);
        }

        public DataTable ConsultarMenus()
        {
            return _menuDAL.ConsultarMenus();
        }

        public TbMenu ObterMenu(int id)
        {
            DataTable dataTable = _menuDAL.ConsultarMenus(id);
            TbMenu menu = new TbMenu();
            foreach (DataRow row in dataTable.Rows)
            {
                menu.Id = (int)row["Id"];
                menu.DsMenu = (string)row["DsMenu"];
                menu.FlProfessional = Convert.ToBoolean(row["FlProfessional"]);
                menu.FlHabilitado = Convert.ToBoolean(row["FlHabilitado"]);
                menu.NrOrdem = (int)row["NrOrdem"];
                menu.grupo = (string)row["grupo"];
                menu.Fladministrador = Convert.ToBoolean(row["Fladministrador"]);

            }
            return menu;
        }
        public TbMenu ObterMenucomSubMenu(int id)
        {
            DataTable dataTable = _menuDAL.ConsultarMenus(id);
            TbMenu menu = new TbMenu();
            foreach (DataRow row in dataTable.Rows)
            {
                menu.Id = (int)row["Id"];
                menu.DsMenu = (string)row["DsMenu"];
                menu.FlProfessional = Convert.ToBoolean(row["FlProfessional"]);
                menu.FlHabilitado = Convert.ToBoolean(row["FlHabilitado"]);
                menu.NrOrdem = (int)row["NrOrdem"];
                menu.grupo = (string)row["grupo"];
                menu.Fladministrador = Convert.ToBoolean(row["Fladministrador"]);

                DataTable subMenu = new SubMenuBL().ConsultarSubMenus(id);
                menu.TbSubMenu = new TbSubMenu[subMenu.Rows.Count];
                int cont = 0;
                
                foreach (DataRow rowsubMenu in subMenu.Rows)
                {
                    TbSubMenu sub = new TbSubMenu();
                    sub.IdMenu = menu;
                    sub.IdSubMenu = (int)rowsubMenu["IdSubMenu"];
                    sub.NrOrdem = (int)rowsubMenu["NrOrdem"];
                    sub.FlProfissional = Convert.ToBoolean(rowsubMenu["flProfissional"]);
                    sub.Flhabilitado = Convert.ToBoolean(rowsubMenu["flhabilitado"]);
                    sub.DsSubMenu = (string)rowsubMenu["dsSubMenu"];
                    sub.DsLink = (string)rowsubMenu["dsLink"];
                    sub.Fladministrador = Convert.ToBoolean(rowsubMenu["Fladministrador"]); 

                    menu.TbSubMenu[cont] = sub;
                    cont++;
                }
            }
            return menu;
        }

        public StringBuilder GenerateMenuOLD(bool FlProfessional, bool flAdministrador)
        {
            // 1. Retrieve menu items from the database
            // (Replace with your specific data access logic)
            
            DataTable tabela = ConsultarMenus();

            if (tabela.Rows.Count > 0)
            {
                // 2. Build the HTML structure for the menu
                StringBuilder sb = new StringBuilder();
                string grupo = "&&&&&&";

                // Iterate through menus
                for (int i = 0; i <= tabela.Rows.Count - 1; i++)
                {
                    TbMenu mn = ObterMenucomSubMenu((int)tabela.Rows[i]["id"]);

                    if (mn.TbSubMenu.Length > 0)
                    {

                        if (mn.FlProfessional == FlProfessional && FlProfessional == true && mn.FlHabilitado == true)
                        {
                            if (grupo != mn.grupo)
                            {
                                sb.AppendLine("<div class=\"sb-sidenav-menu-heading\">" + mn.grupo + "</div>");
                                grupo = mn.grupo;
                            }

                            sb.AppendLine("<a class=\"nav-link collapsed\" href=\"#\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapse" + mn.DsMenu + "\" aria-expanded=\"false\" aria-controls=\"collapse" + mn.DsMenu + "\">");
                            sb.AppendLine("<div class=\"sb-nav-link-icon\"><i class=\"fas fa-columns\"></i></div>");
                            sb.AppendLine(mn.DsMenu);
                            sb.AppendLine("<div class=\"sb-sidenav-collapse-arrow\"><i class=\"fas fa-angle-down\"></i></div>");
                            sb.AppendLine("</a>");
                            sb.AppendLine("<div class=\"collapse\" id=\"collapse" + mn.DsMenu + "\" aria-labelledby=\"headingOne\" data-bs-parent=\"#sidenavAccordion\">");
                            sb.AppendLine("<nav class=\"sb-sidenav-menu-nested nav\">");
                            for (int h = 0; h <= mn.TbSubMenu.Length - 1; h++)
                            {
                                if (mn.TbSubMenu[h].FlProfissional == FlProfessional && FlProfessional == true && mn.TbSubMenu[h].Flhabilitado == true)
                                {
                                    if (h % 2 == 0)
                                    {

                                        sb.AppendLine("<a class=\"nav-link\" href=\"" + mn.TbSubMenu[h].DsLink + "\">" + mn.TbSubMenu[h].DsSubMenu + "</a>");
                                    }
                                    else
                                    {
                                        sb.AppendLine("<a class=\"nav-link\" href=\"" + mn.TbSubMenu[h].DsLink + "\">" + mn.TbSubMenu[h].DsSubMenu + "</a>");
                                    }
                                }
                                else
                                {
                                    if (mn.TbSubMenu[h].Flhabilitado == true)
                                    {
                                        if (h % 2 == 0)
                                        {

                                            sb.AppendLine("<a class=\"nav-link\" href=\"" + mn.TbSubMenu[h].DsLink + "\">" + mn.TbSubMenu[h].DsSubMenu + "</a>");
                                        }
                                        else
                                        {
                                            sb.AppendLine("<a class=\"nav-link\" href=\"" + mn.TbSubMenu[h].DsLink + "\">" + mn.TbSubMenu[h].DsSubMenu + "</a>");
                                        }
                                    }
                                }
                            }
                            sb.AppendLine("</nav>");
                            sb.AppendLine("</div>");
                        }
                        else
                        {
                            if (mn.Fladministrador == flAdministrador && mn.FlHabilitado == true)
                            {
                                if (grupo != mn.grupo)
                                {
                                    sb.AppendLine("<div class=\"sb-sidenav-menu-heading\">" + mn.grupo + "</div>");
                                    grupo = mn.grupo;
                                }

                                sb.AppendLine("<a class=\"nav-link collapsed\" href=\"#\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapse" + mn.DsMenu + "\" aria-expanded=\"false\" aria-controls=\"collapse" + mn.DsMenu + "\">");
                                sb.AppendLine("<div class=\"sb-nav-link-icon\"><i class=\"fas fa-columns\"></i></div>");
                                sb.AppendLine(mn.DsMenu);
                                sb.AppendLine("<div class=\"sb-sidenav-collapse-arrow\"><i class=\"fas fa-angle-down\"></i></div>");
                                sb.AppendLine("</a>");
                                sb.AppendLine("<div class=\"collapse\" id=\"collapse" + mn.DsMenu + "\" aria-labelledby=\"headingOne\" data-bs-parent=\"#sidenavAccordion\">");
                                sb.AppendLine("<nav class=\"sb-sidenav-menu-nested nav\">");
                                for (int h = 0; h <= mn.TbSubMenu.Length - 1; h++)
                                {
                                    if (mn.TbSubMenu[h].FlProfissional == FlProfessional && FlProfessional == true && mn.TbSubMenu[h].Flhabilitado == true)
                                    {
                                        if (h % 2 == 0)
                                        {

                                            sb.AppendLine("<a class=\"nav-link\" href=\"" + mn.TbSubMenu[h].DsLink + "\">" + mn.TbSubMenu[h].DsSubMenu + "</a>");
                                        }
                                        else
                                        {
                                            sb.AppendLine("<a class=\"nav-link\" href=\"" + mn.TbSubMenu[h].DsLink + "\">" + mn.TbSubMenu[h].DsSubMenu + "</a>");
                                        }
                                    }
                                    else
                                    {
                                        if (mn.TbSubMenu[h].Flhabilitado == true)
                                        {
                                            if (h % 2 == 0)
                                            {

                                                sb.AppendLine("<a class=\"nav-link\" href=\"" + mn.TbSubMenu[h].DsLink + "\">" + mn.TbSubMenu[h].DsSubMenu + "</a>");
                                            }
                                            else
                                            {
                                                sb.AppendLine("<a class=\"nav-link\" href=\"" + mn.TbSubMenu[h].DsLink + "\">" + mn.TbSubMenu[h].DsSubMenu + "</a>");
                                            }
                                        }
                                    }
                                }
                                sb.AppendLine("</nav>");
                                sb.AppendLine("</div>");

                            }
                            else
                            {

                                if (mn.FlHabilitado == true)
                                {
                                    if (grupo != mn.grupo)
                                    {
                                        sb.AppendLine("<div class=\"sb-sidenav-menu-heading\">" + mn.grupo + "</div>");
                                        grupo = mn.grupo;
                                    }
                                    sb.AppendLine("<a class=\"nav-link collapsed\" href=\"#\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapse" + mn.DsMenu + "\" aria-expanded=\"false\" aria-controls=\"collapse" + mn.DsMenu + "\">");
                                    sb.AppendLine("<div class=\"sb-nav-link-icon\"><i class=\"fas fa-columns\"></i></div>");
                                    sb.AppendLine(mn.DsMenu);
                                    sb.AppendLine("<div class=\"sb-sidenav-collapse-arrow\"><i class=\"fas fa-angle-down\"></i></div>");
                                    sb.AppendLine("</a>");
                                    sb.AppendLine("<div class=\"collapse\" id=\"collapse" + mn.DsMenu + "\" aria-labelledby=\"headingOne\" data-bs-parent=\"#sidenavAccordion\">");
                                    sb.AppendLine("<nav class=\"sb-sidenav-menu-nested nav\">");

                                    for (int h = 0; h <= mn.TbSubMenu.Length - 1; h++)
                                    {
                                        if (mn.TbSubMenu[h].Flhabilitado == true)
                                        {
                                            if (h % 2 == 0)
                                            {
                                                sb.AppendLine("<a class=\"nav-link\" href=\"" + mn.TbSubMenu[h].DsLink + "\">" + mn.TbSubMenu[h].DsSubMenu + "</a>");
                                            }
                                            else
                                            {
                                                sb.AppendLine("<a class=\"nav-link\" href=\"" + mn.TbSubMenu[h].DsLink + "\">" + mn.TbSubMenu[h].DsSubMenu + "</a>");
                                            }
                                        }
                                    }
                                }
                            }
                            sb.AppendLine("</nav>");
                            sb.AppendLine("</div>");
                        }
                    }
                }

                // 3. Assign the generated HTML to the placeholder control
                return sb;
            }
            else
            {
                return null;
            }
        }
        public StringBuilder GenerateMenuNEW(bool FlProfessional, bool flAdministrador)
        {
            // 1. Retrieve menu items from the database
            // (Replace with your specific data access logic)
            DataTable tabela = ConsultarMenus();

            if (tabela.Rows.Count > 0)
            {
                // 2. Build the HTML structure for the menu
                StringBuilder sb = new StringBuilder();
                string grupo = "&&&&&&";

                // Iterate through menus
                for (int i = 0; i < tabela.Rows.Count; i++)
                {
                    TbMenu mn = ObterMenucomSubMenu((int)tabela.Rows[i]["id"]);

                    if (mn.TbSubMenu.Length > 0)
                    {
                        // Check if the menu item is enabled and matches the user role
                        if (mn.FlHabilitado && ((FlProfessional && mn.FlProfessional) || (flAdministrador && mn.Fladministrador)))
                        {
                            // Check if the group has changed
                            if (grupo != mn.grupo)
                            {
                                sb.AppendLine("<div class=\"sb-sidenav-menu-heading\">" + mn.grupo + "</div>");
                                grupo = mn.grupo;
                            }

                            sb.AppendLine("<a class=\"nav-link collapsed\" href=\"#\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapse" + mn.DsMenu + "\" aria-expanded=\"false\" aria-controls=\"collapse" + mn.DsMenu + "\">");
                            sb.AppendLine("<div class=\"sb-nav-link-icon\"><i class=\"fas fa-columns\"></i></div>");
                            sb.AppendLine(mn.DsMenu);
                            sb.AppendLine("<div class=\"sb-sidenav-collapse-arrow\"><i class=\"fas fa-angle-down\"></i></div>");
                            sb.AppendLine("</a>");
                            sb.AppendLine("<div class=\"collapse\" id=\"collapse" + mn.DsMenu + "\" aria-labelledby=\"headingOne\" data-bs-parent=\"#sidenavAccordion\">");
                            sb.AppendLine("<nav class=\"sb-sidenav-menu-nested nav\">");

                            // Iterate through submenu items
                            foreach (var submenu in mn.TbSubMenu)
                            {
                                // Check if submenu item is enabled and matches the user role
                                if (submenu.Flhabilitado && ((FlProfessional && submenu.FlProfissional) || (flAdministrador && submenu.Fladministrador)))
                                {
                                    sb.AppendLine("<a class=\"nav-link\" href=\"" + submenu.DsLink + "\">" + submenu.DsSubMenu + "</a>");
                                }
                            }

                            sb.AppendLine("</nav>");
                            sb.AppendLine("</div>");
                        }
                    }
                }

                // 3. Assign the generated HTML to the placeholder control
                return sb;
            }
            else
            {
                return null;
            }
        }
        public StringBuilder GenerateMenu(bool FlProfessional, bool flAdministrador)
        {
            // 1. Retrieve menu items from the database
            // (Replace with your specific data access logic)
            DataTable tabela = ConsultarMenus();

            if (tabela.Rows.Count > 0)
            {
                // 2. Build the HTML structure for the menu
                StringBuilder sb = new StringBuilder();
                string grupo = "&&&&&&";

                // Iterate through menus
                for (int i = 0; i < tabela.Rows.Count; i++)
                {
                    TbMenu mn = ObterMenucomSubMenu((int)tabela.Rows[i]["id"]);

                    // Check if the menu item is enabled and matches the user role
                    if (mn.FlHabilitado && flAdministrador)
                    {
                        // Check if the group has changed
                        if (grupo != mn.grupo)
                        {
                            sb.AppendLine("<div class=\"sb-sidenav-menu-heading\">" + mn.grupo + "</div>");
                            grupo = mn.grupo;
                        }

                        sb.AppendLine("<a class=\"nav-link collapsed\" href=\"#collapse" + mn.DsMenu + "\" data-bs-toggle=\"collapse\" aria-expanded=\"false\">");
                        sb.AppendLine("<div class=\"sb-nav-link-icon\"><i class=\"fas fa-columns\"></i></div>");
                        sb.AppendLine(mn.DsMenu);
                        sb.AppendLine("<div class=\"sb-sidenav-collapse-arrow\"><i class=\"fas fa-angle-down\"></i></div>");
                        sb.AppendLine("</a>");
                        sb.AppendLine("<div class=\"collapse\" id=\"collapse" + mn.DsMenu + "\">");
                        sb.AppendLine("<nav class=\"sb-sidenav-menu-nested nav\">");

                        // Iterate through submenu items
                        foreach (var submenu in mn.TbSubMenu)
                        {
                            // Check if submenu item is enabled and matches the user role
                            if (submenu.Flhabilitado && flAdministrador && submenu.Fladministrador)
                            {
                                sb.AppendLine("<a class=\"nav-link\" href=\"" + submenu.DsLink + "\">" + submenu.DsSubMenu + "</a>");
                            }
                        }

                        sb.AppendLine("</nav>");
                        sb.AppendLine("</div>");
                    }
                    else
                    {
                        // Handle non-administrator, non-professional menus
                        if (mn.FlHabilitado && !mn.Fladministrador)
                        {
                            // Check if the group has changed
                            if (grupo != mn.grupo)
                            {
                                sb.AppendLine("<div class=\"sb-sidenav-menu-heading\">" + mn.grupo + "</div>");
                                grupo = mn.grupo;
                            }

                            sb.AppendLine("<a class=\"nav-link collapsed\" href=\"#collapse" + mn.DsMenu + "\" data-bs-toggle=\"collapse\" aria-expanded=\"false\">");
                            sb.AppendLine("<div class=\"sb-nav-link-icon\"><i class=\"fas fa-columns\"></i></div>");
                            sb.AppendLine(mn.DsMenu);
                            sb.AppendLine("<div class=\"sb-sidenav-collapse-arrow\"><i class=\"fas fa-angle-down\"></i></div>");
                            sb.AppendLine("</a>");
                            sb.AppendLine("<div class=\"collapse\" id=\"collapse" + mn.DsMenu + "\">");
                            sb.AppendLine("<nav class=\"sb-sidenav-menu-nested nav\">");

                            // Iterate through submenu items
                            foreach (var submenu in mn.TbSubMenu)
                            {
                                // Check if submenu item is enabled
                                if (submenu.Flhabilitado && !submenu.Fladministrador)
                                {
                                    sb.AppendLine("<a class=\"nav-link\" href=\"" + submenu.DsLink + "\">" + submenu.DsSubMenu + "</a>");
                                }
                            }

                            sb.AppendLine("</nav>");
                            sb.AppendLine("</div>");
                        }
                    }
                }

                // 3. Assign the generated HTML to the placeholder control
                return sb;
            }
            else
            {
                return null;
            }
        }

    }
}
