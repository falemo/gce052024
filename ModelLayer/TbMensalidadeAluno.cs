using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbMensalidadeAluno
    {
        public int Id { get; set; }
        public int IdStatusPagamento { get; set; }
        public int IdPersonal { get; set; }
        public int IdAluno { get; set; }
        public DateTime DtVencimento { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DtPagto { get; set; }
        public decimal? ValorPago { get; set; }
        public decimal? ValorDesconto { get; set; }
        public int IdPlano { get; set; }

        public TbStatusPagamento StatusPagamento { get; set; }
        public TbPersonalTrainers PersonalTrainers { get; set; }
        public TbAluno Aluno { get; set; }
        public TbPlanos Planos { get; set; }
    }

}
