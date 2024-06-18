<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaArquivos.aspx.cs" Inherits="Headin_APP0012023.ConsultaArquivos" %>

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
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css"/>

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
        .body_events {
            padding: 20px;
        }

        .search-bar {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 20px;
        }

        .search-bar input[type=text] {
            width: 300px;
            padding: 10px;
            font-size: 16px;
        }

        .search-bar button {
            padding: 10px 20px;
            font-size: 16px;
            cursor: pointer;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        th, td {
            padding: 15px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        th {
            background-color: #f4f4f4;
        }

        .directory {
            font-weight: bold;
        }

        .directory a {
            text-decoration: none;
            color: #007bff;
        }

        .directory a:hover {
            text-decoration: underline;
        }

        .error {
            color: red;
            margin-top: 20px;
        }
    </style>
    <style>
        ul { list-style-type: none; }
        .directory { font-weight: bold; }
        pre { white-space: pre-wrap; word-wrap: break-word; }
    </style>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>ConsultaArquivos - DeMolay Sergipe</title>
</head>
<body>
<form id="form1" runat="server">
   <div class="body_events">
        <div class="mt-3">
            <h1>Lista de Documentos - Demolay Sergipe</h1>
            <asp:TextBox ID="SearchBox" runat="server" Width="300px"></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" Text="Buscar..." OnClick="SearchButton_Click" />
            <br /><br />
            <asp:Literal ID="FileListLiteral" runat="server"></asp:Literal>
            <asp:Literal ID="ErrorMessageLiteral" runat="server"></asp:Literal>
        </div>
        <br />
        <br />
    </div>
    <br />
    <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-center font-weight-light my-4" Text="" />
    </div>
    </form>



</body>
</html>
