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

namespace Headin_APP0012023
{
    public partial class CadastroTipoMensalidade : System.Web.UI.Page
    {
        private void CarregarDados()
        {
            DataTable dataTable = new TipoMensalidadeBL().ConsultarTiposMensalidades();
            GridViewTipoMensalidade.DataSource = dataTable;
            GridViewTipoMensalidade.DataBind();
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
            GridViewTipoMensalidade.DataSource = dt;
            GridViewTipoMensalidade.DataBind();
        }

        // Método para aplicar filtro aos dados (exemplo, substitua com sua lógica real)
        private DataTable AplicarFiltro(string filtro)
        {
            // Implemente a lógica para filtrar dados aqui
            // Exemplo: Filtrar por nome do país
            DataTable dt = new TipoMensalidadeBL().ConsultarTiposMensalidades();
            DataView dv = new DataView(dt);
            dv.RowFilter = $"dsTipo LIKE '%{filtro}%'";
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


        protected void GridViewTipoMensalidade_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewTipoMensalidade.EditIndex = e.NewEditIndex;
            CarregarDados();
        }

        protected void GridViewTipoMensalidade_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTipoMensalidade.EditIndex = -1;
            CarregarDados();
        }

        protected void GridViewTipoMensalidade_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AtualizarRegistroGrid(e.RowIndex);
        }

        protected void GridViewTipoMensalidade_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ExcluirRegistroGrid(e.RowIndex);
        }

        private void InserirRegistro()
        {
            try
            {
                if (new TipoMensalidadeBL().InserirTipoMensalidade(txtdsTipo.Text, int.Parse(txtdiasFaturacao.Text),chkflHabilitado.Checked) > 0)
                {
                    txtdsTipo.Text = "";
                    txtdiasFaturacao.Text = "0";
                    chkflHabilitado.Checked= false;
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
                TextBox txtdsTipo = GridViewTipoMensalidade.Rows[rowIndex].FindControl("txtdsTipo") as TextBox;
                TextBox txtdiasFaturacao = GridViewTipoMensalidade.Rows[rowIndex].FindControl("txtdiasFaturacao") as TextBox;
                CheckBox chkflHabilitado = GridViewTipoMensalidade.Rows[rowIndex].FindControl("chkflHabilitado") as CheckBox;

                int id = Convert.ToInt32(GridViewTipoMensalidade.DataKeys[rowIndex].Value);
                TipoMensalidadeBL TipoMensalidadeBL = new TipoMensalidadeBL();

                if (TipoMensalidadeBL.AtualizarTipoMensalidade( id, txtdsTipo.Text, int.Parse(txtdiasFaturacao.Text),chkflHabilitado.Checked) > 0)
                {
                    // Atualização bem-sucedida
                    GridViewTipoMensalidade.EditIndex = -1;
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
                int id = Convert.ToInt32(GridViewTipoMensalidade.DataKeys[rowIndex].Value);
                TipoMensalidadeBL TipoMensalidadeBL = new TipoMensalidadeBL();

                if (TipoMensalidadeBL.ExcluirTipoMensalidade(id) > 0)
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
            txtdsTipo.Text = "";
            txtdiasFaturacao.Text = "0";
            chkflHabilitado.Checked = false;
            CarregarDados();
        }
    }
}