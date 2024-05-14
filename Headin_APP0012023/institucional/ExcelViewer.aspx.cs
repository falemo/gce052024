using BusinessLayer;
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
using ExcelDataReader;



namespace Headin_APP0012023
{
    public partial class ExcelViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadExcelData();
            }
        }

        private void LoadExcelData()
        {
            // Caminho do arquivo Excel
            string filePath = Server.MapPath("~/uploads/DadosCampanha.xlsx");

            // Verifica se o arquivo existe
            if (File.Exists(filePath))
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });

                        if (result.Tables.Count > 0)
                        {
                            DataTable excelDataTable = result.Tables[1];
                            gridViewExcelData.DataSource = excelDataTable;
                            gridViewExcelData.DataBind();
                        }
                    }
                }
            }
            else
            {
                Response.Write("Arquivo Excel não encontrado.");
            }
        }
    }
}
