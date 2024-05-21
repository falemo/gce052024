using APIDemolaySergipe;
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
    public class PaisBL
    {
        private readonly PaisDAL _paisDAL = new PaisDAL("");

        public PaisBL()
        {
        }

        public int InserirPais(string nmPais, int codPais)
        {
            return _paisDAL.InserirPais(nmPais, codPais);
        }

        public int AtualizarPais(int id,string nmPais, int codPais)
        {
            return _paisDAL.AtualizarPais(id,nmPais, codPais);
        }

        public int ExcluirPais(int id)
        {
            return _paisDAL.ExcluirPais(id);
        }

        public DataTable ConsultarPaises()
        {
            return _paisDAL.ConsultarPaises();
        }

        public TbPais ObterPais(int id)
        {
            DataTable dataTable = _paisDAL.ConsultarPaises(id);
            TbPais pais = new TbPais();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    pais.Id = (int)row["Id"];
                    pais.NmPais = (string)row["NmPais"];
                    pais.CodPais = (int)row["CodPais"];
                }
            }
            return pais;
        }
    }
}
