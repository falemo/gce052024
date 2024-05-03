using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbNrSorteCampanha
    {
        public int Id { get; set; }
        public string NrCupom { get; set; }
        public DateTime DtCriacao { get; set; }
        public TbPessoas Pessoa { get; set; }
        public decimal VlrAportado { get; set; }
        public string NmarqComprovante { get; set; }
        public bool FlValidado { get; set; } // Assuming tinyint(1) with values 1 (true) and 0 (false)
        public TbRegistroCampanha RegistroCampanha { get; set; }
    }

}
