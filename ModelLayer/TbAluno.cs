using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbAluno
    {
        public int Id { get; set; }
        public DateTime Dtaluno { get; set; }
        public int IdSituacao { get; set; }
        public int IdPessoa { get; set; }

        public TbSituacao Situacao { get; set; }
        public TbPessoas Pessoa { get; set; }
    }
}
