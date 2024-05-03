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
    public class PersonalTrainersAlunoBL
    {
        private readonly PersonalTrainersAlunoDAL _personalTrainersAlunoDAL = new PersonalTrainersAlunoDAL();
        public PersonalTrainersAlunoBL()
        {
        }
        public int InserirPersonalTrainersAluno(int idPersonal, int idAluno, DateTime DtCadastro, int idSituacao, int idPlano)
        {
            return _personalTrainersAlunoDAL.InserirPersonalTrainersAluno(idPersonal, idAluno, DtCadastro, idSituacao, idPlano);
        }

        public int ExcluirPersonalTrainersAluno(int idPersonal, int idAluno)
        {
            return _personalTrainersAlunoDAL.ExcluirPersonalTrainersAluno(idPersonal, idAluno);
        }

        public DataTable ConsultarPersonalTrainersAlunos()
        {
            return _personalTrainersAlunoDAL.ConsultarPersonalTrainersAlunos();
        }

        public TbPersonalTrainersAluno ObterPersonalTrainersAluno(int idPersonal, int idAluno)
        {
            DataTable dataTable = _personalTrainersAlunoDAL.ConsultarPersonalTrainersAlunos(idPersonal, idAluno);
            TbPersonalTrainersAluno personalTrainersAluno = new TbPersonalTrainersAluno();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["idPersonal"].Equals(idPersonal) && row["idAluno"].Equals(idAluno))
                {
                    personalTrainersAluno.IdPersonal = (int)row["idPersonal"];
                    personalTrainersAluno.IdAluno = (int)row["idAluno"];
                    personalTrainersAluno.DtCadastro = (DateTime)row["DtCadastro"];
                    personalTrainersAluno.IdSituacao = (int)row["idSituacao"];
                    personalTrainersAluno.IdPlano = (int)row["idPlano"];
                }
            }
            return personalTrainersAluno;
        }
    }
}
