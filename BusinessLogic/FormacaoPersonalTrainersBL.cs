using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    namespace BusinessLayer
    {
        public class FormacaoPersonalTrainersBL
        {
            private readonly FormacaoPersonalTrainersDAL _formacaoPersonalTrainersDAL = new FormacaoPersonalTrainersDAL();
            public FormacaoPersonalTrainersBL()
            {
            }
            public int InserirFormacaoPersonalTrainers(int idFormacao, DateTime dtConclusao, bool flFinalizado, int idPersonal)
            {
                return _formacaoPersonalTrainersDAL.InserirFormacaoPersonalTrainers(idFormacao, dtConclusao, flFinalizado, idPersonal);
            }

            public int AtualizarFormacaoPersonalTrainers(int id, int idFormacao, DateTime dtConclusao, bool flFinalizado, int idPersonal)
            {
                return _formacaoPersonalTrainersDAL.AtualizarFormacaoPersonalTrainers(id, idFormacao, dtConclusao, flFinalizado, idPersonal);
            }

            public int ExcluirFormacaoPersonalTrainers(int id)
            {
                return _formacaoPersonalTrainersDAL.ExcluirFormacaoPersonalTrainers(id);
            }

            public DataTable ConsultarFormacaoPersonalTrainers()
            {
                return _formacaoPersonalTrainersDAL.ConsultarFormacaoPersonalTrainers();
            }

            public DataTable ConsultarFormacaoPersonalTrainersPorPersonal(int idPersonal)
            {
                return _formacaoPersonalTrainersDAL.ConsultarFormacaoPersonalTrainersPorPersonal(idPersonal);
            }
        }
    }
}
