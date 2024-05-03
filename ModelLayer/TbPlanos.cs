using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbPlanos
    {
        public int Id { get; set; }
        public string DsPlano { get; set; }
        public int IdTipoPlano { get; set; }
        public int QtdDiasPlano { get; set; }
        public bool Flativo { get; set; }
        public int DiasParaPagamento { get; set; }
        public int IdPersonal { get; set; }
        public bool FlHabilitado { get; set; }

        public TbPersonalTrainers PersonalTrainers { get; set; }
        public TbTipoPlanos TipoPlanos { get; set; }
    }
}
