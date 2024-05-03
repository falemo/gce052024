using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLogic;
using ModelLayer;

namespace Headin_APP0012023
{
    public partial class DefaultTeste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Find the lblUserName control in the Site.Master page
            Label lblUserName = (Label)Master.FindControl("lblUserName");

            // Set the label's text
            if (Context.Session["UserName"] != null)
            {

                lblUserName.Text = Context.Session["UserName"].ToString();
            }
            else
            {
                lblUserName.Text = "Usuário anônimo";
            }

            if (((Sessions)Session["pessoa"]).UserId.Fladministrador)
            {
                lblUserName.Text = lblUserName.Text + " - ADM";
            }

            if (!IsPostBack)
            {
           //     PlaceHolder sidenavPlaceholder = (PlaceHolder)Master.FindControl("sidenavPlaceholder");
            //    sidenavPlaceholder.InnerHtml = sb.ToString();  new MenuBL().GenerateMenu(((Sessions)Session["pessoa"]).UserId.FlProfessional).ToString();
            }
        }
    }
}