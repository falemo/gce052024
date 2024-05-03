using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbPersonalTrainersAluno
    {
        public int IdPersonal { get; set; }
        public int IdAluno { get; set; }
        public DateTime DtCadastro { get; set; }
        public int IdSituacao { get; set; }
        public int IdPlano { get; set; }

        public TbPersonalTrainers PersonalTrainers { get; set; }
        public TbAluno Aluno { get; set; }
        public TbPlanos Planos { get; set; }
        public TbSituacao Situacao { get; set; }
    }
}
