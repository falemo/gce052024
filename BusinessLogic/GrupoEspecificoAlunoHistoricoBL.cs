using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GrupoEspecificoAlunoHistoricoBL
    {
        private readonly GrupoEspecificoAlunoHistoricoDAL _grupoEspecificoAlunoHistoricoDAL =new GrupoEspecificoAlunoHistoricoDAL();


        public GrupoEspecificoAlunoHistoricoBL()
        {
        }
        public int InserirGrupoEspecificoAlunoHistorico(int idGrupoEspecifico, int idAluno, int idPersonal, DateTime dtRegistro, float? vlrModificadoNum, string vlrModificadoTxt)
        {
            return _grupoEspecificoAlunoHistoricoDAL.InserirGrupoEspecificoAlunoHistorico(idGrupoEspecifico, idAluno, idPersonal, dtRegistro, vlrModificadoNum, vlrModificadoTxt);
        }

        public DataTable ConsultarGruposEspecificosAlunosHistorico()
        {
            return _grupoEspecificoAlunoHistoricoDAL.ConsultarGruposEspecificosAlunosHistorico();
        }

        public DataTable ConsultarGruposEspecificosAlunosHistoricoPorAluno(int idAluno)
        {
            return _grupoEspecificoAlunoHistoricoDAL.ConsultarGruposEspecificosAlunosHistoricoPorAluno(idAluno);
        }
    }
}