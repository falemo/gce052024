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
    public class AssociacaoNrSorteCampanhaBL
    {
        private readonly AssociacaoNrSorteCampanhaDAL _associacaoNrSorteCampanhaDAL = new AssociacaoNrSorteCampanhaDAL();

        public AssociacaoNrSorteCampanhaBL()
        {
        }

        public int InserirAssociacaoNrSorteCampanha(int idNrSorte, int idSortePai, DateTime dtCadastro, decimal vlrConvervacao, decimal vlrSaldo)
        {
            return _associacaoNrSorteCampanhaDAL.InserirAssociacaoNrSorteCampanha(idNrSorte, idSortePai, dtCadastro, vlrConvervacao, vlrSaldo);
        }

        public int AtualizarAssociacaoNrSorteCampanha(int idNrSorte, int idSortePai, DateTime dtCadastro, decimal vlrConvervacao, decimal vlrSaldo)
        {
            return _associacaoNrSorteCampanhaDAL.AtualizarAssociacaoNrSorteCampanha(idNrSorte, idSortePai, dtCadastro, vlrConvervacao, vlrSaldo);
        }

        public int ExcluirAssociacaoNrSorteCampanha(int idNrSorte, int idSortePai)
        {
            return _associacaoNrSorteCampanhaDAL.ExcluirAssociacaoNrSorteCampanha(idNrSorte, idSortePai);
        }

        public DataTable ConsultarAssociacoesNrSorteCampanha()
        {
            return _associacaoNrSorteCampanhaDAL.ConsultarAssociacaoNrSorteCampanha();
        }

        public TbAssociacaoNrSorteCampanha ObterAssociacaoNrSorteCampanha(int idNrSorte, int idSortePai)
        {
            DataTable dataTable = _associacaoNrSorteCampanhaDAL.ConsultarAssociacaoNrSorteCampanha(idNrSorte, idSortePai);
            TbAssociacaoNrSorteCampanha associacaoNrSorteCampanha = new TbAssociacaoNrSorteCampanha();
            foreach (DataRow row in dataTable.Rows)
            {

                NrSorteCampanhaBL nrSorte = new NrSorteCampanhaBL();
                associacaoNrSorteCampanha.IdNrSorte = nrSorte.ObterNrSorteCampanha((int)row["idNrSorte"]);
                associacaoNrSorteCampanha.IdSortePai = nrSorte.ObterNrSorteCampanha((int)row["idSortePai"]);
                associacaoNrSorteCampanha.DtCadastro = (DateTime)row["dtCadastro"];
                associacaoNrSorteCampanha.VlrConvervacao = (decimal)row["vlrConvervacao"];
                associacaoNrSorteCampanha.VlrSaldo = (decimal)row["vlrSaldo"];
            }
            return associacaoNrSorteCampanha;
        }

        public List<TbAssociacaoNrSorteCampanha> ObterAssociacoesPorSortePai(int idSortePai)
        {
            DataTable dataTable = _associacaoNrSorteCampanhaDAL.ConsultarAssociacaoNrSorteCampanha(idSortePai);
            List<TbAssociacaoNrSorteCampanha> associacoes = new List<TbAssociacaoNrSorteCampanha>();

            foreach (DataRow row in dataTable.Rows)
            {
                TbAssociacaoNrSorteCampanha associacao = new TbAssociacaoNrSorteCampanha();
                NrSorteCampanhaBL nrSorte = new NrSorteCampanhaBL();
                associacao.IdNrSorte = nrSorte.ObterNrSorteCampanha((int)row["idNrSorte"]);
                associacao.IdSortePai = nrSorte.ObterNrSorteCampanha((int)row["idSortePai"]);
                associacao.DtCadastro = (DateTime)row["dtCadastro"];
                associacao.VlrConvervacao = (decimal)row["vlrConvervacao"];
                associacao.VlrSaldo = (decimal)row["vlrSaldo"];

                associacoes.Add(associacao);
            }

            return associacoes;
        }
    }
}
