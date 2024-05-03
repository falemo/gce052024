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
    public class PlanosBL
    {
        private readonly PlanosDAL _planosDAL = new PlanosDAL();

        public PlanosBL()
        {
        }

        public int InserirPlanos(string dsPlano, int idTipoPlano, int qtdDiasPlano, bool Flativo, int diasParaPagamento, int idPersonal, bool flHabilitado)
        {
            return _planosDAL.InserirPlanos(dsPlano, idTipoPlano, qtdDiasPlano, Flativo, diasParaPagamento, idPersonal, flHabilitado);
        }

        public int ExcluirPlanos(int id)
        {
            return _planosDAL.ExcluirPlanos(id);
        }

        public DataTable ConsultarPlanos()
        {
            return _planosDAL.ConsultarPlanos();
        }

        public DataTable ConsultarPlanosPorPersonal(int idPersonal)
        {
            return _planosDAL.ConsultarPlanosPorPersonal(idPersonal);
        }

        public TbPlanos ConsultarPlanoPorId(int id)
        {
            DataTable dataTable = _planosDAL.ConsultarPlanos(id);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if ((int)dataRow["Id"] == id)
                {
                    return new TbPlanos
                    {
                        Id = (int) dataRow["Id"],
                        DsPlano = dataRow["DsPlano"].ToString(),
                        IdTipoPlano = (int)(int)dataRow["IdTipoPlano"],
                        QtdDiasPlano = (int)dataRow["QtdDiasPlano"],
                        Flativo = Convert.ToBoolean(dataRow["Flativo"]),
                        DiasParaPagamento = (int)dataRow["DiasParaPagamento"],
                        IdPersonal = (int)dataRow["IdPersonal"],
                        FlHabilitado = Convert.ToBoolean(dataRow["flHabilitado"])
                    };
                }
            }

            return null;
        }
    }
}