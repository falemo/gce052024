using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbMenu
    {
        public int Id { get; set; }
        public string DsMenu { get; set; }
        public bool FlProfessional { get; set; }
        public bool FlHabilitado { get; set; }
        public int NrOrdem { get; set; }

        public TbSubMenu[] TbSubMenu { get; set; }

        public string grupo { get; set; }

        public bool Fladministrador { get; set; }

        

    }  

}
