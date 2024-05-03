using BusinessLogic;
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
    public class EspecialidadeBL
    {
        private readonly EspecialidadeDAL _especialidadeDAL = new EspecialidadeDAL();
        public EspecialidadeBL()
        {
        }

        public int InserirEspecialidade(string dsEspecialidade, int idTipoEspecialidade)
        {
            return _especialidadeDAL.InserirEspecialidade(dsEspecialidade, idTipoEspecialidade);
        }

        public int AtualizarEspecialidade(int id, string dsEspecialidade, int idTipoEspecialidade)
        {
            return _especialidadeDAL.AtualizarEspecialidade(id, dsEspecialidade, idTipoEspecialidade);
        }

        public int ExcluirEspecialidade(int id)
        {
            return _especialidadeDAL.ExcluirEspecialidade(id);
        }

        public DataTable ConsultarEspecialidades()
        {
            return _especialidadeDAL.ConsultarEspecialidades();
        }

        public DataTable ConsultarEspecialidadesPorTipoEspecialidade(int idTipoEspecialidade)
        {
            return _especialidadeDAL.ConsultarEspecialidadesPorTipoEspecialidade(idTipoEspecialidade);
        }
        public TbEspecialidade ObterEspecialidadePorId(int id)
        {
            DataTable dataTable = _especialidadeDAL.ConsultarEspecialidades(id);
            TbEspecialidade especialidade = null;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    especialidade = new TbEspecialidade();
                    especialidade.Id = (int)row["Id"];
                    especialidade.DsEspecialidade = row["DsEspecialidade"].ToString();
                    especialidade.IdTipoEspecialidade = (int)row["IdTipoEspecialidade"];
                    TipoEspecialidadeBL tipoespecialidadeBL = new TipoEspecialidadeBL();
                    especialidade.TipoEspecialidade = tipoespecialidadeBL.ConsultarTipoEspecialidadePorId(especialidade.IdTipoEspecialidade);
                    break;
                }
            }
            return especialidade;
        }


    }
}