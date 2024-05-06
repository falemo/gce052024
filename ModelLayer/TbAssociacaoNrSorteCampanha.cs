using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbAssociacaoNrSorteCampanha
    {
        
        public TbNrSorteCampanha IdNrSorte { get; set; }
        public TbNrSorteCampanha IdSortePai { get; set; }
        public DateTime DtCadastro { get; set; }
        public decimal VlrConvervacao { get; set; }
        public decimal VlrSaldo { get; set; }

    }

}