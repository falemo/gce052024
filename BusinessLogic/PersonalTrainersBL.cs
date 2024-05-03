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
    public class PersonalTrainersBL
    {
        private readonly PersonalTrainersDAL _personalTrainersDAL = new PersonalTrainersDAL();
        public PersonalTrainersBL()
        {
        }
        public int InserirPersonalTrainers(DateTime dtprofissional, int idSituacao, int idPessoa, string ChavePix1, string ChavePix2)
        {
            return _personalTrainersDAL.InserirPersonalTrainers(dtprofissional, idSituacao, idPessoa, ChavePix1, ChavePix2);
        }

        public int ExcluirPersonalTrainers(int id)
        {
            return _personalTrainersDAL.ExcluirPersonalTrainers(id);
        }

        public DataTable ConsultarPersonalTrainers()
        {
            return _personalTrainersDAL.ConsultarPersonalTrainers();
        }

        public DataTable ConsultarPersonalTrainersPorPessoa(int idPessoa)
        {
            return _personalTrainersDAL.ConsultarPersonalTrainersPorPessoa(idPessoa);
        }

        public TbPersonalTrainers ObterPersonalTrainers(int id)
        {
            DataTable dataTable = _personalTrainersDAL.ConsultarPersonalTrainers(id);
            TbPersonalTrainers personalTrainers = new TbPersonalTrainers();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    personalTrainers.Id = (int)row["Id"];
                    personalTrainers.DtProfissional = (DateTime)row["dtprofissional"];
                    personalTrainers.IdSituacao = (int)row["idSituacao"];
                    personalTrainers.IdPessoa = (int)row["idPessoa"];
                    personalTrainers.ChavePix1 = (string)row["ChavePix1"];
                    personalTrainers.ChavePix2 = (string)row["ChavePix2"];
                }
            }
            return personalTrainers;
        }
    }
}
