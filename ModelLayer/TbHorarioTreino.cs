using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbHorarioTreino
    {
        public int Id { get; set; }
        public string DsHorario { get; set; }
        public int DiaDaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public int IdPersonal { get; set; }
        public bool FlHabilitado { get; set; }

        public TbPersonalTrainers PersonalTrainers { get; set; }
    }

}
