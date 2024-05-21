<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampanhaContribuicao.aspx.cs" Inherits="Headin_APP0012023.CampanhaContribuicao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0" />
	<meta name="HandheldFriendly" content="true" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0" />
	<meta name="HandheldFriendly" content="true" />
	<meta name="Author" content="DeMolay Sergipe - contato@demolaysergipe.org.br" />
	<meta name="Language" content="Portuguese" />
	<meta name="country" content="Aracaju" />
	<meta name="Robots" content="index, follow" />
	<meta name="msapplication-TileColor" content="#00a300" />
	<meta name="theme-color" content="#ffffff" />

    <script src="https://use.fontawesome.com/releases/v6.3.0/js/all.js" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/simple-datatables@7.1.2/dist/style.min.css" rel="stylesheet" />
    <link href="../css/styles.css" rel="stylesheet" />
    <script src="https://use.fontawesome.com/releases/v6.3.0/js/all.js" crossorigin="anonymous"></script>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />

	<!-- Google tag (gtag.js) -->
	<script async src="https://www.googletagmanager.com/gtag/js?id=G-RNRQK0QQB6"></script>
	<script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-RNRQK0QQB6');
    </script>

	<link rel="stylesheet" type="text/css" href="../DeMolaySergipe_files/css.css" />

	<style>
		.area_footer {
			border: none;
		}
	    </style>
	<script type="text/javascript" async="" src="../DeMolaySergipe_files/ga.js.transferir"></script>
    <style>
        .progress {
            width: 100%;
            background-color: #f2f2f2;
            border-radius: 5px;
        }

        .bar {
            width: 0%;
            height: 20px;
            background-color: #4caf50;
            border-radius: 5px;
            text-align: center;
            color: white;
        }
    </style>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>DeMolay Sergipe</title>
</head>
<body>
<form id="form1" runat="server">
   <div class="body_events">

        <!-- Área para o gráfico de progresso -->
        <!-- Estrutura de consulta -->
        <div class="mt-3">
            <h5>Informe seu E-mail ou Pix:</h5>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
        </div>
        <br />
        <br />

        <!-- Tabela para exibir dados -->
        <asp:GridView ID="GridViewPaises" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="Email">
            <Columns>
        <asp:TemplateField>
            <HeaderTemplate>Email</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Data</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblData" runat="server" Text='<%# Eval("Data") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Valor</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblValor" runat="server" Text='<%# Eval("Valor") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Situação</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblValidado" runat="server" Text='<%# Eval("Validado") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Número da Sorte</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblNumeroSorte" runat="server" Text='<%# Eval("NumeroSorte") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-center font-weight-light my-4" Text="" />
    </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="../js/scripts.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
    <script src="../assets/demo/chart-area-demo.js"></script>
    <script src="../assets/demo/chart-bar-demo.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/simple-datatables@7.1.2/dist/umd/simple-datatables.min.js" crossorigin="anonymous"></script>
    <script src="../js/datatables-simple-demo.js"></script>
    <script src="../Scripts/scripts.js"> </script>

</body>
</html>
