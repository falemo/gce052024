using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbEspecialidade
    {
        public int Id { get; set; }
        public string DsEspecialidade { get; set; }
        public int IdTipoEspecialidade { get; set; }

        public TbTipoEspecialidade TipoEspecialidade { get; set; }
    }

}
