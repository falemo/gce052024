﻿<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Geral.Master" AutoEventWireup="true" CodeBehind="PersonRegistration.aspx.cs" Inherits="Headin_APP0012023.PersonRegistration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Person Registration</title>
    <link href="css/styles.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/releases/v6.3.0/js/all.js" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
	<!-- Google tag (gtag.js) -->
	<script async src="https://www.googletagmanager.com/gtag/js?id=G-RNRQK0QQB6"></script>
	<script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-RNRQK0QQB6');
	</script>
</head>
<body>
  <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="card shadow-lg border-0 rounded-lg mt-5">
                    <div class="card-header"><h3 class="text-center font-weight-light my-4">Cadastro</h3></div>
                    <div class="card-body">
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Text="" placeholder="Nome Completo" />
                                <label for="txtName">Nome Completo</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" placeholder="Data de Nascimento"></asp:TextBox>
                                <label for="txtBirthDate">Data de Nascimento</label>
                            </div>
                            <script>
                                $(function () {
                                    $("#<%= txtBirthDate.ClientID %>").datepicker({
                                    dateFormat: 'dd/mm/yy',
                                    dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
                                    dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb'],
                                    monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                                    monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                                    changeMonth: true,
                                    changeYear: true
                                });
                            });
                            </script>
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-select" AutoPostBack="false">
                                    <asp:ListItem Text="Prefiro Não informar" Value="N" />
                                    <asp:ListItem Text="Masculino" Value="M" />
                                    <asp:ListItem Text="Feminino" Value="F" />
                                    </asp:DropDownList>
                                <label for="ddlEstado">Genero (Opcional)</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Text="" placeholder="Endereço" />
                                <label for="txtAddress">Endereço</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Text="" placeholder="Email" />
                                <label for="txtEmail">Email</label>
                            </div>
                            <div class="mt-2">
                                    <p class="mt-2 text-blue font-weight-bold">Atenção: Este e-mail será a associação (Chave) entre você e os modulos do Sistemas.</p>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Text="" placeholder="Telefone" />
                                <label for="txtPhone">Telefone</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged">
                                    <asp:ListItem Text="Selecione seu Pais" Value="" />
                                    </asp:DropDownList>
                                <label for="ddlPais">Pais</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                                    <asp:ListItem Text="Selecione seu Estado" Value="" />
                                    </asp:DropDownList>
                                <label for="ddlEstado">Estado</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlCidade" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlCidade_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label for="ddlCidade">Cidade</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:DropDownList ID="ddlTipoPessoa" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                                <label for="ddlTipoPessoa">Tipo de Pessoa</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox ID="txtpwd" runat="server" CssClass="form-control" TextMode="Password" placeholder="Senha" />
                                <label for="txtpwd">Senha</label>
                            </div>
                            <div class="mt-2">
                                    <p class="mt-2 text-blue font-weight-bold">Marcar a opção "Demolay\Maçom" habilita o seu perfil para ter acesso a opções associado aos trabalhos da Ordem na plataforma.</p>
                            </div>

                            <div class="form-check mb-3">
                                <asp:CheckBox ID="chkProfessional" runat="server" CssClass="form-check-input" />
                                <label class="form-check-label" for="chkProfessional">Demolay\Maçom</label>
                            </div>
                            <div class="separador"></div>

                            <div class="politica-privacidade">
                                <h3>Política de Privacidade</h3>
                                <p>Ao se cadastrar em nosso site e fornecer seus dados pessoais, você concorda com o uso desses dados pelo nosso sistema para os fins específicos descritos em nossa política de privacidade. Esses fins incluem, mas não estão limitados a:</p>
                                <ul>
                                    <li>Processar seu cadastro e fornecer acesso aos recursos e serviços do site.</li>
                                    <li>Comunicar-se com você sobre sua conta, atualizações de serviços e informações relevantes.</li>
                                    <li>Personalizar sua experiência no site e fornecer conteúdo e recursos relevantes.</li>
                                    <li>Cumprir com obrigações legais e regulamentações aplicáveis.</li>
                                </ul>
                                <p>Ao concordar com esta declaração, você reconhece que leu e compreendeu nossa política de privacidade e concorda com as práticas de coleta, armazenamento e uso de dados descritas nesse documento.</p>
                            </div>
                            <div class="d-flex justify-content-center">
                                <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnRegister_Click" />
                            </div>
                            <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                <asp:Label ID="lblMessage" runat="server" CssClass="text-center font-weight-light my-4" Text="" />
                            </div>
                            <div class="d-flex justify-content-center">
                                <asp:Button ID="btnBackToLogin" runat="server" CssClass="btn btn-secondary" Text="Retornar para Login" OnClick="btnBackToLogin_Click" />
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="Scripts/scripts.js"></script>
    </body>
</html>
</asp:Content>
