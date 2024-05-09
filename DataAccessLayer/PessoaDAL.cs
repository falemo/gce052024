using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using ToolAccessLayer;
using MySql.Data.MySqlClient;
using System.Text;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class PessoaDAL
    {
        private SQLServerConexion SqlConnection = new SQLServerConexion("headin2023fabrinioandessantanalemos");

        public PessoaDAL()
        {
            SqlConnection.Open();
        }

        public int InserirPessoa(string nome, DateTime dtNascimento, string genero, string endereco, string email, string telefone, int? idCidade, int? idSituacao, string pwdUsuario, DateTime dtCadastro, bool flProfessional, bool fladministrador, int idTipoPessoa)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nome", MySqlDbType.VarChar, nome);
            SqlConnection.AdicionarParametro("@dtNascimento", MySqlDbType.DateTime, dtNascimento);
            SqlConnection.AdicionarParametro("@genero", MySqlDbType.VarChar, genero);
            SqlConnection.AdicionarParametro("@endereco", MySqlDbType.VarChar, endereco);
            SqlConnection.AdicionarParametro("@email", MySqlDbType.VarChar, email);
            SqlConnection.AdicionarParametro("@telefone", MySqlDbType.VarChar, telefone);
            SqlConnection.AdicionarParametro("@idCidade", MySqlDbType.Int64, idCidade ?? (object)DBNull.Value);
            SqlConnection.AdicionarParametro("@idSituacao", MySqlDbType.Int64, idSituacao ?? (object)DBNull.Value);
            SqlConnection.AdicionarParametro("@pwdUsuario", MySqlDbType.VarChar, pwdUsuario);
            SqlConnection.AdicionarParametro("@dtCadastro", MySqlDbType.DateTime, dtCadastro);
            SqlConnection.AdicionarParametro("@flProfessional", MySqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@fladministrador", MySqlDbType.Bit, fladministrador);
            SqlConnection.AdicionarParametro("@idTipoPessoa", MySqlDbType.Int64, idTipoPessoa);

            return SqlConnection.ExecutaAtualizacaoWithIdentity("INSERT INTO TbPessoas (nome, DtNascimento, genero, endereco, email, Telefone, idCidade, idSituacao, pwdUsuario, dtCadastro,flProfessional,fladministrador,idTipoPessoa) " +
                                              "VALUES (@nome, @dtNascimento, @genero, @endereco, @email, @telefone, @idCidade, @idSituacao, UNHEX(SHA2(@pwdUsuario, 256)), @dtCadastro,@flProfessional,@fladministrador,@idTipoPessoa)");
        }

        public int AtualizarPessoa(int id, string nome, DateTime dtNascimento, string genero, string endereco, string telefone, int? idCidade, int? idSituacao, DateTime dtCadastro, bool flProfessional, bool fladministrador, int idTipoPessoa)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@nome", MySqlDbType.VarChar, nome);
            SqlConnection.AdicionarParametro("@dtNascimento", MySqlDbType.DateTime, dtNascimento);
            SqlConnection.AdicionarParametro("@genero", MySqlDbType.VarChar, genero);
            SqlConnection.AdicionarParametro("@endereco", MySqlDbType.VarChar, endereco);
          //  SqlConnection.AdicionarParametro("@email", MySqlDbType.VarChar, email);
            SqlConnection.AdicionarParametro("@telefone", MySqlDbType.VarChar, telefone);
            SqlConnection.AdicionarParametro("@idCidade", MySqlDbType.Int64, idCidade ?? (object)DBNull.Value);
            SqlConnection.AdicionarParametro("@idSituacao", MySqlDbType.Int64, idSituacao ?? (object)DBNull.Value);
            SqlConnection.AdicionarParametro("@dtCadastro", MySqlDbType.DateTime, dtCadastro);
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            SqlConnection.AdicionarParametro("@flProfessional", MySqlDbType.Bit, flProfessional);
            SqlConnection.AdicionarParametro("@fladministrador", MySqlDbType.Bit, fladministrador);
            SqlConnection.AdicionarParametro("@idTipoPessoa", MySqlDbType.Int64, idTipoPessoa);
            
            return SqlConnection.ExecutaAtualizacao("UPDATE TbPessoas SET nome = @nome, DtNascimento = @dtNascimento, genero = @genero, " +
                                                     "endereco = @endereco, Telefone = @telefone, " +
                                                     "idCidade = @idCidade, idSituacao = @idSituacao,  " +
                                                     "dtCadastro = @dtCadastro, flProfessional = @flProfessional, fladministrador = @fladministrador, idTipoPessoa=@idTipoPessoa WHERE Id = @id");
        }
        public int AtualizarSenha(int id, string email, string pwdUsuario)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@pwdUsuario", MySqlDbType.VarChar, pwdUsuario);
            SqlConnection.AdicionarParametro("@email", MySqlDbType.VarChar, email);
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbPessoas SET pwdUsuario = UNHEX(SHA2(@pwdUsuario, 256)) " +
                                                     "WHERE Id = @id or email = @email");
        }
        public DataTable GetPessoaPWD(int id, string email, string pwdUsuario)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@email", MySqlDbType.VarChar, email);
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);

            // Criptografar a senha fornecida com SHA-256
            byte[] senhaCriptografada = GerarHashSHA256(pwdUsuario);

            // Converter o hash criptografado em uma string hexadecimal
            string senhaHexadecimal = BitConverter.ToString(senhaCriptografada).Replace("-", "");

            SqlConnection.AdicionarParametro("@pwdUsuario", MySqlDbType.VarBinary, senhaCriptografada);

            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPessoas WHERE (email = @email OR id = @id) And (@pwdUsuario =  pwdUsuario)");
        }
       
        private byte[] GerarHashSHA256(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                return bytes;
            }
        }

        public int AtualizarSituacao(int id, int idSituacao)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@idSituacao", MySqlDbType.Int64, idSituacao);
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaAtualizacao("UPDATE TbPessoas SET idSituacao = @idSituacao " +
                                                                    "WHERE Id = @id");
        }

        public int ExcluirPessoa(int id)
        {
            SqlConnection.LimparParametros();
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
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
            SqlConnection.AdicionarParametro("@id", MySqlDbType.Int64, id);
            return SqlConnection.ExecutaConsulta("SELECT * FROM TbPessoas WHERE Id = @id");
        }
        // Adicione outros métodos conforme necessário
    }
}
