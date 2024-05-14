<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelViewer.aspx.cs" Inherits="Headin_APP0012023.ExcelViewer" %>

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
            <asp:GridView ID="gridViewExcelData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
    </div>
    <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-center font-weight-light my-4" Text="" />
    </div>

    </form>
</body>
</html>
