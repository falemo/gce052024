using BusinessLayer;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;


namespace Headin_APP0012023
{
    public partial class ConsultaArquivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string path = Request.QueryString["path"] ?? Server.MapPath("../Doc"); // Substitua 'your-directory' pelo nome da pasta que deseja listar
                DisplayFilesAndDirectories(path);
            }
        }

        private void SearchDirectoriesAndFiles(string dir, StringBuilder sb, string searchTerm, ref bool hasResults)
        {
            foreach (var directory in Directory.GetDirectories(dir))
            {
                string dirName = Path.GetFileName(directory);
                if (string.IsNullOrEmpty(searchTerm) || dirName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    string dirPath = $"../Institucional/ConsultaArquivos.aspx?path={HttpUtility.UrlEncode(directory)}";
                    //sb.Append($"<li class='directory'><a href='{dirPath}'>{dirName}</a></li>");
                    sb.Append($"<tr><td class='directory'><a href='{dirPath}'>{dirName}</a></td></tr>");
                    hasResults = true;
                }
                // Busca recursiva em subdiretórios
                SearchDirectoriesAndFiles(directory, sb, searchTerm, ref hasResults);
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                string fileName = Path.GetFileName(file);
                if (string.IsNullOrEmpty(searchTerm) || fileName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    string fileUrl = GetFileUrl(file);
                    //sb.Append($"<li><a href='{fileUrl}' target='_blank'>{fileName}</a></li>");
                    sb.Append($"<tr><td><a href='{fileUrl}' target='_blank'>{fileName}</a></td></tr>");
                    hasResults = true;
                }
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchTerm = SearchBox.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                string path = Request.QueryString["path"] ?? Server.MapPath("../Doc");
                DisplayFilesAndDirectories(path, searchTerm);
            }
        }
        private void DisplayFilesAndDirectories(string path, string searchTerm = "")
        {
            try
            {
                if (Directory.Exists(path))
                {
                    // Gera a listagem de arquivos e pastas
                    StringBuilder fileListingHtml = new StringBuilder();
                    GenerateFileListing(path, fileListingHtml, searchTerm);
                    FileListLiteral.Text = fileListingHtml.ToString();
                }
                else
                {
                    ErrorMessageLiteral.Text = "<div class='error'>Path not found.</div>";
                }
            }
            catch (Exception ex)
            {
                ErrorMessageLiteral.Text = $"<div class='error'>Error: {ex.Message}</div>";
            }
        }

        private void GenerateFileListing(string dir, StringBuilder sb, string searchTerm = "")
        {
            //sb.Append("<ul>");

            sb.Append("<table>");
            sb.Append("<thead><tr><th>Nome</th></tr></thead>"); // Adiciona cabeçalho na tabela
            sb.Append("<tbody>");

            // Adiciona link para a pasta pai se não estiver na raiz

            string consultaArquivosPath = "../Institucional/ConsultaArquivos.aspx";
            sb.Append($"<li class='directory'><a href='{consultaArquivosPath}'>.. (Voltar)</a></li>");

            
            bool hasResults = false;

            // Busca recursiva
            SearchDirectoriesAndFiles(dir, sb, searchTerm, ref hasResults);
  
           

            if (!hasResults)
            {
                sb.Append("<li>No results found.</li>");
            }

            //sb.Append("</ul>");

            sb.Append("</tbody>");
            sb.Append("</table>");
        }
        private void DisplayFilesAndDirectories(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    // Gera a listagem de arquivos e pastas
                    StringBuilder fileListingHtml = new StringBuilder();
                    GenerateFileListing(path, fileListingHtml);
                    FileListLiteral.Text = fileListingHtml.ToString();
                }
                else
                {
                    ErrorMessageLiteral.Text = "<div class='error'>Path not found.</div>";
                }
            }
            catch (Exception ex)
            {
                ErrorMessageLiteral.Text = $"<div class='error'>Error: {ex.Message}</div>";
            }
        }

        private void GenerateFileListing(string dir, StringBuilder sb)
        {
            try
            {
                //sb.Append("<ul>");
                
                sb.Append("<table>");
                sb.Append("<thead><tr><th>Nome</th></tr></thead>"); // Adiciona cabeçalho na tabela
                sb.Append("<tbody>");

                // Adiciona link para a pasta pai se não estiver na raiz
                if (dir != Server.MapPath("../Doc")) // Substitua 'your-directory' pelo nome da pasta que deseja listar
                {
                    string parentDir = Directory.GetParent(dir).FullName;
                    string parentDirPath = $"../Institucional/ConsultaArquivos.aspx?path={HttpUtility.UrlEncode(parentDir)}";
                    //sb.Append($"<li class='directory'><a href='{parentDirPath}'>.. (Voltar)</a></li>");
                    sb.Append($"<tr><td class='directory'><a href='{parentDirPath}'>.. (Voltar)</a></td></tr>");

                }

                foreach (var directory in Directory.GetDirectories(dir))
                {
                    string dirName = Path.GetFileName(directory);
                    string dirPath = $"../Institucional/ConsultaArquivos.aspx?path={HttpUtility.UrlEncode(directory)}";
                    //sb.Append($"<li class='directory'><a href='{dirPath}'>{dirName}</a></li>");

                    sb.Append($"<tr><td class='directory'><a href='{dirPath}'>{dirName}</a></td></tr>");

                }

                foreach (var file in Directory.GetFiles(dir))
                {
                    string fileName = Path.GetFileName(file);
                    string fileUrl = GetFileUrl(file);
                    //sb.Append($"<li><a href='{fileUrl}' target='_blank'>{fileName}</a></li>");
                    sb.Append($"<tr><td><a href='{fileUrl}' target='_blank'>{fileName}</a></td></tr>");
                }
                //sb.Append("</ul>");

                sb.Append("</tbody>");
                sb.Append("</table>");
            }
            catch (Exception ex)
            {
                ErrorMessageLiteral.Text = $"<div class='error'>Error: {ex.Message}</div>";
            }
        }

        private string GetFileUrl(string filePath)
        {
            // Substitui Server.MapPath("~/") pelo caminho físico da raiz do site
            string rootPath = Server.MapPath("~/");
            // Remove o caminho raiz do caminho completo do arquivo para obter a URL relativa
            string relativePath = filePath.Replace(rootPath, "").Replace("\\", "/");
            // Retorna a URL relativa com base no caminho do aplicativo
            return ResolveUrl($"~/{relativePath}");
        }
    }
}