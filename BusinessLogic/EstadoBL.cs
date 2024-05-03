using BusinessLayer;
using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EstadoBL
    {
        private readonly EstadoDAL _estadoDAL =new EstadoDAL();

        public EstadoBL()
        {
        }

        public int InserirEstado(string nmEstado, string sigla, int idPais)
        {
            return _estadoDAL.InserirEstado(nmEstado, sigla, idPais);
        }

        public int AtualizarEstado(int id, string nmEstado, string sigla, int idPais)
        {
            return _estadoDAL.AtualizarEstado(id, nmEstado, sigla, idPais);
        }

        public int ExcluirEstado(int id)
        {
            return _estadoDAL.ExcluirEstado(id);
        }

        public DataTable ConsultarEstados()
        {
            return _estadoDAL.ConsultarEstados();
        }

        public DataTable ConsultarEstadosGrid()
        {
            return _estadoDAL.ConsultarEstadosGrid();
        }

        public DataTable ConsultarEstadosPorPais(int idPais)
        {
            return _estadoDAL.ConsultarEstadosPorPais(idPais);
        }
        public TbEstado ObterEstados(int id)
        {
            DataTable dataTable = _estadoDAL.ConsultarEstados(id);
            TbEstado estado  = new TbEstado();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    estado.Id = (int)row["Id"];
                    estado.NmEstado = row["NmEstado"].ToString();
                    estado.IdPais = (int)row["IdPais"];
                    PaisBL pais = new PaisBL();
                    estado.Pais = pais.ObterPais(estado.IdPais);
                }
            }
            return estado;
        }
    }
}
