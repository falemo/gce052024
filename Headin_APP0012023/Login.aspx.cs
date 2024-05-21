using BusinessLogic;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using static System.Collections.Specialized.BitVector32;
using BusinessLayer;
using System.Web.Security;
using ToolAccessLayer;

namespace Headin_APP0012023
{
    public partial class Login : System.Web.UI.Page
    {
        private Sessions session = new Sessions();
        string sessionId = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["sessionId"] != null)
                    {
                        sessionId = Session["sessionId"].ToString();

                        SessionBL ssBL = new SessionBL();
                        Session session = ssBL.ObterSessionSessionID(sessionId);

                        int userId = session.UserId;
                        int Id = session.Id;

                        DateTime agora = DateTime.Now;
                        TimeSpan diferenca = agora - session.UpdatedAt;

                        // Check if the user is logged in.
                        if (userId > 0 && diferenca.TotalMinutes < 30)
                        {
                            Sessions ss = new Sessions
                            {
                                UserId = new PessoaBL().ObterPessoa(userId),
                                StartTime = DateTime.Now,
                                EndTime = DateTime.Now.AddMinutes(30)
                            };
                            new SessionBL().AtualizarSession(Id, sessionId, ss.UserId.Id, true);
                            Session["pessoa"] = ss;

                            // Verifica se o usuário já está autenticado
                            // if (vIsAuthenticated)
                            //{
                            // Redireciona para a página inicial
                            Response.Redirect("~/Default.aspx");
                            // }
                            //Response.Redirect("~/Default.aspx");
                        }
                        else
                        {
                            TextAlarme.Text = "Por favor refazer login, sua sessão anterior tinha mais de 30 minutos ativa sem movimentação.";
                            new SessionBL().ExcluirSession(Id);
                            Session.Clear();
                            // The Sessionuser is not logged in.
                            // Redirect the user to the login page.
                            // Response.Redirect("~/Login.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TextAlarme.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }

        protected void lnkForgotPassword_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Valida os campos de texto
                if (string.IsNullOrEmpty(inputEmail.Text) || string.IsNullOrEmpty(inputPassword.Text))
                {
                    // Exibe uma mensagem de erro
                    TextAlarme.Text = "Por favor, informe o e-mail e a senha.";
                    return;
                }

                PessoaBL pessoaBL = new PessoaBL();
                DataTable pessoa = pessoaBL.GetPessoaPWD(0, inputEmail.Text, inputPassword.Text);
                if (pessoa.Rows.Count > 0)
                {

                    string sessionId = SessionManagers.GenerateRandomSessionId();
                    Session.Add("sessionId", sessionId);
                    Sessions ss = new Sessions();
                    ss.UserId = new PessoaBL().ObterPessoa(int.Parse(pessoa.Rows[0]["id"].ToString()));
                    ss.StartTime = DateTime.Now;
                    ss.EndTime = DateTime.Now.AddMinutes(30);

                    // Cria um ticket de autenticação
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, ss.UserId.Id.ToString(), DateTime.Now, DateTime.Now.AddMinutes(30), false, ss.UserId.Nome);
                
                    // Criptografa o ticket
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                    #region Limpando sessões antigas do usuario por segurança.
                    SessionBL ssBL = new SessionBL();
                    Session[] sessionUserID = ssBL.ObterSession(ss.UserId.Id);
                    foreach (Session session in sessionUserID)
                    {
                        ssBL.ExcluirSession(session.Id);
                    }
                    #endregion

                    // Cria um cookie com o ticket
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    // Adiciona o cookie à resposta
                    Response.Cookies.Add(cookie);

                    new SessionBL().InserirSession(ss.UserId.Id, sessionId, true);
                    Session.Add("pessoa", ss);
                    Session.Add("UserName", ss.UserId.Nome);

                    Response.Redirect("~/Default.aspx");
                    //TextAlarme.Text = "Login efetuado com sucesso! " + pessoa.Rows[0]["nome"].ToString();
                }
                else
                {
                    TextAlarme.Text = "Login ou senha inválidos!";
                }
            }
            catch (Exception ex)
            {
                                TextAlarme.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }
    }
}