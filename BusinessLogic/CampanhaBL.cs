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
    public class CampanhaBL
    {
        private readonly CampanhaDAL _campanhaDAL = new CampanhaDAL();

        public CampanhaBL()
        {
        }

        public int InserirCampanha(decimal vlrCampanha, DateTime dtInicio, DateTime dtFim, bool flAtiva, string dsPix, string dsPixInfo, int idPessoa, string filePath, decimal vlrMinimoSorte)
        {
            return _campanhaDAL.InserirCampanha(vlrCampanha, dtInicio, dtFim, flAtiva, dsPix, dsPixInfo, idPessoa, filePath, vlrMinimoSorte);
        }

        public int AtualizarCampanha(int id, decimal vlrCampanha, DateTime dtInicio, DateTime dtFim, bool flAtiva, string dsPix, string dsPixInfo, int idPessoa, string filePath, decimal vlrMinimoSorte)
        {
            return _campanhaDAL.AtualizarCampanha(id, vlrCampanha, dtInicio, dtFim, flAtiva, dsPix, dsPixInfo, idPessoa, filePath, vlrMinimoSorte);
        }

        public int ExcluirCampanha(int id)
        {
            return _campanhaDAL.ExcluirCampanha(id);
        }

        public DataTable ConsultarCampanhas()
        {
            return _campanhaDAL.ConsultarCampanhas();
        }

        public TbCampanha ObterCampanha(int id)
        {
            DataTable dataTable = _campanhaDAL.ConsultarCampanha(id);
            TbCampanha campanha = new TbCampanha();
            foreach (DataRow row in dataTable.Rows)
            {
                if ((int)row["id"] == id)
                {
                    campanha.Id = (int)row["id"];
                    campanha.VlrCampanha = (decimal)row["vlrCampanha"];
                    campanha.DtInicio = (DateTime)row["dtInicio"];
                    campanha.DtFim = (DateTime)row["dtFim"];
                    campanha.FlAtiva = (bool)row["flAtiva"];
                    campanha.DsPix = row["dsPix"].ToString();
                    campanha.DsPixInfo = row["dsPixInfo"].ToString();

                    PessoaBL pessoa = new PessoaBL();
                    campanha.Pessoa = pessoa.ObterPessoa((int)row["idPessoa"]);

                    campanha.FilePath = row["file_path"].ToString();
                    campanha.VlrMinimoSorte = (decimal)row["vlrMinimoSorte"];
                }
            }
            return campanha;
        }
    }
}
