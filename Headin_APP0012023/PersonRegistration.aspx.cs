using BusinessLayer;
using BusinessLogic;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Headin_APP0012023
{ 
    public partial class PersonRegistration : Page
    {
        protected void GerarComboPais()
        {
            try
            {
                ddlPais.Items.Clear();
                ddlPais.DataSource = new PaisBL().ConsultarPaises();
                ddlPais.DataTextField = "nmPais";
                ddlPais.DataValueField = "Id";
                ddlPais.DataBind();
                ddlPais.Items.Insert(0, new ListItem("-- Selecione --", ""));
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void GerarComboTipoPessoa()
        {
            try
            {
                ddlTipoPessoa.Items.Clear();
                ddlTipoPessoa.DataSource = new TipoPessoalBL().ConsultarTipoPessoa(true);
                ddlTipoPessoa.DataTextField = "dsTipo";
                ddlTipoPessoa.DataValueField = "Id";
                ddlTipoPessoa.DataBind();
                ddlTipoPessoa.Items.Insert(0, new ListItem("-- Selecione --", ""));
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        protected void GerarComboEstado(int idPais)
        {
            try {
            
                ddlEstado.Items.Clear();
                ddlEstado.DataSource = new EstadoBL().ConsultarEstadosPorPais(idPais);
                ddlEstado.DataTextField = "nmEstado";
                ddlEstado.DataValueField = "Id";
                ddlEstado.DataBind();
                ddlEstado.Items.Insert(0, new ListItem("-- Selecione --", ""));
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }

        protected void GerarComboCidade(int idEstado)
        {
            try
            {
                ddlCidade.Items.Clear();
                ddlCidade.DataSource = new CidadeBL().ConsultarCidadesPorEstado(idEstado);
                ddlCidade.DataTextField = "nmCidade";
                ddlCidade.DataValueField = "Id";
                ddlCidade.DataBind();
                ddlCidade.Items.Insert(0, new ListItem("-- Selecione --", ""));
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }

        protected void LimparFormulario()
        {
            try
            {
                txtName.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
                txtpwd.Text = "";
                txtPhone.Text = "";
                txtBirthDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                chkProfessional.Checked = false;

                GerarComboPais();
                ddlPais_SelectedIndexChanged(null, null);
                GerarComboTipoPessoa();

                ddlEstado.SelectedIndex = 0;
                ddlCidade.SelectedIndex = 0;
                ddlGender.SelectedIndex = 0;
                ddlTipoPessoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimparFormulario();
                //GerarComboPais();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string mensagem = "";
                if (!ToolAccessLayer.Funcoes.ValidarPassword(txtpwd.Text, out mensagem))
                {
                    lblMessage.Text = mensagem;
                }
                else
                {
                    PessoaBL pessoaBL = new PessoaBL();
                    pessoaBL.InserirPessoa(txtName.Text, DateTime.Parse(txtBirthDate.Text), ddlGender.SelectedValue, txtAddress.Text, txtEmail.Text, txtPhone.Text, int.Parse(ddlCidade.SelectedValue), 1, txtpwd.Text, DateTime.Now, chkProfessional.Checked, false, int.Parse(ddlTipoPessoa.SelectedValue));
                    lblMessage.Text = "Cadastrado realizado com sucesso! retorne e faça seu Login";
                    LimparFormulario();
                    btnBackToLogin.Focus();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
}

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Login.aspx");
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlEstado.SelectedIndex > 0)
                {
                    GerarComboCidade(int.Parse(ddlEstado.SelectedValue));
                    ddlCidade_SelectedIndexChanged(e, e);
                }
                else
                {
                    ddlCidade.Items.Clear();
                    ddlCidade.Items.Insert(0, new ListItem("-- Selecione --", ""));
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void ddlCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPais.SelectedIndex > 0)
                {
                    GerarComboEstado(int.Parse(ddlPais.SelectedValue));
                    ddlEstado_SelectedIndexChanged(e, e);
                }
                else
                {
                    ddlEstado.Items.Clear();
                    ddlEstado.Items.Insert(0, new ListItem("-- Selecione --", ""));
                }
                  
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}