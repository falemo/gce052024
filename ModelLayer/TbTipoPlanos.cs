using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbTipoPlanos
    {
        public int Id { get; set; }
        public string DsTipo { get; set; }
        public int NrNivel { get; set; }
        public int IdPersonal { get; set; }

        public TbPersonalTrainers PersonalTrainers { get; set; }
    }
}
