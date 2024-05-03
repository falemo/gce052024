using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbEstado
    {
        public int Id { get; set; }
        public string NmEstado { get; set; }
        public string Sigla { get; set; }
        public int IdPais { get; set; }

        public TbPais Pais { get; set; }
    }

}
