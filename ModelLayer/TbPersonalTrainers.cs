using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbPersonalTrainers
    {
        public int Id { get; set; }
        public DateTime DtProfissional { get; set; }
        public int IdSituacao { get; set; }
        public int IdPessoa { get; set; }
        public string ChavePix1 { get; set; }
        public string ChavePix2 { get; set; }

        public TbPessoas Pessoas { get; set; }
        public TbSituacao Situacao { get; set; }
    }
}
