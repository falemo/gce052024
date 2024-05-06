using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbCampanha
    {
        public int Id { get; set; }
        public decimal VlrCampanha { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public bool FlAtiva { get; set; } // Assuming tinyint(1) with values 1 (true) and 0 (false)
        public string DsPix { get; set; }
        public string DsPixInfo { get; set; }
        public TbPessoas Pessoa { get; set; }
        public string FilePath { get; set; } // Assuming text data type is mapped to string
        public decimal VlrMinimoSorte { get; set; } // Assuming text data type is mapped to string

        
    }

}
