using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolAccessLayer;
using ModelLayer;
using DataAccessLayer;
using BusinessLogic;

namespace BusinessLayer
{
    public class AlunoBL
    {
        private AlunoDAL AlunoDAL = new AlunoDAL();

        public AlunoBL()
        {
        }

        public int InserirAluno(DateTime dtAluno, int idSituacao, int? idPessoa)
        {
            return AlunoDAL.InserirAluno(dtAluno, idSituacao, idPessoa);
        }

        public int AtualizarAluno(int id, DateTime dtAluno, int idSituacao, int? idPessoa)
        {
            return AlunoDAL.AtualizarAluno(id, dtAluno, idSituacao, idPessoa);
        }

        public int ExcluirAluno(int id)
        {
            return AlunoDAL.ExcluirAluno(id);
        }

        public DataTable ConsultarAlunos()
        {
            return AlunoDAL.ConsultarAlunos();
        }

        public TbAluno ObterAluno(int id)
        {
            DataTable dataTable = AlunoDAL.ConsultarAlunos(id);
            TbAluno aluno = new TbAluno();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Id"].Equals(id))
                {
                    aluno.Id = (int)row["Id"];
                    aluno.Dtaluno = (DateTime)row["Dtaluno"];
                    SituacaoBL situacaoBL = new SituacaoBL();
                    aluno.IdSituacao = (int)row["IdSituacao"];
                    aluno.Situacao = situacaoBL.ConsultarSituacaoPorId(aluno.IdSituacao);
                    aluno.IdPessoa = (int)row["IdPessoa"];
                    PessoaBL pessoalBL = new PessoaBL();
                    aluno.Pessoa = pessoalBL.ObterPessoa(aluno.IdPessoa);
                }
            }
            return aluno;
        }
    }
}