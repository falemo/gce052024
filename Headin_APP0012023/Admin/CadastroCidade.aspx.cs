using BusinessLayer;
using BusinessLogic;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Headin_APP0012023.Admin
{
    public partial class CadastroCidade : System.Web.UI.Page
    {
        private void CarregarDados()
        {
            try
            {
                DataTable dataTable = new CidadeBL().ConsultarCidadesComboGrid();
                GridViewCidades.DataSource = dataTable;
                GridViewCidades.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }

        private void carregarComboEstado(int idPais)
        {
            try
            {
                DataTable dataTable = new EstadoBL().ConsultarEstadosPorPais(idPais);
                ddlEstado.DataTextField = "nmEstado";
                ddlEstado.DataValueField = "Id";
                ddlEstado.DataSource = dataTable;
                ddlEstado.DataBind();

                // Adicione um item em branco se desejar
                ddlEstado.Items.Insert(0, new ListItem("-- Selecione --", ""));
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }
        private void carregarComboPais()
        {
            try
            {
                DataTable dataTable = new PaisBL().ConsultarPaises();
                ddlPais.DataTextField = "nmPais";
                ddlPais.DataValueField = "Id";
                ddlPais.DataSource = dataTable;
                ddlPais.DataBind();

                // Adicione um item em branco se desejar
                ddlPais.Items.Insert(0, new ListItem("-- Selecione --", ""));
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
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
                    carregarComboPais();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }

        }
        // Evento de texto alterado no TextBox de filtro

        protected void txtFiltroCidade_TextChanged(object sender, EventArgs e)
        {
            // Implemente a lógica de filtro aqui
            string filtro = txtFiltroCidade.Text;
            DataTable dt = AplicarFiltro(filtro); // Substitua este método com sua lógica real
            GridViewCidades.DataSource = dt;
            GridViewCidades.DataBind();
        }

        // Método para aplicar filtro aos dados (exemplo, substitua com sua lógica real)
        private DataTable AplicarFiltro(string filtro)
        {
            // Implemente a lógica para filtrar dados aqui
            // Exemplo: Filtrar por nome do país
            DataTable dt = new CidadeBL().ConsultarCidades();
            DataView dv = new DataView(dt);
            dv.RowFilter = $"nmCidade LIKE '%{filtro}%'";
            return dv.ToTable();
        }

        protected void btnInserirCidade_Click(object sender, EventArgs e)
        {
            InserirRegistro();
        }

        /*   protected void btnAtualizar_Click(object sender, EventArgs e)
           {
               AtualizarRegistro();
           }*/

        protected void GridViewCidades_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewCidades.EditIndex = e.NewEditIndex;
                CarregarDados();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }


        }

        protected void GridViewCidades_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCidades.EditIndex = -1;
            CarregarDados();
        }

        protected void GridViewCidades_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AtualizarRegistroGrid(e.RowIndex);
        }

        protected void GridViewCidades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ExcluirRegistroGrid(e.RowIndex);
        }

        private void InserirRegistro()
        {
            try
            {
                if (new CidadeBL().InserirCidade(txtNomeCidade.Text, int.Parse(ddlEstado.SelectedValue)) > 0)
                {
                    txtNomeCidade.Text = "";
                    ddlEstado.SelectedIndex = -1;
                    CarregarListaEstado();
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
                // Obtenha os valores dos controles no GridView
                TextBox txtNomeCidade = GridViewCidades.Rows[rowIndex].FindControl("txtNomeCidade") as TextBox;
                DropDownList ddlEstado = GridViewCidades.Rows[rowIndex].FindControl("ddlEditEstado") as DropDownList;

                int id = Convert.ToInt32(GridViewCidades.DataKeys[rowIndex].Value);
                CidadeBL CidadeBL = new CidadeBL();
                
                if (CidadeBL.AtualizarCidade(id,txtNomeCidade.Text, int.Parse(ddlEstado.SelectedValue)) > 0)
                {
                    // Atualização bem-sucedida
                    GridViewCidades.EditIndex = -1;
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
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }

        private void ExcluirRegistroGrid(int rowIndex)
        {
            try
            {
                int id = Convert.ToInt32(GridViewCidades.DataKeys[rowIndex].Value);
                CidadeBL CidadeBL = new CidadeBL();

                if (CidadeBL.ExcluirCidade(id) > 0)
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
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
            // Implemente a lógica para excluir um registro existente
            // Use os valores do GridView

            // Após a exclusão, chame CarregarDados() para atualizar o GridView
            // CarregarDados();
        }

        protected void ddlEditEstado_Load(object sender, EventArgs e)
        {
            try
            {
                if (GridViewCidades.EditIndex >= 0)
                {
                    DropDownList ddlEditPais = (DropDownList)sender;
                    ddlEditPais.DataSource = new EstadoBL().ConsultarEstadosGrid(); // Método que retorna a lista de países
                    ddlEditPais.DataTextField = "NmEstadoG";
                    ddlEditPais.DataValueField = "Id";
                    ddlEditPais.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "";
            }
            finally
            {

            }
        }

        protected void GridViewCidades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //   if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
                //{
                //DropDownList ddlEditPais = (DropDownList)e.Row.FindControl("ddlEditPais");

                //if (ddlEditPais != null)
                //{
                // Substitua o seguinte código com a lógica real para carregar a lista de países
                // Aqui, estou apenas fornecendo um exemplo com alguns valores fictícios
                //ddlEditPais.DataSource = new PaisBL().ConsultarPaises(); // Método que retorna a lista de países
                //ddlEditPais.DataTextField = "NmPais";
                //ddlEditPais.DataValueField = "Id";
                //ddlEditPais.DataBind();
                // }
                //}
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }
        private void CarregarListaEstado()
        {
            DataTable dtEstado = new EstadoBL().ConsultarEstadosPorPais(int.Parse(ddlPais.SelectedValue)); // Método fictício para obter dados do país

            ddlEstado.DataSource = dtEstado;
            ddlEstado.DataTextField = "nmEstado"; // Substitua "NomePais" pelo campo real em seu DataTable
            ddlEstado.DataValueField = "Id";  // Substitua "IdPais" pelo campo real em seu DataTable
            ddlEstado.DataBind();

            // Adicione um item em branco se desejar
            ddlEstado.Items.Insert(0, new ListItem("-- Selecione --", ""));
        }
        private void CarregarListaPaises(DropDownList ddlpaist)
        {
            DataTable dtPais = new PaisBL().ConsultarPaises(); // Método fictício para obter dados do país

            ddlpaist.DataSource = dtPais;
            ddlpaist.DataTextField = "nmPais"; // Substitua "NomePais" pelo campo real em seu DataTable
            ddlpaist.DataValueField = "Id";  // Substitua "IdPais" pelo campo real em seu DataTable
            ddlpaist.DataBind();

            // Adicione um item em branco se desejar
            ddlpaist.Items.Insert(0, new ListItem("-- Selecione --", ""));
        }
        protected void LimparCidade_Click(object sender, EventArgs e)
        {
            txtNomeCidade.Text = "";
            ddlEstado.SelectedIndex = -1;
            CarregarDados();
            carregarComboPais();
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               carregarComboEstado(int.Parse(ddlPais.SelectedValue));
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }
    }
}