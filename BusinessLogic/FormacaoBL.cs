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
    public class FormacaoBL
    {
        private FormacaoDAL _FormacaoDAL = new FormacaoDAL();
        public FormacaoBL()
        {
        }
        public int InserirFormacao(string nmFormacao, int idEstado)
        {
            return _FormacaoDAL.InserirFormacao(nmFormacao, idEstado);
        }

        public int AtualizarFormacao(int id, string nmFormacao, int idEstado)
        {
            return _FormacaoDAL.AtualizarFormacao(id, nmFormacao, idEstado);
        }

        public int ExcluirFormacao(int id)
        {
            return _FormacaoDAL.ExcluirFormacao(id);
        }

        public DataTable ConsultarFormacaos()
        {
            return _FormacaoDAL.ConsultarFormacoes();
        }

        public DataTable ConsultarFormacoesPorTipoFormacao(int idTipoFormacao)
        {
            return _FormacaoDAL.ConsultarFormacoesPorTipoFormacao(idTipoFormacao);
        }

        public TbFormacao ObterFormacaoPorId(int id)
        {
            DataTable dataTable = _FormacaoDAL.ConsultarFormacoes(id);
            TbFormacao Formacao = null;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    Formacao = new TbFormacao();
                    Formacao.Id = (int)row["Id"];
                    Formacao.DsFormacao = row["DsFormacao"].ToString();
                    Formacao.IdTipoFormacao = (int)row["IdTipoFormacao"];
                    Formacao.TipoFormacao = new TbTipoFormacao();
                    Formacao.TipoFormacao.Id = (int)row["IdTipoFormacao"];
                    Formacao.TipoFormacao.DsTipo = row["DsTipo"].ToString();
                    Formacao.TipoFormacao.NrNivel = (int)row["NrNivel"];
                    break;
                }
            }
            return Formacao;
        }
    }
}
