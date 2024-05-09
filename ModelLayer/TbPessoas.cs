using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbPessoas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Genero { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string PwdUsuario { get; set; }
        public DateTime DtCadastro { get; set; }
        public TbCidade Cidade { get; set; }
        public TbSituacao Situacao { get; set; }
        public bool FlProfessional { get; set; }
        public bool Fladministrador { get; set; }
        public TbTipoPessoa Tipopessoa { get; set; }
    }
}
