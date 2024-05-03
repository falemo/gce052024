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
    public class TipoEspecialidadeBL
    {
        private readonly TipoEspecialidadeDAL _tipoEspecialidadeDAL = new TipoEspecialidadeDAL();

        public TipoEspecialidadeBL()
        {
        }

        public int InserirTipoEspecialidade(string dsTipo)
        {
            return _tipoEspecialidadeDAL.InserirTipoEspecialidade(dsTipo);
        }

        public int ExcluirTipoEspecialidade(int id)
        {
            return _tipoEspecialidadeDAL.ExcluirTipoEspecialidade(id);
        }

        public DataTable ConsultarTiposEspecialidades()
        {
            return _tipoEspecialidadeDAL.ConsultarTiposEspecialidades();
        }

        public TbTipoEspecialidade ConsultarTipoEspecialidadePorId(int id)
        {
            DataTable dataTable = _tipoEspecialidadeDAL.ConsultarTiposEspecialidades(id);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if ((int)dataRow["Id"] == id)
                {
                    return new TbTipoEspecialidade
                    {
                        Id = (int)dataRow["Id"],
                        DsTipo = dataRow["DsTipo"].ToString()
                    };
                }
            }

            return null;
        }
    }
 
}