<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Headin_APP0012023.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Plataforma de serviços que registra a vida das pessoas em termos de atividade física e médica e as conecta com profissionais da saúde e do fitness" />
    <meta name="author" content="Hedin Inovação e Tecnologia" />
    <title>Login - Demolay Sergipe</title>
    <link href="css/styles.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/releases/v6.3.0/js/all.js" crossorigin="anonymous"></script>
    <style>
    body {
        background: url('Images/FundoPaginaWEB.png') no-repeat center center fixed;
        background-size: cover;
        height: 100vh;
        margin: 0;
    }
    .overlay {
        background: rgba(0, 0, 0, 0.6);
        height: 100%;
        width: 100%;
        position: absolute;
        top: 0;
        left: 0;
        z-index: 1;
    }
    </style>
</head>
<body class="bg-primary">
    <div id="layoutAuthentication" class="d-flex">
        <!-- Área de Login -->
        <div id="layoutAuthentication_login" class="flex-grow-1">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-5">
                        <div class="card shadow-lg border-0 rounded-lg mt-5">
                            <div class="card-header">
                                <h3 class="text-center font-weight-light my-4">Login - Demolay Sergipe</h3>
                            </div>
                            <!-- Espaço para o logo -->
                            <div id="layoutAuthentication_logo" class="text-center">
                                <img src="Images/DemolaySergipe.png" alt="Logo" class="img-fluid" style="max-width: 150px;" />
                            </div>
                            <div class="card-body">
                                <form runat="server">
                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="inputEmail" runat="server" type="email" CssClass="form-control" Text="fabrinio.lemos@gmail.com" placeholder="name@example.com" autocomplete="username"/>
                                        <label for="inputEmail">Email\Login</label>
                                    </div>
                                    <div class="form-floating mb-3">
                                        <asp:TextBox ID="inputPassword" runat="server" type="password" CssClass="form-control" Text="Lemos1008" placeholder="Password" autocomplete="current-password"/>
                                        <label for="inputPassword">Senha\Password</label>
                                    </div>
                                    <div class="form-check mb-3">
                                      
                                    </div>
                                    <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                        <asp:Button ID="lnkForgotPassword" runat="server" CssClass="btn btn-link small" Text="Esqueceu a Senha?" OnClick="lnkForgotPassword_Click" />
                                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Entrar" OnClick="btnLogin_Click" />
                                    </div>
                                    <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                        <asp:Label ID="TextAlarme" runat="server" CssClass="text-center font-weight-light my-4" Text=""/>
                                    </div>
                                </form>


                            </div>
                            <div class="card-footer text-center py-3">
                                <div class="small">
                                    <asp:HyperLink ID="hlCreateAccount" runat="server" NavigateUrl="~/PersonRegistration.aspx">Criar nova conta? Cadastre-se!</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

   <div id="layoutAuthentication_footer" runat="server">
            <footer class="py-4 bg-light mt-auto">
                <div class="container-fluid px-4">
                    <div class="d-flex align-items-center justify-content-between small">
                        <div class="text-muted">Copyright &copy; Grande Conselho Demolay Sergipe 2024</div>
                        <div>
                            <asp:HyperLink ID="hlPrivacyPolicy" runat="server" NavigateUrl="#">Privacy Policy</asp:HyperLink>
                            &middot;
                            <asp:HyperLink ID="hlTermsAndConditions" runat="server" NavigateUrl="#">Terms &amp; Conditions</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </div>
                      
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="Scripts/scripts.js"></script>
</body>
</html>
