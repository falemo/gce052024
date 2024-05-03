using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolAccessLayer;
using ModelLayer;
using BusinessLogic;

namespace BusinessLayer
{
    public class AvaliacaoPersonalTrainersBL
    {
        private AvaliacaoPersonalTrainersDAL _avaliacaoPersonalTrainersDAL = new AvaliacaoPersonalTrainersDAL();
        public AvaliacaoPersonalTrainersBL()
        {
        }
        public int InserirAvaliacaoPersonalTrainers(int mes, int ano, float avgAvaliacao, int idPersonal)
        {
            return _avaliacaoPersonalTrainersDAL.InserirAvaliacaoPersonalTrainers(mes, ano, avgAvaliacao, idPersonal);
        }

        public int AtualizarAvaliacaoPersonalTrainers(int id, int mes, int ano, float avgAvaliacao, int idPersonal)
        {
            return _avaliacaoPersonalTrainersDAL.AtualizarAvaliacaoPersonalTrainers(id, mes, ano, avgAvaliacao, idPersonal);
        }

        public int ExcluirAvaliacaoPersonalTrainers(int id)
        {
            return _avaliacaoPersonalTrainersDAL.ExcluirAvaliacaoPersonalTrainers(id);
        }

        public DataTable ConsultarAvaliacaoPersonalTrainers()
        {
            return _avaliacaoPersonalTrainersDAL.ConsultarAvaliacaoPersonalTrainers();
        }

        public DataTable ConsultarAvaliacaoPersonalTrainersPorAno(int ano)
        {
            return _avaliacaoPersonalTrainersDAL.ConsultarAvaliacaoPersonalTrainersPorAno(ano);
        }

        public DataTable ConsultarAvaliacaoPersonalTrainersPorPersonal(int idPersonal)
        {
            return _avaliacaoPersonalTrainersDAL.ConsultarAvaliacaoPersonalTrainersPorPersonal(idPersonal);
        }
        public TbAvaliacaoPersonalTrainers AvaliacaoPersonalTrainers(int id)
        {
            DataTable dataTable = _avaliacaoPersonalTrainersDAL.ConsultarAvaliacaoPersonalTrainers(id);
            TbAvaliacaoPersonalTrainers avaliacaoPersonalTrainers = new TbAvaliacaoPersonalTrainers();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    avaliacaoPersonalTrainers.Id = (int)row["Id"];
                    avaliacaoPersonalTrainers.Ano= (int)row["Ano"];
                    avaliacaoPersonalTrainers.Mes = (int)row["Mes"];
                    avaliacaoPersonalTrainers.AvgAvaliacao = (float)row["avgAvaliacao"];
                    avaliacaoPersonalTrainers.IdPersonal = (int)row["IdPersonal"];
                    PersonalTrainersBL personalTrainersBL = new PersonalTrainersBL();
                    avaliacaoPersonalTrainers.PersonalTrainers = personalTrainersBL.ObterPersonalTrainers(avaliacaoPersonalTrainers.IdPersonal);
                }
            }
            return avaliacaoPersonalTrainers;
        }
    }
}
