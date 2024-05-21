using APIDemolaySergipe;
using BusinessLogic;
using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 


namespace BusinessLayer
{
    public class CampanhaGoogleBL
    {
        private readonly CampanhaGoogleDAL _CampanhaGoogleDAL = new CampanhaGoogleDAL();

        public CampanhaGoogleBL()
        {

        }
        public DataTable ConsultarCampanhas(string spreadsheetIds, string ranges)
        {
            try
            {
                string spreadsheetId = spreadsheetIds;
                // Substitua pelo intervalo desejado
                string range = ranges;

                var values = _CampanhaGoogleDAL.ReadEntries(spreadsheetIds, ranges);

                if (values != null && values.Count > 0)
                {
                    DataTable dataTable = new DataTable();
                    // Adicionar colunas ao DataTable
                    foreach (var header in values[0])
                    {
                        dataTable.Columns.Add(header.ToString());
                    }
                    // Adicionar linhas ao DataTable
                    for (int i = 1; i < values.Count; i++)
                    {
                        var rows = values[i];
                        DataRow dataRow = dataTable.NewRow();
                        for (int j = 0; j < rows.Count; j++)
                        {
                            dataRow[j] = rows[j];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                    return dataTable;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
