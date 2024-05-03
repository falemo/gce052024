using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbTipoMensalidade
    {
        public int Id { get; set; }
        public string DsTipo { get; set; }
        public int DiasFaturacao { get; set; }
        public bool FlHabilitado { get; set; }
    }
}
