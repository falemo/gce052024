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
    public class RegistroCampanhaBL
    {
        private readonly TbRegistroCampanhaDAL _registroCampanhaDAL = new TbRegistroCampanhaDAL();

        public RegistroCampanhaBL()
        {
        }

        public int InserirRegistroCampanha(int idCampanha, DateTime dtRegistro, decimal vlrRegistrado, bool flNegativo, int idPessoa, string dsResumo)
        {
            return _registroCampanhaDAL.InserirRegistroCampanha(idCampanha, dtRegistro, vlrRegistrado, flNegativo, idPessoa, dsResumo);
        }

        public int AtualizarRegistroCampanha(int id, int idCampanha, DateTime dtRegistro, decimal vlrRegistrado, bool flNegativo, int idPessoa, string dsResumo)
        {
            return _registroCampanhaDAL.AtualizarRegistroCampanha(id, idCampanha, dtRegistro, vlrRegistrado, flNegativo, idPessoa, dsResumo);
        }

        public int ExcluirRegistroCampanha(int id)
        {
            return _registroCampanhaDAL.ExcluirRegistroCampanha(id);
        }

        public DataTable ConsultarRegistrosCampanha()
        {
            return _registroCampanhaDAL.ConsultarRegistrosCampanha();
        }

        public DataTable ConsultarVlrAcumuladoRegistrosCampanha(int idCampanha)
        {
            return _registroCampanhaDAL.ConsultarValorRegistrosCampanha(idCampanha);
        }
        public TbRegistroCampanha ObterRegistroCampanha(int id)
        {
            DataTable dataTable = _registroCampanhaDAL.ConsultarRegistroCampanha(id);
            TbRegistroCampanha registroCampanha = new TbRegistroCampanha();
            foreach (DataRow row in dataTable.Rows)
            {
                registroCampanha.Id = (int)row["Id"];
                CampanhaBL campanha = new CampanhaBL();
                registroCampanha.Campanha = campanha.ObterCampanha((int)row["idCampanha"]);
                registroCampanha.DtRegistro = (DateTime)row["dtRegistro"];
                registroCampanha.VlrRegistrado = (decimal)row["VlrRegistrado"];
                registroCampanha.FlNegativo = Convert.ToBoolean(row["flNegativo"]);
                PessoaBL pessoa = new PessoaBL();
                registroCampanha.Pessoa = pessoa.ObterPessoa((int)row["idPessoa"]);
                registroCampanha.DsResumo = (string)row["dsResumo"];

            }
            return registroCampanha;
        }


        public List<TbRegistroCampanha> ObterRegistrosPorCampanha(int idCampanha)
        {
            DataTable dataTable = _registroCampanhaDAL.ConsultarRegistroPorCampanha(idCampanha);
            List<TbRegistroCampanha> registros = new List<TbRegistroCampanha>();

            foreach (DataRow row in dataTable.Rows)
            {
                TbRegistroCampanha registro = new TbRegistroCampanha();
                registro.Id = (int)row["id"];
                CampanhaBL campanha = new CampanhaBL();
                registro.Campanha = campanha.ObterCampanha((int)row["idCampanha"]);
                registro.DtRegistro = (DateTime)row["dtRegistro"];
                registro.VlrRegistrado = (decimal)row["vlrRegistrado"];
                registro.FlNegativo = Convert.ToBoolean(row["flNegativo"]);
                PessoaBL pessoa = new PessoaBL();
                registro.Pessoa = pessoa.ObterPessoa((int)row["idPessoa"]);
                registro.DsResumo = row["dsResumo"].ToString();

                registros.Add(registro);
            }

            return registros;
        }
    }
}
