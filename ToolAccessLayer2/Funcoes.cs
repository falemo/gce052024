using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;
using System.Configuration;
using System.Xml;
using System.IO;

namespace ToolAccessLayer
{
    public class Funcoes
    {
        public static bool ValidarEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double GetValorInestimentos(string nmAtivo)
        {
            double vlrultimo = 0;

            using (XmlReader xmlReader = XmlReader.Create(nmAtivo))
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Papel"))
                    {
                        if (xmlReader.HasAttributes)
                        {
                            string codigo = xmlReader.GetAttribute("Codigo");
                            string ultimoAttribute = xmlReader.GetAttribute("Ultimo");
                            if (codigo != null && ultimoAttribute != null)
                            {
                                vlrultimo = double.Parse(ultimoAttribute);
                            }
                        }
                    }
                }
            }

            return vlrultimo;
        }

        public static int RandomNumber(int min, int max, bool considera)
        {
            if (!considera)
            {
                min = 1;
                max = 900000;
            }
            Random random = new Random();
            return random.Next(min, max);
        }
        public static bool ValidarPassword(string pass, out string mensagem)
        {
            // Validate password
            string password = pass;

            if (password.Length < 8)
            {
                mensagem = "A senha deve ter pelo menos 8 caracteres.";
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                mensagem = "A senha deve conter pelo menos uma letra maiúscula.";
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                mensagem = "A senha deve conter pelo menos uma letra minúscula.";
                return false;
            }

            mensagem = "Password is valid.";

            return true;
        }

        #region Método para registrar erro no log
        public static void LogError(string ex, string stack)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"E:\home\demolayse2\demolaysergipe.org.br\web\Logs\Logs.txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - Error: " + ex);
                    writer.WriteLine("StackTrace: " + stack);
                    writer.WriteLine(); // Adiciona uma linha em branco para separar os registros de erro
                }
            }
            catch (Exception)
            {
                // Caso ocorra algum erro ao tentar gravar no arquivo de log, não faz nada
            }
        }
        #endregion
    }
}
