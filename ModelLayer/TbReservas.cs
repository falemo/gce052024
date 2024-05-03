using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbReservas
    {
        public int Id { get; set; }
        public int Idaluno { get; set; }
        public int IdPersonal { get; set; }
        public DateTime DtReserva { get; set; }
        public DateTime Dtregistro { get; set; }
        public int IdHorarioTreino { get; set; }
        public int NrAvaliacao { get; set; }
        public bool FlRealizado { get; set; }

        public TbPersonalTrainers PersonalTrainers { get; set; }
        public TbAluno Aluno { get; set; }
        public TbHorarioTreino HorarioTreino { get; set; }
    }
}
