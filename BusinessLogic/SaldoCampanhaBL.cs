using APIDemolaySergipe;
using BusinessLayer;
using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLogic
{
    public class SaldoCampanhaBL
    {
        private readonly SaldoCampanhaDAL _saldoCampanhaDAL = new SaldoCampanhaDAL("");

        public int InserirSaldoCampanha(int idPessoa, int idCampanha, decimal vlrSaldo, DateTime dtCarga, bool flUso)
        {
            return _saldoCampanhaDAL.InserirSaldoCampanha(idPessoa, idCampanha, vlrSaldo, dtCarga, flUso);
        }

        public int AtualizarSaldoCampanha(int id, int idPessoa, int idCampanha, decimal vlrSaldo, DateTime dtCarga, bool flUso)
        {
            return _saldoCampanhaDAL.AtualizarSaldoCampanha(id, idPessoa, idCampanha, vlrSaldo, dtCarga, flUso);
        }
    
        public int AtualizarSaldoCampanha(int id, decimal vlrSaldo, bool flUso)
        {
            return _saldoCampanhaDAL.AtualizarSaldoCampanha(id, vlrSaldo, flUso);
        }
    
        public int ExcluirSaldoCampanha(int id)
        {
            return _saldoCampanhaDAL.ExcluirSaldoCampanha(id);
        }

        public DataTable ConsultarSaldoCampanha()
        {
            return _saldoCampanhaDAL.ConsultarSaldoCampanha();
        }

        public DataTable ConsultarSaldoCampanha(int idPessoa, int idCampanha)
        {
            return _saldoCampanhaDAL.ConsultarSaldoCampanha(idPessoa, idCampanha);
        }

        public TbSaldoCampanha ObterSaldoCampanha(int id)
        {
            DataTable dataTable = _saldoCampanhaDAL.ConsultarSaldoCampanha(id);
            TbSaldoCampanha saldoCampanha = new TbSaldoCampanha();
            foreach (DataRow row in dataTable.Rows)
            {
                saldoCampanha.Id = (int)row["id"];

                PessoaBL pessoa = new PessoaBL();
                saldoCampanha.IdPessoa = pessoa.ObterPessoa((int)row["idPessoa"]);

                CampanhaBL campanha = new CampanhaBL();
                saldoCampanha.IdCampanha = campanha.ObterCampanha((int)row["idCampanha"]);
                saldoCampanha.VlrSaldo = (decimal)row["vlrSaldo"];
                saldoCampanha.Dtcarga = (DateTime)row["dtCarga"];
                saldoCampanha.FlUso = Convert.ToBoolean(row["flUso"]);
            }
            return saldoCampanha;
        }
    }
}
