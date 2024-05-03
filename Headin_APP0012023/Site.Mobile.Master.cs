using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Headin_APP0012023
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se a sessão existe
            if (Session.Count == 0)
            {
                // Redireciona para a página de login
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}