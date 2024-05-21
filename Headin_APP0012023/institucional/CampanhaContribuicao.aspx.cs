using BusinessLayer;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                // Para evitar erros de renderização de controles
                GridViewPaises.AllowPaging = false;
                
                string spreadsheetId = "17SQPXA_bOuvlkZENGeCntBytAcBXobJFtivto8cbq3o";
                DataTable dataTable = new CampanhaGoogleBL().ConsultarCampanhas(spreadsheetId, "Avanco_Geracao!A1:G81000");
                GridViewPaises.DataSource = dataTable;
                GridViewPaises.DataBind();

                GridViewPaises.HeaderRow.Style.Add("background-color", "#FFFFFF");
                foreach (TableCell cell in GridViewPaises.HeaderRow.Cells)
                {
                    cell.Style["background-color"] = "#A55129";
                }
                foreach (GridViewRow row in GridViewPaises.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.Style["background-color"] = "#FFF7E7";
                        }
                        else
                        {
                            cell.Style["background-color"] = "#F7F6F3";
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridViewPaises.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Export")
            {
                ExportGridToExcel();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Necessário para exportação do GridView
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