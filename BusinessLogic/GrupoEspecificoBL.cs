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
    public class GrupoEspecificoBL
    {
        private readonly GrupoEspecificoDAL _grupoEspecificoDAL = new GrupoEspecificoDAL();

        public GrupoEspecificoBL()
        {
        }
        public int InserirGrupoEspecifico(string dsGrupo, bool flNumerico)
        {
            return _grupoEspecificoDAL.InserirGrupoEspecifico(dsGrupo, flNumerico);
        }

        public int AtualizarGrupoEspecifico(int id, string dsGrupo, bool flNumerico)
        {
            return _grupoEspecificoDAL.AtualizarGrupoEspecifico(id, dsGrupo, flNumerico);
        }

        public int ExcluirGrupoEspecifico(int id)
        {
            return _grupoEspecificoDAL.ExcluirGrupoEspecifico(id);
        }

        public DataTable ConsultarGruposEspecificos()
        {
            return _grupoEspecificoDAL.ConsultarGruposEspecificos();
        }

        public TbGrupoEspecifico ObterGrupoEspecifico(int id)
        {
            DataTable dataTable = _grupoEspecificoDAL.ConsultarGruposEspecificos(id);
            TbGrupoEspecifico grupoEspecifico = new TbGrupoEspecifico();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    grupoEspecifico.Id = (int)row["Id"];
                    grupoEspecifico.DsGrupo = (string)row["DsGrupo"];
                    grupoEspecifico.FlNumerico = (bool)row["FlNumerico"];
                }
            }
            return grupoEspecifico;
        }
    }
}
