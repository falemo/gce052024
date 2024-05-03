using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbFormacaoPersonalTrainers
    {
        public int Id { get; set; }
        public int IdFormacao { get; set; }
        public DateTime DtConclusao { get; set; }
        public bool FlFinalizado { get; set; }
        public int IdPersonal { get; set; }

        public TbFormacao Formacao { get; set; }
        public TbPersonalTrainers PersonalTrainers { get; set; }
    }

}
