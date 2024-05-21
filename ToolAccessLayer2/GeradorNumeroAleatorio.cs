using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolAccessLayer
{
    public class GeradorNumeroAleatorio
    {
        private Random random;
        private const string CaracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public GeradorNumeroAleatorio()
        {
            random = new Random();
        }

        public string GerarNumeroAleatorio(int tamanho)
        {
            char[] alfanumerico = new char[tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                alfanumerico[i] = CaracteresPermitidos[random.Next(CaracteresPermitidos.Length)];
            }
            return new string(alfanumerico);
        }
    }
}
