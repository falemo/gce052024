using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbEspecialidadPersonalTrainers
    {
        public int Id { get; set; }
        public int IdEspecialidade { get; set; }
        public DateTime DtHabilitacao { get; set; }
        public bool FlHabilitado { get; set; }
        public DateTime DtAtualizacao { get; set; }
        public int IdPersonal { get; set; }

        public TbEspecialidade Especialidade { get; set; }
        public TbPersonalTrainers PersonalTrainers { get; set; }
    }

}
