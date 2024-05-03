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
    public class TipoMensalidadeBL
    {
        private readonly TipoMensalidadeDAL _tipoMensalidadeDAL = new TipoMensalidadeDAL();

        public TipoMensalidadeBL()
        {
        }

        public int InserirTipoMensalidade(string dsTipo, int diasFaturacao, bool flHabilitado)
        {
            return _tipoMensalidadeDAL.InserirTipoMensalidade(dsTipo, diasFaturacao, flHabilitado);
        }

        public int ExcluirTipoMensalidade(int id)
        {
            return _tipoMensalidadeDAL.ExcluirTipoMensalidade(id);
        }

        public int AtualizarTipoMensalidade(int id,string dsTipo, int diasFaturacao, bool flHabilitado)
        {
            return _tipoMensalidadeDAL.AtualizarTipoMensalidade(id,dsTipo, diasFaturacao, flHabilitado);
        }

        public DataTable ConsultarTiposMensalidades()
        {
            return _tipoMensalidadeDAL.ConsultarTiposMensalidades();
        }

        public TbTipoMensalidade ConsultarTipoMensalidadePorId(int id)
        {
            DataTable dataTable = _tipoMensalidadeDAL.ConsultarTiposMensalidades(id);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if ((int)dataRow["Id"] == id)
                {
                    return new TbTipoMensalidade
                    {
                        Id = (int)dataRow["Id"],
                        DsTipo = dataRow["DsTipo"].ToString(),
                        DiasFaturacao = (int)dataRow["DiasFaturacao"],
                        FlHabilitado = Convert.ToBoolean(dataRow["flHabilitado"])
                    };
                }
            }

            return null;
        }
    }

}