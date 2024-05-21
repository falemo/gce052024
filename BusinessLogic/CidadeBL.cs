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
    public class CidadeBL
    {
        private CidadeDAL _cidadeDAL = new CidadeDAL("");
         
        public CidadeBL()
        {
        }
   
        public int InserirCidade(string nmCidade, int idEstado)
        {
            return _cidadeDAL.InserirCidade(nmCidade, idEstado);
        }

        public int AtualizarCidade(int id, string nmCidade, int idEstado)
        {
            return _cidadeDAL.AtualizarCidade(id, nmCidade, idEstado);
        }

        public int ExcluirCidade(int id)
        {
            return _cidadeDAL.ExcluirCidade(id);
        }

        public DataTable ConsultarCidades()
        {
            return _cidadeDAL.ConsultarCidades();
        }
        public DataTable ConsultarCidadesComboGrid()
        {
            return _cidadeDAL.ConsultarCidadesGrid();
        }
        public DataTable ConsultarCidadesPorEstado(int idEstado)
        {
            return _cidadeDAL.ConsultarCidadesPorEstado(idEstado);
        }

        public TbCidade ObterCidadePorId(int id)
        {
            DataTable dataTable = _cidadeDAL.ConsultarCidades(id);
            TbCidade cidade = null;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    cidade = new TbCidade();
                    cidade.Id = (int)row["Id"];
                    cidade.NmCidade = row["NmCidade"].ToString();
                    cidade.IdEstado = (int)row["IdEstado"];
                    EstadoBL estadoBL = new EstadoBL();
                    cidade.Estado = estadoBL.ObterEstados(cidade.IdEstado);
                    break;
                }
            }
            return cidade;
        }
    }
}
