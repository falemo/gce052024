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
    public class MensalidadeAlunoBL
    {
        private readonly MensalidadeAlunoDAL _mensalidadeAlunoDAL = new MensalidadeAlunoDAL();
        public MensalidadeAlunoBL()
        {
        }
        public int InserirMensalidadeAluno(int idStatusPagamento, int idPersonal, int idAluno, DateTime dtVencimento, float valor, DateTime? dtPagto, float? valorPago, float? valorDesconto, int idPlano)
        {
            return _mensalidadeAlunoDAL.InserirMensalidadeAluno(idStatusPagamento, idPersonal, idAluno, dtVencimento, valor, dtPagto, valorPago, valorDesconto, idPlano);
        }

        public int ExcluirMensalidadeAluno(int id)
        {
            return _mensalidadeAlunoDAL.ExcluirMensalidadeAluno(id);
        }

        public DataTable ConsultarMensalidadesAlunos()
        {
            return _mensalidadeAlunoDAL.ConsultarMensalidadesAlunos();
        }

        public DataTable ConsultarMensalidadesAlunosPorAluno(int idAluno)
        {
            return _mensalidadeAlunoDAL.ConsultarMensalidadesAlunosPorAluno(idAluno);
        }

        public TbMensalidadeAluno ObterMensalidadeAluno(int id)
        {
            DataTable dataTable = _mensalidadeAlunoDAL.ConsultarMensalidadesAlunos(id);
            TbMensalidadeAluno mensalidadeAluno = new TbMensalidadeAluno();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    mensalidadeAluno.Id = (int)row["Id"];
                    mensalidadeAluno.IdStatusPagamento = (int)row["IdStatusPagamento"];
                    mensalidadeAluno.IdPersonal = (int)row["IdPersonal"];
                    mensalidadeAluno.IdAluno = (int)row["IdAluno"];
                    mensalidadeAluno.DtVencimento = (DateTime)row["DtVencimento"];
                    mensalidadeAluno.Valor = (decimal)row["Valor"];
                    mensalidadeAluno.DtPagto = (DateTime?)row["DtPagto"];
                    mensalidadeAluno.ValorPago = (decimal?)row["ValorPago"];
                    mensalidadeAluno.ValorDesconto = (decimal?)row["ValorDesconto"];
                    mensalidadeAluno.IdPlano = (int)row["IdPlano"];
                }
            }
            return mensalidadeAluno;
        }
    }
}
