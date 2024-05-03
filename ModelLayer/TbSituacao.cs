using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbSituacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool FlBloqueado { get; set; }
        public bool FlNovo { get; set; }
        public bool FlSuspenso { get; set; }
        public bool FlAtivo { get; set; }
    }
}
