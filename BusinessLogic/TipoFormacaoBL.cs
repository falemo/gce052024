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
    public class TipoFormacaoBL
    {
        private readonly TipoFormacaoDAL _tipoFormacaoDAL = new TipoFormacaoDAL();

        public TipoFormacaoBL()
        {
        }

        public int InserirTipoFormacao(string dsTipo, int nrNivel)
        {
            return _tipoFormacaoDAL.InserirTipoFormacao(dsTipo, nrNivel);
        }

        public int ExcluirTipoFormacao(int id)
        {
            return _tipoFormacaoDAL.ExcluirTipoFormacao(id);
        }

        public DataTable ConsultarTiposFormacoes()
        {
            return _tipoFormacaoDAL.ConsultarTiposFormacoes();
        }

        public int AtualizarTiposFormacoes(int id, string dsTipo, int nrNivel)
        {
            return _tipoFormacaoDAL.AtualizarTipoFormacao(id, dsTipo, nrNivel);
        }

        public TbTipoFormacao ConsultarTipoFormacaoPorId(int id)
        {
            DataTable dataTable = _tipoFormacaoDAL.ConsultarTiposFormacoes(id);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if ((int)dataRow["Id"] == id)
                {
                    return new TbTipoFormacao
                    {
                        Id = (int)dataRow["Id"],
                        DsTipo = dataRow["DsTipo"].ToString(),
                        NrNivel = (int)dataRow["NrNivel"]
                    };
                }
            }

            return null;
        }
    }

    public class TipoFormacao
    {
        public int Id { get; set; }
        public string DsTipo { get; set; }
        public int NrNivel { get; set; }
    }
}
