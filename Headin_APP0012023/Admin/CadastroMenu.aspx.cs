using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using BusinessLayer;
using ModelLayer;
using BusinessLogic;

namespace Headin_APP0012023
{
    public partial class CadastroMenu : System.Web.UI.Page
    {
        private void CarregarDados()
        {
            DataTable dataTable = new MenuBL().ConsultarMenus();
            GridViewMenu.DataSource = dataTable;
            GridViewMenu.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Atualizado 30.01.24
            try
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
                    CarregarDados();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }
        // Evento de texto alterado no TextBox de filtro

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            // Implemente a lógica de filtro aqui
            string filtro = txtFiltro.Text;
            DataTable dt = AplicarFiltro(filtro); // Substitua este método com sua lógica real
            GridViewMenu.DataSource = dt;
            GridViewMenu.DataBind();
        }

        // Método para aplicar filtro aos dados (exemplo, substitua com sua lógica real)
        private DataTable AplicarFiltro(string filtro)
        {
            // Implemente a lógica para filtrar dados aqui
            // Exemplo: Filtrar por nome do país
            DataTable dt = new MenuBL().ConsultarMenus();
            DataView dv = new DataView(dt);
            dv.RowFilter = $"dsMenu LIKE '%{filtro}%'";
            return dv.ToTable();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            InserirRegistro();
        }

     /*   protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarRegistro();
        }*/

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
    
        }


        protected void GridViewMenu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewMenu.EditIndex = e.NewEditIndex;
            CarregarDados();
        }

        protected void GridViewMenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewMenu.EditIndex = -1;
            CarregarDados();
        }

        protected void GridViewMenu_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AtualizarRegistroGrid(e.RowIndex);
        }

        protected void GridViewMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ExcluirRegistroGrid(e.RowIndex);
        }

        private void InserirRegistro()
        {
            try
            {
                if (new MenuBL().InserirMenu(txtdsMenu.Text, flProfessional.Checked, flHabilitado.Checked, int.Parse(txtnrOrdem.Text), txtgrupo.Text, fladministrador.Checked) > 0)
                {
                    txtdsMenu.Text = "";
                    flProfessional.Checked = false;
                    fladministrador.Checked = false;
                    flHabilitado.Checked = false;
                    txtnrOrdem.Text = "0";
                    txtgrupo.Text = "";

                    lblMessage.Text = "Registro inserido com sucesso";
                }
                CarregarDados();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

   /*     private void AtualizarRegistro()
        {
            try
            {
                if (new PaisBL().AtualizarPais(int.Parse(txtId.Text),txtNomePais.Text, int.Parse(txtCodPais.Text)) > 0)
                {
                    txtNomePais.Text = "";
                    txtCodPais.Text = "";
                    lblMessage.Text = "Registro atualizado com sucesso";
                }
                CarregarDados();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }*/

        private void AtualizarRegistroGrid(int rowIndex)
        {
            try
            {
                // Obtenha os valores dos controles no GridView
                TextBox txtmenu = GridViewMenu.Rows[rowIndex].FindControl("txtmenu") as TextBox;
                CheckBox chkProfessional = GridViewMenu.Rows[rowIndex].FindControl("chkProfessional") as CheckBox;
                CheckBox chkflHabilitado = GridViewMenu.Rows[rowIndex].FindControl("chkflHabilitado") as CheckBox;
                TextBox txtnrOrdem = GridViewMenu.Rows[rowIndex].FindControl("txtnrOrdem") as TextBox;
                TextBox txtgrupo = GridViewMenu.Rows[rowIndex].FindControl("txtgrupo") as TextBox;
                CheckBox chkfladministrador = GridViewMenu.Rows[rowIndex].FindControl("chkfladministrador") as CheckBox;


                int id = Convert.ToInt32(GridViewMenu.DataKeys[rowIndex].Value);
                MenuBL menuBL = new MenuBL();

                if (menuBL.AtualizarMenu(id, txtmenu.Text, chkProfessional.Checked, chkflHabilitado.Checked ,int.Parse(txtnrOrdem.Text),txtgrupo.Text,chkfladministrador.Checked) > 0)
                {
                    // Atualização bem-sucedida
                    GridViewMenu.EditIndex = -1;
                    CarregarDados();
                    lblMessage.Text = "Registro atualizado com sucesso";
                }
                else
                {
                    // Registro não encontrado ou não atualizado
                    // Adicione lógica de tratamento de erro, se necessário
                    lblMessage.Text = "Registro não encontrado ou não atualizado";
                }
            }
            catch (Exception ex)
            {
                // Trate exceções aqui, se necessário
                // Exiba uma mensagem de erro, registre em log, etc.
                lblMessage.Text = ex.Message;
            }
        }

        private void ExcluirRegistroGrid(int rowIndex)
        {
            try
            {
                int id = Convert.ToInt32(GridViewMenu.DataKeys[rowIndex].Value);
                MenuBL menuBL = new MenuBL();

                if (menuBL.ExcluirMenu(id) > 0)
                {
                    // Exclusão bem-sucedida
                    CarregarDados();
                    lblMessage.Text = "Registro excluído com sucesso";
                }
                else
                {
                    // Registro não encontrado ou não excluído
                    // Adicione lógica de tratamento de erro, se necessário
                    lblMessage.Text = "Registro não encontrado ou não excluído";
                }
            }
            catch (Exception ex)
            {
                // Trate exceções aqui, se necessário
                // Exiba uma mensagem de erro, registre em log, etc.
                lblMessage.Text = ex.Message;
            }
            // Implemente a lógica para excluir um registro existente
            // Use os valores do GridView

            // Após a exclusão, chame CarregarDados() para atualizar o GridView
            // CarregarDados();
        }

        protected void Limpar_Click(object sender, EventArgs e)
        {
            txtdsMenu.Text = "";
            flProfessional.Checked= false;
            fladministrador.Checked = false;        
            flHabilitado.Checked = false;
            txtnrOrdem.Text = "0";
            txtgrupo.Text = "";
            CarregarDados();
        }
    }
}