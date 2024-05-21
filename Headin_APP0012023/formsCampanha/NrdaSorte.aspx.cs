using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessLogic;
using ModelLayer;

namespace Headin_APP0012023
{
    public partial class NrdaSorte : System.Web.UI.Page
    {
        private void CarregarDados()
        {
            DataTable dataTable = new CampanhaBL().ConsultarCampanhas();
            GridViewCampanha.DataSource = dataTable;
            GridViewCampanha.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Label lblUserName = (Label)Master.FindControl("lblUserName");

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
                    CarregarDados();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text;
            DataTable dt = AplicarFiltro(filtro);
            GridViewCampanha.DataSource = dt;
            GridViewCampanha.DataBind();
        }

        private DataTable AplicarFiltro(string filtro)
        {
            DataTable dt = new CampanhaBL().ConsultarCampanhas();
            DataView dv = new DataView(dt);
            dv.RowFilter = $"dsPix LIKE '%{filtro}%'";
            return dv.ToTable();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            InserirRegistro();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void GridViewCampanha_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCampanha.EditIndex = e.NewEditIndex;
            CarregarDados();
        }

        protected void GridViewCampanha_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCampanha.EditIndex = -1;
            CarregarDados();
        }

        protected void GridViewCampanha_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AtualizarRegistroGrid(e.RowIndex);
        }

        protected void GridViewCampanha_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ExcluirRegistroGrid(e.RowIndex);
        }

        private void InserirRegistro()
        {
            try
            {
                if (new CampanhaBL().InserirCampanha(decimal.Parse(txtVlrCampanha.Text), DateTime.Parse(txtDtInicio.Text), DateTime.Parse(txtDtFim.Text), chkFlAtiva.Checked, txtDsPix.Text, txtDsPixInfo.Text, int.Parse(txtIdPessoa.Text), txtFilePath.Text, decimal.Parse(txtVlrMinimoSorte.Text)) > 0)
                {
                    LimparCampos();
                    lblMessage.Text = "Registro inserido com sucesso";
                }
                CarregarDados();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }

        private void AtualizarRegistroGrid(int rowIndex)
        {
            try
            {
                TextBox txtEditVlrCampanha = (TextBox)GridViewCampanha.Rows[rowIndex].FindControl("txtEditVlrCampanha");
                TextBox txtEditDtInicio = (TextBox)GridViewCampanha.Rows[rowIndex].FindControl("txtEditDtInicio");
                TextBox txtEditDtFim = (TextBox)GridViewCampanha.Rows[rowIndex].FindControl("txtEditDtFim");
                CheckBox chkEditFlAtiva = (CheckBox)GridViewCampanha.Rows[rowIndex].FindControl("chkEditFlAtiva");
                TextBox txtEditDsPix = (TextBox)GridViewCampanha.Rows[rowIndex].FindControl("txtEditDsPix");
                TextBox txtEditDsPixInfo = (TextBox)GridViewCampanha.Rows[rowIndex].FindControl("txtEditDsPixInfo");
                TextBox txtEditIdPessoa = (TextBox)GridViewCampanha.Rows[rowIndex].FindControl("txtEditIdPessoa");
                TextBox txtEditFilePath = (TextBox)GridViewCampanha.Rows[rowIndex].FindControl("txtEditFilePath");
                TextBox txtEditVlrMinimoSorte = (TextBox)GridViewCampanha.Rows[rowIndex].FindControl("txtEditVlrMinimoSorte");

                int id = Convert.ToInt32(GridViewCampanha.DataKeys[rowIndex].Value);
                CampanhaBL CampanhaBL = new CampanhaBL();

                if (CampanhaBL.AtualizarCampanha(id, decimal.Parse(txtEditVlrCampanha.Text), DateTime.Parse(txtEditDtInicio.Text), DateTime.Parse(txtEditDtFim.Text), chkEditFlAtiva.Checked, txtEditDsPix.Text, txtEditDsPixInfo.Text, int.Parse(txtEditIdPessoa.Text), txtEditFilePath.Text, decimal.Parse(txtEditVlrMinimoSorte.Text)) > 0)
                {
                    GridViewCampanha.EditIndex = -1;
                    CarregarDados();
                    lblMessage.Text = "Registro atualizado com sucesso";
                }
                else
                {
                    lblMessage.Text = "Registro não encontrado ou não atualizado";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }

        private void ExcluirRegistroGrid(int rowIndex)
        {
            try
            {
                int id = Convert.ToInt32(GridViewCampanha.DataKeys[rowIndex].Value);

                if (new CampanhaBL().ExcluirCampanha(id) > 0)
                {
                    CarregarDados();
                    lblMessage.Text = "Registro excluído com sucesso";
                }
                else
                {
                    lblMessage.Text = "Registro não encontrado ou não excluído";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }

        private void LimparCampos()
        {
            txtVlrCampanha.Text = "";
            txtDtInicio.Text = "";
            txtDtFim.Text = "";
            chkFlAtiva.Checked = false;
            txtDsPix.Text = "";
            txtDsPixInfo.Text = "";
            txtIdPessoa.Text = "";
            txtFilePath.Text = "";
            txtVlrMinimoSorte.Text = "";
        }
    }
}
