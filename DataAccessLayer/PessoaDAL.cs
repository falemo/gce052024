using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;
using System.Text;

namespace DataAccessLayer
{
    public class PessoaDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public PessoaDAL()
        {
            SqlConnection.Open();
        }

        public int InserirPessoa(string nome, DateTime dtNascimento, string genero, string endereco, string email, string telefone, int? idCidade, int? idSituacao, string pwdUsuario, DateTime dtCadastro, bool flProfessional, bool fladministrador)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nome", SqlDbType.VarChar, nome);
            SqlConnection.AdicionarParametro("@dtNascimento", SqlDbType.SmallDateTime, dtNascimento);
            SqlConnection.AdicionarParametro("@genero", SqlDbType.VarChar, genero);
            SqlConnection.AdicionarParametro("@endereco", SqlDbType.VarChar, endereco);
            SqlConnection.AdicionarParametro("@email", SqlDbType.VarChar, email);
            SqlConnection.AdicionarParametro("@telefone", SqlDbType.VarChar, telefone);
            SqlConnection.AdicionarParametro("@idCidade", SqlDbType.Int, idCidade ?? (object)DBNull.Value);
            SqlConnection.AdicionarParametro("@idSituacao", SqlDbType.Int, idSituacao ?? (object)DBNull.Value);
            SqlConnection.AdicionarParametro("@pwdUsuario", SqlDbType.VarChar, pwdUsuario);
            SqlConnection.AdicionarParametro("@dtCadastro", SqlDbType.SmallDateTime, dtCadastro);
            SqlConnection.AdicionarParametro("@flProfessional", SqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@fladministrador", SqlDbType.Bit, fladministrador);
            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbPessoas (nome, DtNascimento, genero, endereco, email, Telefone, idCidade, idSituacao, pwdUsuario, dtCadastro,flProfessional,fladministrador) " +
                                              "VALUES (@nome, @dtNascimento, @genero, @endereco, @email, @telefone, @idCidade, @idSituacao, PWDENCRYPT(@pwdUsuario), @dtCadastro,@flProfessional,@fladministrador)");
        }

        public int AtualizarPessoa(int id, string nome, DateTime dtNascimento, string genero, string endereco, string telefone, int? idCidade, int? idSituacao, DateTime dtCadastro, bool flProfessional, bool fladministrador)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nome", SqlDbType.VarChar, nome);
            SqlConnection.AdicionarParametro("@dtNascimento", SqlDbType.SmallDateTime, dtNascimento);
            SqlConnection.AdicionarParametro("@genero", SqlDbType.VarChar, genero);
            SqlConnection.AdicionarParametro("@endereco", SqlDbType.VarChar, endereco);
          //  SqlConnection.AdicionarParametro("@email", SqlDbType.VarChar, email);
            SqlConnection.AdicionarParametro("@telefone", SqlDbType.VarChar, telefone);
            SqlConnection.AdicionarParametro("@idCidade", SqlDbType.Int, idCidade ?? (object)DBNull.Value);
            SqlConnection.AdicionarParametro("@idSituacao", SqlDbType.Int, idSituacao ?? (object)DBNull.Value);
            SqlConnection.AdicionarParametro("@dtCadastro", SqlDbType.SmallDateTime, dtCadastro);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            SqlConnection.AdicionarParametro("@flProfessional", SqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@fladministrador", SqlDbType.Bit, fladministrador);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbPessoas SET nome = @nome, DtNascimento = @dtNascimento, genero = @genero, " +
                                                     "endereco = @endereco, Telefone = @telefone, " +
                                                     "idCidade = @idCidade, idSituacao = @idSituacao,  " +
                                                     "dtCadastro = @dtCadastro, flProfessional = @flProfessional, fladministrador = @fladministrador WHERE Id = @id");
        }
        public int AtualizarSenha(int id, string email, string pwdUsuario)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@pwdUsuario", SqlDbType.VarChar, pwdUsuario);
            SqlConnection.AdicionarParametro("@email", SqlDbType.VarChar, email);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbPessoas SET pwdUsuario = PWDENCRYPT(@pwdUsuario) " +
                                                     "WHERE Id = @id or email = @email");
        }
        public DataTable GetPessoaPWD(int id, string email, string pwdUsuario)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@pwdUsuario", SqlDbType.VarChar, pwdUsuario);
            SqlConnection.AdicionarParametro("@email", SqlDbType.VarChar, email);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPessoas WHERE (email = @email OR id = @id) And PWDCOMPARE(@pwdUsuario,pwdUsuario) = 1");
        }


        public int AtualizarSituacao(int id, int idSituacao)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idSituacao", SqlDbType.Int, idSituacao);
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbPessoas SET idSituacao = @idSituacao " +
                                                                    "WHERE Id = @id");
        }

        public int ExcluirPessoa(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaAtualizacao("DELETE FROM TbPessoas WHERE Id = @id");
        }

        public DataTable ConsultarPessoas()
        {
            SqlConnection.LimparParametros();
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPessoas");
        }
        public DataTable ConsultarPessoas(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", SqlDbType.Int, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPessoas WHERE Id = @id");
        }
        // Adicione outros métodos conforme necessário
    }
}
