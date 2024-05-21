using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;


namespace Headin_APP0012023
{
    public partial class CampanhaDemolaySE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    AtualizarProgressoMeta();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

 /*       protected void AtualizarProgressoMeta()
        {
            try
            {
                double totalValorAtual = 0;
                double progressoPercentual = 0;
                double maxValorMeta = 0;
                
                // Consultar a campanha
                DataTable TabelaMaxValoreta = new CampanhaGoogleBL().ConsultarCampanhas("17SQPXA_bOuvlkZENGeCntBytAcBXobJFtivto8cbq3o", "Campanha!A1:F20");
                DataTable TabelatotalValorAtual = new CampanhaGoogleBL().ConsultarCampanhas("17SQPXA_bOuvlkZENGeCntBytAcBXobJFtivto8cbq3o", "Acompanhamento!A1:D301000");

                if (TabelaMaxValoreta.Rows.Count > 0)
                {
                    maxValorMeta = Convert.ToDouble(TabelaMaxValoreta.Rows[0]["VlrCampanha"]);
                    lblVlrCupom.Text = Convert.ToDouble(TabelaMaxValoreta.Rows[0]["VlrMinimoSorte"]).ToString("C2");
                }

                for (int i = 0; i < TabelatotalValorAtual.Rows.Count; i++)
                {
                    totalValorAtual += Convert.ToDouble(TabelatotalValorAtual.Rows[i]["Valor"]);
                }

                progressoPercentual = (totalValorAtual / maxValorMeta) * 100;


                // Atualizar o texto do progresso na página
                lblProgress.Text = $"Progresso: {totalValorAtual.ToString("C2")} / {maxValorMeta.ToString("C2")}";

                // Define os valores no gráfico
                ChartMeta.Series["Meta"].Points.AddY(maxValorMeta);
                ChartMeta.Series["Acumulado"].Points.AddY(totalValorAtual);
                ChartMeta.Series["Porcentagem"].Points.AddY(progressoPercentual);

                // Configura as legendas
                ChartMeta.Series["Meta"].LegendText = "Meta";
                //ChartMeta.Series["Acumulado"].LegendText = "Acumulado";
                ChartMeta.Series["Porcentagem"].LegendText = "Porcentagem (%)";

                // Formata a série de porcentagem para mostrar apenas duas casas decimais
                ChartMeta.Series["Meta"].LabelFormat = "R$ 0.00";
                //ChartMeta.Series["Acumulado"].LabelFormat = "R$ 0.##";
                ChartMeta.Series["Porcentagem"].LabelFormat = "0.##";


                // Mostra os valores nas barras
                ChartMeta.Series["Meta"].IsValueShownAsLabel = true;
                //ChartMeta.Series["Acumulado"].IsValueShownAsLabel = false;
                ChartMeta.Series["Porcentagem"].IsValueShownAsLabel = true;

                // Exemplo de configuração manual dos intervalos do eixo Y
                ChartMeta.ChartAreas["ChartArea1"].AxisY.Minimum = 0;  // Valor mínimo do eixo Y
                ChartMeta.ChartAreas["ChartArea1"].AxisY.Maximum = maxValorMeta;  // Valor máximo do eixo Y

                ChartMeta.ChartAreas["ChartArea1"].AxisY2.Minimum = 0;  // Valor mínimo do eixo Y
                ChartMeta.ChartAreas["ChartArea1"].AxisY2.Maximum = 100;  // Valor máximo do eixo Y

                // Definir cores diferentes para as séries
                ChartMeta.Series["Meta"].Color = Color.Blue;
                //ChartMeta.Series["ValorAcumulado"].Color = Color.Blue;
                ChartMeta.Series["Porcentagem"].Color = Color.DarkRed;

                // Definir a cor do texto dos valores das séries
                ChartMeta.Series["Meta"].LabelForeColor = Color.White;
                ChartMeta.Series["Porcentagem"].LabelForeColor = Color.White;

                // Definir o tamanho da fonte dos valores das séries
                ChartMeta.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font("Arial", 16); // Define o tamanho da fonte para 12pt
                ChartMeta.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Font = new Font("Arial", 16); // Define o tamanho da fonte para 12pt

                // Ajusta o tamanho da fonte dos valores das séries
                ChartMeta.Series["Meta"].Font = new Font("Arial", 16); // Define o tamanho da fonte para 12pt
                ChartMeta.Series["Porcentagem"].Font = new Font("Arial", 16); // Define o tamanho da fonte para 12pt

                ChartMeta.ChartAreas["ChartArea1"].AxisY.IsStartedFromZero = false;

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }*/
        protected void AtualizarProgressoMeta()
        {
            try
            {
                double totalValorAtual = 0;
                double progressoPercentual = 0;
                double maxValorMeta = 0;
                int totalparticipantes = 0;
                lblVlrCupom.Text = "R$ 0,00";

                string spreadsheetId = "17SQPXA_bOuvlkZENGeCntBytAcBXobJFtivto8cbq3o";
                // Substitua pelo intervalo desejado

                CampanhaGoogleBL sheetsService = new CampanhaGoogleBL();
                DataTable tabelaMaxValor = sheetsService.ConsultarCampanhas(spreadsheetId, "Campanha!A1:F20");
                DataTable tabelaValorAtual = sheetsService.ConsultarCampanhas(spreadsheetId, "Acompanhamento!A1:D301000");
                //                DataTable tabelaParticipantes = sheetsService.ConsultarCampanhas(spreadsheetId, "Avanco_Geracao!A1:G81000");

                if (tabelaMaxValor.Rows.Count > 0)
                {
                    maxValorMeta = Convert.ToDouble(tabelaMaxValor.Rows[0]["VlrCampanha"]);
                    lblVlrCupom.Text = Convert.ToDouble(tabelaMaxValor.Rows[0]["VlrMinimoSorte"]).ToString("C2");
                }

                foreach (DataRow row in tabelaValorAtual.Rows)
                {
                    totalValorAtual += Convert.ToDouble(row["Valor"]);
                    totalparticipantes += Convert.ToInt32(row["Quantidade"]);
                }

                progressoPercentual = (totalValorAtual / maxValorMeta) * 100;

                // Atualizar o texto do progresso na página
                lblProgress.Text = $"Progresso: {totalValorAtual.ToString("C2")} / {maxValorMeta.ToString("C2")}";

                // Define os valores no gráfico
                ChartMeta.Series["Meta"].Points.AddY(maxValorMeta);
                ChartMeta.Series["Acumulado"].Points.AddY(totalValorAtual);
                ChartMeta.Series["Porcentagem"].Points.AddY(progressoPercentual);

                // Configura as legendas
                ChartMeta.Series["Meta"].LegendText = "Meta";
                //ChartMeta.Series["Acumulado"].LegendText = "Acumulado";
                ChartMeta.Series["Porcentagem"].LegendText = "Porcentagem (%)";

                // Formata a série de porcentagem para mostrar apenas duas casas decimais
                ChartMeta.Series["Meta"].LabelFormat = "R$ 0.00";
                //ChartMeta.Series["Acumulado"].LabelFormat = "R$ 0.##";
                ChartMeta.Series["Porcentagem"].LabelFormat = "0.##";


                // Mostra os valores nas barras
                ChartMeta.Series["Meta"].IsValueShownAsLabel = true;
                //ChartMeta.Series["Acumulado"].IsValueShownAsLabel = false;
                ChartMeta.Series["Porcentagem"].IsValueShownAsLabel = true;

                // Exemplo de configuração manual dos intervalos do eixo Y
                ChartMeta.ChartAreas["ChartArea1"].AxisY.Minimum = 0;  // Valor mínimo do eixo Y
                ChartMeta.ChartAreas["ChartArea1"].AxisY.Maximum = maxValorMeta;  // Valor máximo do eixo Y

                ChartMeta.ChartAreas["ChartArea1"].AxisY2.Minimum = 0;  // Valor mínimo do eixo Y
                ChartMeta.ChartAreas["ChartArea1"].AxisY2.Maximum = 100;  // Valor máximo do eixo Y

                // Definir cores diferentes para as séries
                ChartMeta.Series["Meta"].Color = Color.Blue;
                //ChartMeta.Series["ValorAcumulado"].Color = Color.Blue;
                ChartMeta.Series["Porcentagem"].Color = Color.DarkRed;

                // Definir a cor do texto dos valores das séries
                ChartMeta.Series["Meta"].LabelForeColor = Color.White;
                ChartMeta.Series["Porcentagem"].LabelForeColor = Color.White;

                // Definir o tamanho da fonte dos valores das séries
                ChartMeta.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font("Arial", 16); // Define o tamanho da fonte para 12pt
                ChartMeta.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Font = new Font("Arial", 16); // Define o tamanho da fonte para 12pt

                // Ajusta o tamanho da fonte dos valores das séries
                ChartMeta.Series["Meta"].Font = new Font("Arial", 16); // Define o tamanho da fonte para 12pt
                ChartMeta.Series["Porcentagem"].Font = new Font("Arial", 16); // Define o tamanho da fonte para 12pt

                ChartMeta.ChartAreas["ChartArea1"].AxisY.IsStartedFromZero = false;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }
    }
}