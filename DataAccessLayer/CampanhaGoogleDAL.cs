using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using ToolAccessLayer;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;


namespace APIDemolaySergipe
{
    public class CampanhaGoogleDAL
    {
        private string apiKey = "";
        private string chave = "headin2023fabrinioandessantanalemos";
        private readonly SheetsService _sheetsService;

        public CampanhaGoogleDAL()
        {
            // Substitua pela sua chave de API
            apiKey = AesEncryption.DecryptString("32zs+zSrQ1W6qfhIlivIaQtOpVRHQcX/6YbWX6XZk20gRpkShGppBBfDgPOjbk9x", chave);
            //spreadsheetId = "17SQPXA_bOuvlkZENGeCntBytAcBXobJFtivto8cbq3o";


            _sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = "Google Sheets API .NET Quickstart",
            });

        }

        public IList<IList<object>> ReadEntries(string spreadsheetId, string range)
        {
            var request = _sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);
            var response = request.Execute();
            return response.Values;
        }

    }
}
