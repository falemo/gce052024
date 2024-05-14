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

        public int InserirSituacao(string descricao, bool flBloqueado, bool flNovo, bool flSuspenso, bool flAtivo, int idGrupo, bool flEstadoFinal)
        {
            return _situacaoDAL.InserirSituacao(descricao, flBloqueado, flNovo, flSuspenso, flAtivo, idGrupo, flEstadoFinal);
        }

        public int ExcluirSituacao(int id)
        {
            return _situacaoDAL.ExcluirSituacao(id);
        }

        public DataTable ConsultarSituacoes()
        {
            return _situacaoDAL.ConsultarSituacoes();
        }

        public TbSituacao ObterSituacao(int id)
        {
            DataTable dataTable = _situacaoDAL.ConsultarSituacoes(id);
            TbSituacao situacao = new TbSituacao();
            foreach (DataRow row in dataTable.Rows)
            {
                situacao.Id = (int)row["Id"];
                situacao.Descricao = (string)row["Descricao"];
                situacao.FlBloqueado = Convert.ToBoolean(row["FlBloqueado"]);
                situacao.FlNovo = Convert.ToBoolean(row["FlNovo"]);
                situacao.FlSuspenso = Convert.ToBoolean(row["FlSuspenso"]);
                situacao.FlAtivo = Convert.ToBoolean(row["FlAtivo"]);
                situacao.IdGrupo = (int)row["IdGrupo"];
                situacao.FlEstadoFinal = Convert.ToBoolean(row["FlEstadoFinal"]);
            }
            return situacao;
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
                        FlAtivo = Convert.ToBoolean(dataRow["flAtivo"]),
                        IdGrupo = (int)dataRow["IdGrupo"],
                        FlEstadoFinal = Convert.ToBoolean(dataRow["FlEstadoFinal"])

                    };
                }
            }

            return null;
        }
    }
 
}