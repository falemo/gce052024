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
    public class TipoPlanosBL
    {
        private readonly TipoPlanosDAL _tipoPlanosDAL = new TipoPlanosDAL();

        public TipoPlanosBL()
        {
        }

        public int InserirTipoPlanos(string dsTipo, int NrNivel, int idPersonal)
        {
            return _tipoPlanosDAL.InserirTipoPlanos(dsTipo, NrNivel, idPersonal);
        }

        public int ExcluirTipoPlanos(int id)
        {
            return _tipoPlanosDAL.ExcluirTipoPlanos(id);
        }

        public DataTable ConsultarTiposPlanos()
        {
            return _tipoPlanosDAL.ConsultarTiposPlanos();
        }

        public TbTipoPlanos ConsultarTipoPlanosPorId(int id)
        {
            DataTable dataTable = _tipoPlanosDAL.ConsultarTiposPlanos(id);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if ((int)dataRow["Id"] == id)
                {
                    return new TbTipoPlanos
                    {
                        Id = (int)dataRow["Id"],
                        DsTipo = dataRow["DsTipo"].ToString(),
                        NrNivel = (int)dataRow["NrNivel"],
                        IdPersonal = (int)dataRow["idPersonal"]
                    };
                }
            }

            return null;
        }
    }

}