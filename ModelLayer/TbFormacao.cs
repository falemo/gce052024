using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbFormacao
    {
        public int Id { get; set; }
        public string DsFormacao { get; set; }
        public int IdTipoFormacao { get; set; }

        public TbTipoFormacao TipoFormacao { get; set; }
    }

}
