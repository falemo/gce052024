using APIDemolaySergipe;
using BusinessLayer;
using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PessoaBL
    {
        private readonly PessoaDAL _pessoaDAL = new PessoaDAL("");
        public PessoaBL()
        {
        }
        public int InserirPessoa(string nome, DateTime dtNascimento, string genero, string endereco, string email, string telefone, int? idCidade, int? idSituacao, string pwdUsuario, DateTime dtCadastro, bool flProfessional, bool fladministrador, int idTipoPessoa)
        {
            return _pessoaDAL.InserirPessoa(nome, dtNascimento, genero, endereco, email, telefone, idCidade, idSituacao, pwdUsuario, dtCadastro, flProfessional,fladministrador, idTipoPessoa);
        }

        public int AtualizarPessoa(int id, string nome, DateTime dtNascimento, string genero, string endereco, string telefone, int? idCidade, int? idSituacao, DateTime dtCadastro, bool flProfessional, bool fladministrador, int idTipoPessoa)
        {
            return _pessoaDAL.AtualizarPessoa(id, nome, dtNascimento, genero, endereco, telefone, idCidade, idSituacao, dtCadastro, flProfessional, fladministrador,idTipoPessoa);
        }

        public int AtualizarSenha(int id, string email, string pwdUsuario)
        {
            return _pessoaDAL.AtualizarSenha(id, email, pwdUsuario);
        }

        public DataTable GetPessoaPWD(int id, string email, string pwdUsuario)
        {
            return _pessoaDAL.GetPessoaPWD(id, email, pwdUsuario);
        }

        public int AtualizarSituacao(int id, int idSituacao)
        {
            return _pessoaDAL.AtualizarSituacao(id, idSituacao);
        }

        public int ExcluirPessoa(int id)
        {
            return _pessoaDAL.ExcluirPessoa(id);
        }

        public DataTable ConsultarPessoas()
        {
            return _pessoaDAL.ConsultarPessoas();
        }

        public TbPessoas ObterPessoa(int id)
        {
            DataTable dataTable = _pessoaDAL.ConsultarPessoas(id);
            TbPessoas pessoa = new TbPessoas();
            foreach (DataRow row in dataTable.Rows)
            {
                pessoa.Id = (int)row["Id"];
                pessoa.Nome = (string)row["nome"];
                pessoa.DtNascimento = (DateTime)row["DtNascimento"];
                pessoa.Genero = (string)row["Genero"];
                pessoa.Endereco = (string)row["Endereco"];
                pessoa.Email = (string)row["Email"];
                pessoa.Telefone = (string)row["Telefone"];

                CidadeBL cidade = new CidadeBL();
                pessoa.Cidade = cidade.ObterCidadePorId((int)row["idCidade"]);    

                SituacaoBL situacao = new SituacaoBL();
                pessoa.Situacao = situacao.ObterSituacao((int)row["idSituacao"]);

                pessoa.PwdUsuario = ""; // (string)row["PwdUsuario"];
                pessoa.FlProfessional = Convert.ToBoolean(row["FlProfessional"]);
                pessoa.Fladministrador = Convert.ToBoolean(row["fladministrador"]);

                TipoPessoalBL tipoPessoa = new TipoPessoalBL();
                pessoa.Tipopessoa = tipoPessoa.ObterTipoPessoa((int)row["idTipoPessoa"]);
            }
            return pessoa;
        }
    }
}
