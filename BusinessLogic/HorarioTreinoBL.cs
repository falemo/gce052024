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
    public class HorarioTreinoBL
    {
        private readonly HorarioTreinoDAL _horarioTreinoDAL = new HorarioTreinoDAL();
        public HorarioTreinoBL()
        {
        }
        public int InserirHorarioTreino(string dsHorario, int diaDaSemana, TimeSpan horaInicio, TimeSpan horaFim, int idPersonal, bool flHabilitado)
        {
            return _horarioTreinoDAL.InserirHorarioTreino(dsHorario, diaDaSemana, horaInicio, horaFim, idPersonal, flHabilitado);
        }

        public int ExcluirHorarioTreino(int id)
        {
            return _horarioTreinoDAL.ExcluirHorarioTreino(id);
        }

        public DataTable ConsultarHorariosTreinos()
        {
            return _horarioTreinoDAL.ConsultarHorariosTreinos();
        }

        public DataTable ConsultarHorariosTreinosPorPersonal(int idPersonal)
        {
            return _horarioTreinoDAL.ConsultarHorariosTreinosPorPersonal(idPersonal);
        }

        public TbHorarioTreino ObterHorarioTreino(int id)
        {
            DataTable dataTable = _horarioTreinoDAL.ConsultarHorariosTreinos(id);
            TbHorarioTreino horarioTreino = new TbHorarioTreino();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    horarioTreino.Id = (int)row["Id"];
                    horarioTreino.DsHorario = (string)row["DsHorario"];
                    horarioTreino.DiaDaSemana = (int)row["DiaDaSemana"];
                    horarioTreino.HoraInicio = (TimeSpan)row["HoraInicio"];
                    horarioTreino.HoraFim = (TimeSpan)row["HoraFim"];
                    horarioTreino.IdPersonal = (int)row["IdPersonal"];
                }
            }
            return horarioTreino;
        }
    }
}
