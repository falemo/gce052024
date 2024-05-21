using APIDemolaySergipe;
using BusinessLogic;
using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolAccessLayer;

namespace BusinessLayer
{
    public class NrSorteCampanhaBL
    {
        private readonly NrSorteCampanhaDAL _nrSorteCampanhaDAL = new NrSorteCampanhaDAL("");

        public NrSorteCampanhaBL()
        {
        }

        public int InserirNrSorteCampanha(string nrCupom, DateTime dtCriacao, int idPessoa, decimal vlrAportado, string nmarqComprovante, bool flValidado, bool flProcessado, bool flCupom, int idCampanha)
        {
            TbCampanha campanha = new CampanhaBL().ObterCampanha(idCampanha);

            if (vlrAportado >= campanha.VlrMinimoSorte)
            {
                decimal resultadoDivisao = vlrAportado / campanha.VlrMinimoSorte;
                int parteInteira = (int)Math.Floor(resultadoDivisao);
                decimal saldoint = vlrAportado - (parteInteira * campanha.VlrMinimoSorte);
                if (saldoint < 0) { saldoint = 0;}

                for (int i = 0; i < parteInteira-1; i++)
                {
                    nrCupom = GerarNrSorteCampanhas(idCampanha);
                    return _nrSorteCampanhaDAL.InserirNrSorteCampanha(nrCupom, dtCriacao, idPessoa, vlrAportado, nmarqComprovante, flValidado, true, true, idCampanha);
                }

                if (saldoint > 0)
                {
                    SaldoCampanhaBL saldoCampanhaBL = new SaldoCampanhaBL();
                    saldoCampanhaBL.InserirSaldoCampanha(idPessoa, idCampanha, saldoint, DateTime.Now, false);
                }
            }
            else
            {
                return _nrSorteCampanhaDAL.InserirNrSorteCampanha("", dtCriacao, idPessoa, vlrAportado, nmarqComprovante, flValidado, false, false, idCampanha);
            }

            return 0;
            
        }

        public int AtualizarNrSorteCampanha(int id, string nrCupom, DateTime dtCriacao, int idPessoa, decimal vlrAportado, string nmarqComprovante, bool flValidado, bool flProcessado, bool flCupom, int idCampanha)
        {
            return _nrSorteCampanhaDAL.AtualizarNrSorteCampanha(id, "", dtCriacao, idPessoa, vlrAportado, nmarqComprovante, flValidado, flProcessado, flCupom, idCampanha);
        }
        public int AtualizarNrCupomCampanha(string nrCupom, int id)
        {
            return _nrSorteCampanhaDAL.UPDATECupom(id, nrCupom);
        }
        public int ExcluirNrSorteCampanha(int id)
        {
            return _nrSorteCampanhaDAL.ExcluirNrSorteCampanha(id);
        }
        public DataTable ConsultarListadeNrSorteaProcessar(int idCampanha, int idPessoa)
        {
            return _nrSorteCampanhaDAL.ConsultarListadeNrSorteaProcessar(idCampanha, idPessoa);

        }
        public DataTable ConsultarNrSorteCampanhas()
        {
            return _nrSorteCampanhaDAL.ConsultarNrSorteCampanhas();
        }

        public DataTable ConsultarNrSorteCampanhas(int idCampanha)
        {
            return _nrSorteCampanhaDAL.ConsultarNrSorteCampanhas(idCampanha);
        }

        public DataTable ConsultarNrSorteCampanhasPessoa(int idCampanha)
        {
            return _nrSorteCampanhaDAL.ConsultarNrSorteCampanhasPessoa(idCampanha);
        }
        

        public DataTable ConsultarNrSorteCampanhas(int idCampanha,int idPessoa)
        {
            return _nrSorteCampanhaDAL.ConsultarListadeNrSorteaProcessar(idCampanha, idPessoa);
        }

        public DataTable ListaLancamentoDisponivel(int idCampanha, int idPessoa)
        {
            return _nrSorteCampanhaDAL.ListaLancamentoDisponivel(idCampanha, idPessoa);
        }

        public DataTable ConsultarLancamentoDisponivel(int idCampanha, int idPessoa)
        {
            return _nrSorteCampanhaDAL.ConsultarLancamentoDisponivel(idCampanha, idPessoa);
        }

