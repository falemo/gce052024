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
    public class EspecialidadPersonalTrainersBL
    {
        private readonly EspecialidadPersonalTrainersDAL _especialidadPersonalTrainersDAL = new EspecialidadPersonalTrainersDAL();
        public EspecialidadPersonalTrainersBL()
        {
        }

        public int InserirEspecialidadPersonalTrainers(int idEspecialidade, DateTime dtHabilitacao, bool flHabilitado, DateTime dtAtualizacao, int idPersonal)
        {
            return _especialidadPersonalTrainersDAL.InserirEspecialidadPersonalTrainers(idEspecialidade, dtHabilitacao, flHabilitado, dtAtualizacao, idPersonal);
        }

        public int AtualizarEspecialidadPersonalTrainers(int id, int idEspecialidade, DateTime dtHabilitacao, bool flHabilitado, DateTime dtAtualizacao, int idPersonal)
        {
            return _especialidadPersonalTrainersDAL.AtualizarEspecialidadPersonalTrainers(id, idEspecialidade, dtHabilitacao, flHabilitado, dtAtualizacao, idPersonal);
        }

        public int ExcluirEspecialidadPersonalTrainers(int id)
        {
            return _especialidadPersonalTrainersDAL.ExcluirEspecialidadPersonalTrainers(id);
        }

        public DataTable ConsultarEspecialidadPersonalTrainers()
        {
            return _especialidadPersonalTrainersDAL.ConsultarEspecialidadPersonalTrainers();
        }
        public DataTable ConsultarEspecialidadPersonalTrainers(int id)
        {
            return _especialidadPersonalTrainersDAL.ConsultarEspecialidadPersonalTrainers(id);
        }
        public DataTable ConsultarEspecialidadPersonalTrainersPorPersonal(int idPersonal)
        {
            return _especialidadPersonalTrainersDAL.ConsultarEspecialidadPersonalTrainersPorPersonal(idPersonal);
        }

        public TbEspecialidadPersonalTrainers ObterEspecialidadPersonalTrainersPorId(int id)
        {
            DataTable dataTable = _especialidadPersonalTrainersDAL.ConsultarEspecialidadPersonalTrainers(id);
            TbEspecialidadPersonalTrainers especialidadePersonalTrainers = null;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    especialidadePersonalTrainers = new TbEspecialidadPersonalTrainers();
                    especialidadePersonalTrainers.Id = (int)row["Id"];
                    especialidadePersonalTrainers.IdEspecialidade = (int)row["idEspecialidade"];
                    EspecialidadeBL especialidadeBL = new EspecialidadeBL();
                    especialidadePersonalTrainers.Especialidade = especialidadeBL.ObterEspecialidadePorId(especialidadePersonalTrainers.IdEspecialidade);
                    especialidadePersonalTrainers.DtHabilitacao = (DateTime)row["dtHabilitacao"];
                    especialidadePersonalTrainers.FlHabilitado = (bool)row["flHabilitad"];
                    especialidadePersonalTrainers.DtAtualizacao = (DateTime)row["dtAtualizacao"];
                    especialidadePersonalTrainers.IdPersonal = (int)row["idPersonal"];
                    PersonalTrainersBL personalTrainersBL = new PersonalTrainersBL();
                    especialidadePersonalTrainers.PersonalTrainers = personalTrainersBL.ObterPersonalTrainers(especialidadePersonalTrainers.IdPersonal);
                    break;
                }
            }
            return especialidadePersonalTrainers;
        }
    }
}