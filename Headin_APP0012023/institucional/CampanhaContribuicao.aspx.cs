using BusinessLayer;
using Google.Apis.Sheets.v4;
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
    public partial class CampanhaContribuicao : System.Web.UI.Page
    {
        private void CarregarDados(string filtro)
        {
            string spreadsheetId = "17SQPXA_bOuvlkZENGeCntBytAcBXobJFtivto8cbq3o";
            DataTable dataTable = new CampanhaGoogleBL().ConsultarCampanhas(spreadsheetId, "Avanco_Geracao!A1:G81000");
            GridViewPaises.DataSource = dataTable;
            GridViewPaises.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "- Rastreio: " + ex.Source + " " + ex.StackTrace + "- Rastreio: " + ex.Source + " " + ex.StackTrace;
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            // Implemente a lógica de filtro aqui
            string filtro = txtFiltro.Text;
            DataTable dt = AplicarFiltro(filtro); // Substitua este método com sua lógica real
            GridViewPaises.DataSource = dt;
            GridViewPaises.DataBind();
        }

                // Método para aplicar filtro aos dados (exemplo, substitua com sua lógica real)
        private DataTable AplicarFiltro(string filtro)
        {
            // Implemente a lógica para filtrar dados aqui
            // Exemplo: Filtrar por nome do país
            string spreadsheetId = "17SQPXA_bOuvlkZENGeCntBytAcBXobJFtivto8cbq3o";
            DataTable dt = new CampanhaGoogleBL().ConsultarCampanhas(spreadsheetId, "Avanco_Geracao!A1:G81000");
            DataView dv = new DataView(dt);
            dv.RowFilter = $"Email LIKE '{filtro}' or PIX LIKE '{filtro.TrimStart('0')}'";
            return dv.ToTable();
        }


    }
}