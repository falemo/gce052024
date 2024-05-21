using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbSaldoCampanha
    {
        public int Id { get; set; }
        public TbPessoas IdPessoa { get; set; }
        public TbCampanha IdCampanha { get; set; }
        public decimal VlrSaldo { get; set; }
        public DateTime Dtcarga { get; set; }
        public bool FlUso { get; set; }
    }
}
