using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GrupoEspecificoAlunoBL
    {
        private readonly GrupoEspecificoAlunoDAL _grupoEspecificoAlunoDAL = new GrupoEspecificoAlunoDAL();
        public GrupoEspecificoAlunoBL()
        {
        }
        public int InserirGrupoEspecificoAluno(int idGrupoEspecifico, int idAluno, int idPersonal, DateTime dtCadastro)
        {
            return _grupoEspecificoAlunoDAL.InserirGrupoEspecificoAluno(idGrupoEspecifico, idAluno, idPersonal, dtCadastro);
        }

        public int ExcluirGrupoEspecificoAluno(int idGrupoEspecifico, int idAluno)
        {
            return _grupoEspecificoAlunoDAL.ExcluirGrupoEspecificoAluno(idGrupoEspecifico, idAluno);
        }

        public DataTable ConsultarGruposEspecificosAlunos()
        {
            return _grupoEspecificoAlunoDAL.ConsultarGruposEspecificosAlunos();
        }

        public DataTable ConsultarGruposEspecificosAlunosPorAluno(int idAluno)
        {
            return _grupoEspecificoAlunoDAL.ConsultarGruposEspecificosAlunosPorAluno(idAluno);
        }
    }
}