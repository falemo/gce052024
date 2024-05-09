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
    public class NrSorteCampanhaBL
    {
        private readonly NrSorteCampanhaDAL _nrSorteCampanhaDAL = new NrSorteCampanhaDAL();

        public NrSorteCampanhaBL()
        {
        }

        public int InserirNrSorteCampanha(string nrCupom, DateTime dtCriacao, int idPessoa, decimal vlrAportado, string nmarqComprovante, bool flValidado, bool flProcessado, bool flCupom, int idCampanha)
        {
            return _nrSorteCampanhaDAL.InserirNrSorteCampanha(nrCupom, dtCriacao, idPessoa, vlrAportado, nmarqComprovante, flValidado, flProcessado, flCupom, idCampanha);
        }

        public int AtualizarNrSorteCampanha(int id, string nrCupom, DateTime dtCriacao, int idPessoa, decimal vlrAportado, string nmarqComprovante, bool flValidado, bool flProcessado, bool flCupom, int idCampanha)
        {
            return _nrSorteCampanhaDAL.AtualizarNrSorteCampanha(id, nrCupom, dtCriacao, idPessoa, vlrAportado, nmarqComprovante, flValidado, flProcessado, flCupom, idCampanha);
        }

        public int ExcluirNrSorteCampanha(int id)
        {
            return _nrSorteCampanhaDAL.ExcluirNrSorteCampanha(id);
        }

        public DataTable ConsultarNrSorteCampanhas()
        {
            return _nrSorteCampanhaDAL.ConsultarNrSorteCampanhas();
        }

        public TbNrSorteCampanha ObterNrSorteCampanha(int id)
        {
            DataTable dataTable = _nrSorteCampanhaDAL.ConsultarNrSorteCampanha(id);
            TbNrSorteCampanha nrSorteCampanha = new TbNrSorteCampanha();
            foreach (DataRow row in dataTable.Rows)
            {
                nrSorteCampanha.Id = (int)row["id"];
                nrSorteCampanha.NrCupom = row["nrCupom"].ToString();
                nrSorteCampanha.DtCriacao = (DateTime)row["dtCriacao"];
                PessoaBL pessoaBL = new PessoaBL();
                nrSorteCampanha.Pessoa = pessoaBL.ObterPessoa((int)row["idPessoa"]);
                nrSorteCampanha.VlrAportado = (decimal)row["vlrAportado"];
                nrSorteCampanha.NmarqComprovante = row["nmarqComprovante"].ToString();
                nrSorteCampanha.FlValidado = (bool)row["flValidado"];
                nrSorteCampanha.FlProcesado = (bool)row["flProcessado"];
                nrSorteCampanha.FlCupom = (bool)row["flCupom"];
                CampanhaBL campanhaBL = new CampanhaBL();
                nrSorteCampanha.Campanha = campanhaBL.ObterCampanha((int)row["idCampanha"]);
            }
            return nrSorteCampanha;
        }

        public List<TbNrSorteCampanha> ObterNrSorteCampanhasPorPessoa(int idCampanha)
        {
            DataTable dataTable = _nrSorteCampanhaDAL.ConsultarNrSorteCampanhas(idCampanha);
            List<TbNrSorteCampanha> nrSorteCampanhas = new List<TbNrSorteCampanha>();

            foreach (DataRow row in dataTable.Rows)
            {
                TbNrSorteCampanha nrSorteCampanha = new TbNrSorteCampanha();
                nrSorteCampanha.Id = (int)row["id"];
                nrSorteCampanha.NrCupom = row["nrCupom"].ToString();
                nrSorteCampanha.DtCriacao = (DateTime)row["dtCriacao"];

                PessoaBL pessoaBL = new PessoaBL();
                nrSorteCampanha.Pessoa = pessoaBL.ObterPessoa((int)row["idPessoa"]);

                nrSorteCampanha.VlrAportado = (decimal)row["vlrAportado"];
                nrSorteCampanha.NmarqComprovante = row["nmarqComprovante"].ToString();
                nrSorteCampanha.FlValidado = (bool)row["flValidado"];
                nrSorteCampanha.FlProcesado = (bool)row["flProcessado"];
                nrSorteCampanha.FlCupom = (bool)row["flCupom"];

                CampanhaBL campanhaBL = new CampanhaBL();
                nrSorteCampanha.Campanha = campanhaBL.ObterCampanha((int)row["idCampanha"]);

                nrSorteCampanhas.Add(nrSorteCampanha);
            }

            return nrSorteCampanhas;
        }
    }
}
