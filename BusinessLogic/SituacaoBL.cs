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
    public class SituacaoBL
    {
        private readonly SituacaoDAL _situacaoDAL = new SituacaoDAL();

        public SituacaoBL()
        {
        }

        public int InserirSituacao(string descricao, bool flBloqueado, bool flNovo, bool flSuspenso, bool flAtivo)
        {
            return _situacaoDAL.InserirSituacao(descricao, flBloqueado, flNovo, flSuspenso, flAtivo);
        }

        public int ExcluirSituacao(int id)
        {
            return _situacaoDAL.ExcluirSituacao(id);
        }

        public DataTable ConsultarSituacoes()
        {
            return _situacaoDAL.ConsultarSituacoes();
        }

        public TbSituacao ConsultarSituacaoPorId(int id)
        {
            DataTable dataTable = _situacaoDAL.ConsultarSituacoes(id);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if ((int)dataRow["Id"] == id)
                {
                    return new TbSituacao
                    {
                        Id = (int)dataRow["Id"],
                        Descricao = dataRow["Descricao"].ToString(),
                        FlBloqueado = Convert.ToBoolean(dataRow["flBloqueado"]),
                        FlNovo = Convert.ToBoolean(dataRow["flNovo"]),
                        FlSuspenso = Convert.ToBoolean(dataRow["flSuspenso"]),
                        FlAtivo = Convert.ToBoolean(dataRow["flAtivo"])
                    };
                }
            }

            return null;
        }
    }
 
}