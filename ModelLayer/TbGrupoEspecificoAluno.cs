using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbGrupoEspecificoAluno
    {
        public int IdGrupoEspecifico { get; set; }
        public int IdAluno { get; set; }
        public int IdPersonal { get; set; }
        public DateTime DtCadastro { get; set; }

        public TbGrupoEspecifico GrupoEspecifico { get; set; }
        public TbAluno Aluno { get; set; }
        public TbPersonalTrainers PersonalTrainers { get; set; }
    }

}
