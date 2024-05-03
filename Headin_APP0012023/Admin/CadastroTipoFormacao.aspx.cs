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
    public partial class CadastroTipoFormacao : System.Web.UI.Page
    {
        private void CarregarDados()
        {
            DataTable dataTable = new TipoFormacaoBL().ConsultarTiposFormacoes();
            GridViewTipoFormacao.DataSource = dataTable;
            GridViewTipoFormacao.DataBind();
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
            GridViewTipoFormacao.DataSource = dt;
            GridViewTipoFormacao.DataBind();
        }

        // Método para aplicar filtro aos dados (exemplo, substitua com sua lógica real)
        private DataTable AplicarFiltro(string filtro)
        {
            // Implemente a lógica para filtrar dados aqui
            // Exemplo: Filtrar por nome do país
            DataTable dt = new TipoFormacaoBL().ConsultarTiposFormacoes();
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


        protected void GridViewTipoFormacao_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewTipoFormacao.EditIndex = e.NewEditIndex;
            CarregarDados();
        }

        protected void GridViewTipoFormacao_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTipoFormacao.EditIndex = -1;
            CarregarDados();
        }

        protected void GridViewTipoFormacao_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AtualizarRegistroGrid(e.RowIndex);
        }

        protected void GridViewTipoFormacao_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ExcluirRegistroGrid(e.RowIndex);
        }

        private void InserirRegistro()
        {
            try
            {
                if (new TipoFormacaoBL().InserirTipoFormacao(txtdsTipo.Text, int.Parse(txtnrNivel.Text)) > 0)
                {
                    txtdsTipo.Text = "";
                    txtnrNivel.Text = "0";
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
                TextBox txtdsTipo = GridViewTipoFormacao.Rows[rowIndex].FindControl("txtdsTipo") as TextBox;
                TextBox txtnrNivel = GridViewTipoFormacao.Rows[rowIndex].FindControl("txtnrNivel") as TextBox;


                int id = Convert.ToInt32(GridViewTipoFormacao.DataKeys[rowIndex].Value);
                TipoFormacaoBL tipoformacaoBL = new TipoFormacaoBL();

                if (tipoformacaoBL.AtualizarTiposFormacoes( id, txtdsTipo.Text, int.Parse(txtnrNivel.Text)) > 0)
                {
                    // Atualização bem-sucedida
                    GridViewTipoFormacao.EditIndex = -1;
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
                int id = Convert.ToInt32(GridViewTipoFormacao.DataKeys[rowIndex].Value);
                TipoFormacaoBL tipoFormacaoBL = new TipoFormacaoBL();

                if (tipoFormacaoBL.ExcluirTipoFormacao(id) > 0)
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
            txtnrNivel.Text = "0";
            CarregarDados();
        }
    }
}