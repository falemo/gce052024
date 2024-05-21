<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampanhaDemolaySE.aspx.cs" Inherits="Headin_APP0012023.CampanhaDemolaySE" %>

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
        <!-- Área para texto explicativo -->
		<div class="default_area">
						<div class="sharethis-inline-share-buttons"></div>
						<div class="default_left">
							<div class="default_text">
								Participe da nossa campanha para financiar as atividades da Ordem Demolay no estado de Sergipe. Sem cobrança de taxas mensais, todas as iniciativas são realizadas com esforço e dedicação, muitas vezes com recursos limitados. Com transparência total, 
								buscamos financiamento para os próximos dois anos, garantindo o funcionamento das atividades. Ajude-nos a alcançar esse objetivo e acompanhe cada passo do processo.<br />
								<br />
								<i><b>Quem contribuir, pode ser contemplado!</b> além 
                                
&nbsp;de ajudar, também pode participar de 4 Sorteios para ganhar também!</i>
								<i>a cada
                                <asp:Label ID="lblVlrCupom" runat="server" Text="Label"></asp:Label>
&nbsp;acumulado e registrado será gerado um cupom para participação. </i>
								<br />
								<br />
								<i><b>Mais Detalhes</b>: acessar abaixo a página completa que explica a campanha e também o sorteio de prémios para quem participar desta campanhã</i>
                                <br />
								<br />
                                Após doação do valor, carregue seu comprovante e valor doado em nosso formulário <a href="https://forms.gle/q8582WAV37SCP8DVA" target="_blank">aqui</a>.  
								<br />
								<br />
							</div>
						</div>
						<div class="sharethis-inline-share-buttons"></div>
						<div class="clear_line"></div>
		</div>
        <!-- Área para o gráfico de progresso -->
        <div>
            <h2>Campanha de Financiamento - Progresso</h2>
            <asp:Label ID="lblProgress" runat="server" Text="" CssClass="body_events"></asp:Label>
            <br />
            <asp:Chart ID="ChartMeta" runat="server"  Width="600" Height="300" >
                <Series>
                    <asp:Series Name="Meta" ChartType="StackedBar" />
                    <asp:Series Name="Acumulado" ChartType="StackedBar" />
                    <asp:Series Name="Porcentagem" ChartType="StackedBar" YAxisType="Secondary" />
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" />
                </ChartAreas>
                <Legends>
                    <asp:Legend Name="Default" Docking="Bottom" />
                </Legends>
            </asp:Chart>
        </div>
        <br />
    	    <p><strong>Os dados da campanha não são atualizados online é realizado 1 vez (uma vez) ao día.</strong></p>
        <h2>Faça já seu PIX</h2>
        <img src="../Images/CampanhaDemolaySergipe.jpg" alt="Campanha DemolaySergipe" style="height: 600px; margin: 7px; vertical-align: middle;" />

    </div>
    <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-center font-weight-light my-4" Text="" />
    </div>

    </form>
</body>
</html>
