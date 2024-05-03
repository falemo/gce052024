using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbAvaliacaoPersonalTrainers
    {
        public int Id { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public float AvgAvaliacao { get; set; }
        public int IdPersonal { get; set; }

        public TbPersonalTrainers PersonalTrainers { get; set; }
    }

}
