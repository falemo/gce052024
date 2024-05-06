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
    public class TipoPessoalBL
    {
        private readonly TbTipoPessoaDAL _tipoPessoalBL = new TbTipoPessoaDAL();

        public TipoPessoalBL()
        {
        }

        public int InserirTipoPessoa(string dsTipo, bool flAtivo)
        {
            return _tipoPessoalBL.InserirTipoPessoa(dsTipo, flAtivo);
        }

        public int AtualizarTipoPessoa(int id, string dsTipo, bool flAtivo)
        {
            return _tipoPessoalBL.AtualizarTipoPessoa(id, dsTipo, flAtivo);
        }

        public int ExcluirTipoPessoa(int id)
        {
            return _tipoPessoalBL.ExcluirTipoPessoa(id);
        }

        public DataTable ConsultarTipoPessoa()
        {
            return _tipoPessoalBL.ConsultarTiposPessoa();
        }

        public TbTipoPessoa ObterTipoPessoa(int id)
        {
            DataTable dataTable = _tipoPessoalBL.ConsultarTipoPessoa(id);
            TbTipoPessoa tipopessoa = new TbTipoPessoa();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    tipopessoa.Id = (int)row["Id"];
                    tipopessoa.DsTipo = (string)row["dsTipo"];
                    tipopessoa.Flativo = (bool)row["flAtivo"];
                }
            }
            return tipopessoa;
        }
    }
}
