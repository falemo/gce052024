using BusinessLogic;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToolAccessLayer;

namespace Headin_APP0012023
{
    public partial class SiteMaster : MasterPage
    {
        // private Label lblUserName;
        
         protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se a sessão existe
            if (Session.Count == 0)
            {
                // Redireciona para a página de login
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Session["pessoa"] != null)
                {
                    Literal1.Text = new MenuBL().GenerateMenu(((Sessions)Session["pessoa"]).UserId.FlProfessional, ((Sessions)Session["pessoa"]).UserId.Fladministrador).ToString();
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Limpa a sessão
            Session.Clear();
            Session.Abandon();

            // Redireciona para a página de login
            Response.Redirect("~/Login.aspx");
        }

        private void InitializeComponent()
        {
            //this.lblUserName = new Label();
            
        }
    }
}