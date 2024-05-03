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
    public class StatusPagamentoBL
    {
        private readonly StatusPagamentoDAL _statusPagamentoDAL = new StatusPagamentoDAL();

        public StatusPagamentoBL()
        {
        }

        public int InserirStatusPagamento(string dsTipo, bool FlPago)
        {
            return _statusPagamentoDAL.InserirStatusPagamento(dsTipo, FlPago);
        }

        public int ExcluirStatusPagamento(int id)
        {
            return _statusPagamentoDAL.ExcluirStatusPagamento(id);
        }

        public DataTable ConsultarStatusPagamentos()
        {
            return _statusPagamentoDAL.ConsultarStatusPagamentos();
        }

        public TbStatusPagamento ConsultarStatusPagamentoPorId(int id)
        {
            DataTable dataTable = _statusPagamentoDAL.ConsultarStatusPagamentos(id);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if ((int)dataRow["Id"] == id)
                {
                    return new TbStatusPagamento
                    {
                        Id = (int)dataRow["Id"],
                        DsTipo = dataRow["DsTipo"].ToString(),
                        FlPago = Convert.ToBoolean(dataRow["FlPago"])
                    };
                }
            }

            return null;
        }
    }
}