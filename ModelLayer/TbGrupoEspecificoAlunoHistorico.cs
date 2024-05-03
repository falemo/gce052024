using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbGrupoEspecificoAlunoHistorico
    {
        public int Id { get; set; }
        public int IdGrupoEspecifico { get; set; }
        public int IdAluno { get; set; }
        public int IdPersonal { get; set; }
        public DateTime DtRegistro { get; set; }
        public decimal? VlrModificadoNum { get; set; }
        public string VlrModificadoTxt { get; set; }

        public TbGrupoEspecifico GrupoEspecifico { get; set; }
        public TbAluno Aluno { get; set; }
        public TbPersonalTrainers PersonalTrainers { get; set; }
    }

}