        private string GerarNrSorteCampanhas(int idCampanha)
        {
            string nrsorte = "";
            bool numeroValido = false;

            while (!numeroValido)
            {
                // Gerar um número aleatório de 8 dígitos
                nrsorte = new GeradorNumeroAleatorio().GerarNumeroAleatorio(8);

                // Consultar a tabela para verificar se o número gerado já existe
                DataTable tabela = _nrSorteCampanhaDAL.ConsultarNrSorteCampanhasDuplicadaporCampanha(idCampanha, nrsorte);

                // Se a consulta retornar 0 linhas, significa que o número é único
                if (tabela.Rows.Count == 0)
                {
                    return nrsorte;
                }
            }

            return "";

        }
        

      public int RevisareRegistrarCupomCampanhaADMIN(int idCampanha)
        {
            DataTable tabelapessoa = new NrSorteCampanhaBL().ConsultarNrSorteCampanhasPessoa(idCampanha);
            for (int i = 0; i < tabelapessoa.Rows.Count; i++)
            {    
                DataTable tabelaMaster = new NrSorteCampanhaBL().ConsultarListadeNrSorteaProcessar(idCampanha, (int)tabelapessoa.Rows[i]["idPessoa"]) ;
                DataTable tabelaSaldo = new SaldoCampanhaBL().ConsultarSaldoCampanha(idCampanha, (int)tabelapessoa.Rows[i]["idPessoa"]);
                TbCampanha campanha = new CampanhaBL().ObterCampanha(idCampanha);
                TbSaldoCampanha saldo = new SaldoCampanhaBL().ObterSaldoCampanha((int)tabelaSaldo.Rows[0]["id"]);
                TbNrSorteCampanha[] nrSorteCampanha = new TbNrSorteCampanha[tabelaMaster.Rows.Count];
                decimal vlrAportado = 0;
                string nrCupom = "";
                int arrayIndex = 0;

                for (int p = 0; p < tabelaMaster.Rows.Count; p++)
                {
                    nrSorteCampanha[arrayIndex] = new NrSorteCampanhaBL().ObterNrSorteCampanha((int)tabelaMaster.Rows[p]["id"]);
                    vlrAportado = nrSorteCampanha[arrayIndex].VlrAportado + saldo.VlrSaldo;

                    if (vlrAportado >= campanha.VlrMinimoSorte)
                    {
                        decimal resultadoDivisao = vlrAportado / campanha.VlrMinimoSorte;
                        int parteInteira = (int)Math.Floor(resultadoDivisao);

                        decimal saldoint = nrSorteCampanha[arrayIndex].VlrAportado - (parteInteira * campanha.VlrMinimoSorte);
                        if (saldoint < 0) { saldoint = 0; }

                        nrCupom = GerarNrSorteCampanhas(idCampanha);
                        _nrSorteCampanhaDAL.UPDATECupom(nrSorteCampanha[arrayIndex].Id, nrCupom);
                        _nrSorteCampanhaDAL.UPDATELancamentoDisponivel(nrSorteCampanha[arrayIndex].Id);
                        _nrSorteCampanhaDAL.UPDATEFlagCupom(nrSorteCampanha[arrayIndex].Id);

                        if (saldoint > 0)
                        {
                            SaldoCampanhaBL saldoCampanhaBL = new SaldoCampanhaBL();
                            saldoCampanhaBL.AtualizarSaldoCampanha(saldo.Id, saldo.VlrSaldo, true);
                            int idSaldo = saldoCampanhaBL.InserirSaldoCampanha((int)tabelapessoa.Rows[i]["idPessoa"], idCampanha, saldoint, DateTime.Now, false);
                            saldo = new SaldoCampanhaBL().ObterSaldoCampanha(idSaldo);
                        }

                        for (int j = 0; j < nrSorteCampanha.Length; j++)
                        {
                            _nrSorteCampanhaDAL.UPDATELancamentoDisponivel(nrSorteCampanha[j].Id);
                            _nrSorteCampanhaDAL.UPDATEFlagCupom(nrSorteCampanha[j].Id);
                        }

                        nrSorteCampanha = new TbNrSorteCampanha[tabelaMaster.Rows.Count - (i + 1)];
                        nrCupom = "";
                        arrayIndex = 0;
                        vlrAportado = 0;
                    }
                    else
                    {
                        arrayIndex++;
                    }
                }
            }

            return 1;
        }
        public int RevisareRegistrarCupomCampanha(int idCampanha, int idPessoa)
        {
            DataTable tabelaMaster = new NrSorteCampanhaBL().ConsultarListadeNrSorteaProcessar(idCampanha, idPessoa);
            DataTable tabelaSaldo = new SaldoCampanhaBL().ConsultarSaldoCampanha(idCampanha, idPessoa);
            TbCampanha campanha = new CampanhaBL().ObterCampanha(idCampanha);
            TbSaldoCampanha saldo = new SaldoCampanhaBL().ObterSaldoCampanha((int)tabelaSaldo.Rows[0]["id"]);
            //decimal saldo = tabelaSaldo.Rows.Count > 0 ? (decimal)tabelaSaldo.Rows[0]["vlrSaldo"] : 0;
            TbNrSorteCampanha[] nrSorteCampanha = new TbNrSorteCampanha[tabelaMaster.Rows.Count];
            decimal vlrAportado = 0;
            string nrCupom = "";
            int arrayIndex = 0;

            for (int i = 0; i < tabelaMaster.Rows.Count; i++)
            {
                nrSorteCampanha[arrayIndex] = new NrSorteCampanhaBL().ObterNrSorteCampanha((int)tabelaMaster.Rows[i]["id"]);
                vlrAportado = nrSorteCampanha[arrayIndex].VlrAportado + saldo.VlrSaldo;

                if (vlrAportado >= campanha.VlrMinimoSorte)
                {
                    decimal resultadoDivisao = vlrAportado / campanha.VlrMinimoSorte;
                    int parteInteira = (int)Math.Floor(resultadoDivisao);

                    decimal saldoint = nrSorteCampanha[arrayIndex].VlrAportado - (parteInteira * campanha.VlrMinimoSorte);
                    if (saldoint < 0) { saldoint = 0; }
                    
                    nrCupom = GerarNrSorteCampanhas(idCampanha);
                    _nrSorteCampanhaDAL.UPDATECupom(nrSorteCampanha[arrayIndex].Id, nrCupom);
                    _nrSorteCampanhaDAL.UPDATELancamentoDisponivel(nrSorteCampanha[arrayIndex].Id);
                    _nrSorteCampanhaDAL.UPDATEFlagCupom(nrSorteCampanha[arrayIndex].Id);

                    if (saldoint > 0)
                    {
                        SaldoCampanhaBL saldoCampanhaBL = new SaldoCampanhaBL();
                        saldoCampanhaBL.AtualizarSaldoCampanha(saldo.Id, saldo.VlrSaldo, true);
                        int idSaldo = saldoCampanhaBL.InserirSaldoCampanha(idPessoa, idCampanha, saldoint, DateTime.Now, false);
                        saldo = new SaldoCampanhaBL().ObterSaldoCampanha(idSaldo);
                    }

                    for (int j = 0; j < nrSorteCampanha.Length; j++)
                    {
                        _nrSorteCampanhaDAL.UPDATELancamentoDisponivel(nrSorteCampanha[j].Id);
                        _nrSorteCampanhaDAL.UPDATEFlagCupom(nrSorteCampanha[j].Id);
                    }

                    nrSorteCampanha = new TbNrSorteCampanha[tabelaMaster.Rows.Count - (i + 1)];
                    nrCupom = "";
                    arrayIndex = 0;
                    vlrAportado = 0;
                }
                else
                {
                    arrayIndex++;
                }
            }

            return 1;
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
                nrSorteCampanha.FlValidado = Convert.ToBoolean(row["flValidado"]);
                nrSorteCampanha.FlProcesado = Convert.ToBoolean(row["flProcessado"]);
                nrSorteCampanha.FlCupom = Convert.ToBoolean(row["flCupom"]);
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
                nrSorteCampanha.FlValidado = Convert.ToBoolean(row["flValidado"]);
                nrSorteCampanha.FlProcesado = Convert.ToBoolean(row["flProcessado"]);
                nrSorteCampanha.FlCupom = Convert.ToBoolean(row["flCupom"]);

                CampanhaBL campanhaBL = new CampanhaBL();
                nrSorteCampanha.Campanha = campanhaBL.ObterCampanha((int)row["idCampanha"]);

                nrSorteCampanhas.Add(nrSorteCampanha);
            }

            return nrSorteCampanhas;
        }
    }
}
