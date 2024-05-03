using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbRegistroCampanha
    {
        public int Id { get; set; }
        public TbCampanha Campanha { get; set; }
        public DateTime DtRegistro { get; set; }
        public decimal VlrRegistrado { get; set; }
        public bool FlNegativo { get; set; } // Assuming tinyint(1) with values 1 (true) and 0 (false)
        public TbPessoas Pessoa { get; set; }
        public string DsResumo { get; set; }
    }

}
