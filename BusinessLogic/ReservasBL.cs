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
    public class ReservasBL
    {
        private readonly ReservasDAL _reservasDAL = new ReservasDAL();

        public ReservasBL()
        {
        }

        public int InserirReservas(int idaluno, int idPersonal, DateTime dtReserva, DateTime dtregistro, int idHorarioTreino, int nrAvaliacao, bool flRealizado)
        {
            return _reservasDAL.InserirReservas(idaluno, idPersonal, dtReserva, dtregistro, idHorarioTreino, nrAvaliacao, flRealizado);
        }

        public int ExcluirReservas(int id)
        {
            return _reservasDAL.ExcluirReservas(id);
        }

        public DataTable ConsultarReservas()
        {
            return _reservasDAL.ConsultarReservas();
        }

        public DataTable ConsultarReservasPorAluno(int idaluno)
        {
            return _reservasDAL.ConsultarReservasPorAluno(idaluno);
        }

        public TbReservas ConsultarReservaPorId(int id)
        {
            DataTable dataTable = _reservasDAL.ConsultarReservas();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if ((int)dataRow["Id"] == id)
                {
                    return new TbReservas
                    {
                        Id = (int)dataRow["Id"],
                        Idaluno = (int)dataRow["IdAluno"],
                        IdPersonal = (int)dataRow["IdPersonal"],
                        DtReserva = (DateTime) dataRow["DtReserva"],
                        Dtregistro = (DateTime) dataRow["Dtregistro"],
                        IdHorarioTreino = (int)dataRow["IdHorarioTreino"],
                        NrAvaliacao = (int)dataRow["NrAvaliacao"],
                        FlRealizado = Convert.ToBoolean(dataRow["flRealizado"])
                    };
                }
            }

            return null;
        }
    }
}
