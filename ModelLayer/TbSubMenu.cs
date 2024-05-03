using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbSubMenu
    {
        public int IdSubMenu { get; set; }
        public TbMenu IdMenu { get; set; }
        public string DsSubMenu { get; set; }
        public bool FlProfissional { get; set; }
        public bool Flhabilitado { get; set; }
        public string DsLink { get; set; }
        public int NrOrdem { get; set; }
        public bool Fladministrador { get; set; }

    }
}
