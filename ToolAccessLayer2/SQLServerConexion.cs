using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolAccessLayer.Classes;
using System.Configuration;
using System.Data.SqlClient;

namespace ToolAccessLayer
{
    public class SQLServerConexion
    {
        private string clavecriptografia ="";
        private string stringcnx = "";
        #region Objetos Estáticos
        // Objeto Connection para obter acesso ao SQL Server
        public static SqlConnection sqlconnection = new SqlConnection();
        // Objeto SqlCommand para executar os com
        public static SqlCommand comando = new SqlCommand();
        // Objeto SqlParameter para adicionar os parâmetros necessários em nossas consultas
        public static SqlParameter parametro = new SqlParameter();
        #endregion
        #region Abre Conexão
        public void Open()
        {
            if (sqlconnection.State == ConnectionState.Closed)
            {
                sqlconnection.Open();
            }
        }
        #endregion
        #region Fecha Conexão
        public void Close()
        {
            sqlconnection.Close();
        }
        #endregion
        public SQLServerConexion(string clave)
        {
            clavecriptografia = clave;
            stringcnx = AesEncryption.DecryptString(ConfigurationManager.ConnectionStrings["CNXSQL"].ConnectionString, clave);
            Connection(clave, 0);
        }
        public SQLServerConexion(string stringcnxs, string clave)
        {
            clavecriptografia = clave;
            stringcnx = stringcnxs;
            Connection(clave, 0);
        }
        public SQLServerConexion()
        {
        }

        public static SqlConnection Connection(string stringcnxs, string clave)
        {
            try
            {
                string conString = stringcnxs;

                sqlconnection = new SqlConnection(conString);
                if (sqlconnection.State == ConnectionState.Closed)
                {
                    sqlconnection.Open();
                }
                return sqlconnection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Connection(string clave, int nada)
        {
            try
            {
                sqlconnection = new SqlConnection(stringcnx);
                if (sqlconnection.State == ConnectionState.Closed)
                {
                    sqlconnection.Open();
                }
                comando = new SqlCommand();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static SqlConnection Connection(string clave)
        {
            try
            {
                string conString = AesEncryption.DecryptString(ConfigurationManager.ConnectionStrings["CNXSQL"].ConnectionString, clave);

                sqlconnection = new SqlConnection(conString);
                if (sqlconnection.State == ConnectionState.Closed)
                {
                    sqlconnection.Open();
                }
                return sqlconnection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static SqlConnection Connection()
        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["CNXSQL"].ConnectionString;
                sqlconnection = new SqlConnection(conString);
                if (sqlconnection.State == ConnectionState.Closed)
                {
                    sqlconnection.Open();
                }
                return sqlconnection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #region Adiciona Parâmetros 
        public void AdicionarParametro(string nome, SqlDbType tipo, int tamanho, object valor)
        {

            parametro = new SqlParameter();
            parametro.ParameterName = nome;
            parametro.SqlDbType = tipo;
            parametro.Size = tamanho;
            parametro.Value = valor;
            // Adiciona ao comando SQL o parâmetro
            comando.Parameters.Add(parametro);
        }
        #endregion.     
        #region Adiciona Parâmetros
        public void AdicionarParametro(string nome, SqlDbType tipo, object valor)
        {
            // Cria a instância do Parâmetro e adiciona os valores
            SqlParameter parametro = new SqlParameter
            {
                ParameterName = nome,
                SqlDbType = tipo,
                Value = valor
            };
            // Adiciona ao comando SQL o parâmetro
            comando.Parameters.Add(parametro);
        }
        #endregion
        #region Remove os parâmetros 
        public void RemoverParametro(string pNome)
        {
            // Verifica se existe o parâmetro
            if (comando.Parameters.Contains(pNome))
                // Se exite remove o mesmo
                comando.Parameters.Remove(pNome);
        }
        #endregion
        #region Limpar Parâmetros
        public void LimparParametros()
        {
            comando.Parameters.Clear();
        }
        #endregion
        #region Executar Consulta SQL
        public DataTable ExecutaConsulta(string sql)
        {
            try
            {
                // Pega conexão com a base SQL Server
                comando.Connection = Connection(stringcnx, clavecriptografia);
                // Adiciona a instrução SQL
                comando.CommandText = sql;
                //Executa a query sql.
                comando.ExecuteScalar();
                // Ler os dados e passa para um DataTable
                IDataReader dtreader = comando.ExecuteReader();
                DataTable dtresult = new DataTable();

                dtresult.Load(dtreader);
                // Fecha a conexão
                sqlconnection.Close();
                // Retorna o DataTable com os dados da consulta
                return dtresult;

            }
            catch (Exception )
            {
                // Retorna uma exceção simples que pode ser tratada por parte do desenvolvedor
                // Exemplo: if (ex.Message.toString().Contains(‘Networkig’)) 
                // Exemplo throw new Exception(‘Problema de rede detectado’);                        
                throw;
            }
            finally
            {
                if (comando != null)
                    comando.Dispose();
            }
        }
        #endregion
        #region Executa uma instrução SQL: INSERT, UPDATE e DELETE
        public int ExecutaAtualizacao(string sql)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                //comando = new SqlCommand(sql, connection());
                //comando = new SqlCommand(sql, Connection(stringcnx, clavecriptografia));
                comando.Connection = Connection(stringcnx, clavecriptografia);
                comando.CommandText = sql;
                //Executa a query sql.
                int result = comando.ExecuteNonQuery();
                sqlconnection.Close();
                // Retorna a quantidade de linhas afetadas
                return result;
            }
            catch (Exception )
            {
                // Retorna uma exceção simples que pode ser tratada por parte do desenvolvedor
                throw;
            }
            finally
            {
                if (comando != null)
                    comando.Dispose();
            }
        }
        public int ExecutaAtualizacaoWithIdentity(string sql)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                //comando = new SqlCommand(sql, Connection(stringcnx, clavecriptografia));
                comando.Connection = Connection(stringcnx, clavecriptografia);

                int index = sql.IndexOf("VALUES");

                string novoComandoSql = sql.Insert(index, " OUTPUT INSERTED.Id ");

                comando.CommandText = novoComandoSql;

                //Executa a query sql.
                int id = (int)comando.ExecuteScalar();

                //int id = (int)comando.GetGeneratedKeys().GetValue(0);

                sqlconnection.Close();
                // Retorna a quantidade de linhas afetadas
                return id;


            }
            catch (Exception)
            {
                // Retorna uma exceção simples que pode ser tratada por parte do desenvolvedor
                throw;
            }
            finally
            {
                if (comando != null)
                    comando.Dispose();
            }
        }
        public int ExecutaAtualizacaoWithIdentityColuna(string sql, string nombrecolunaid)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                //comando = new SqlCommand(sql, Connection(stringcnx, clavecriptografia));
                comando.Connection = Connection(stringcnx, clavecriptografia);

                int index = sql.IndexOf("VALUES");

                string novoComandoSql = sql.Insert(index, " OUTPUT INSERTED." + nombrecolunaid + " ");

                comando.CommandText = novoComandoSql;

                //Executa a query sql.
                int id = (int)comando.ExecuteScalar();

                //int id = (int)comando.GetGeneratedKeys().GetValue(0);

                sqlconnection.Close();
                // Retorna a quantidade de linhas afetadas
                return id;


            }
            catch (Exception)
            {
                // Retorna uma exceção simples que pode ser tratada por parte do desenvolvedor
                throw;
            }
            finally
            {
                if (comando != null)
                    comando.Dispose();
            }
        }

        #endregion
        #region Executar Consulta SQL Descriptografia
        public DataTable ExecutaConsulta(string stringcnxs, string sql)
        {
            try
            {
                // Pega conexão com a base SQL Server
                comando.Connection = Connection(stringcnx, clavecriptografia);
                // Adiciona a instrução SQL
                comando.CommandText = sql;
                //Executa a query sql.
                comando.ExecuteScalar();
                // Ler os dados e passa para um DataTable
                IDataReader dtreader = comando.ExecuteReader();
                DataTable dtresult = new DataTable();

                dtresult.Load(dtreader);
                // Fecha a conexão
                sqlconnection.Close();
                // Retorna o DataTable com os dados da consulta
                return dtresult;

            }
            catch (Exception)
            {
                // Retorna uma exceção simples que pode ser tratada por parte do desenvolvedor
                // Exemplo: if (ex.Message.toString().Contains(‘Networkig’)) 
                // Exemplo throw new Exception(‘Problema de rede detectado’);                        
                throw;
            }
            finally
            {
                if (comando != null)
                    comando.Dispose();
            }
        }
        #endregion
        #region Executa uma instrução SQL: INSERT, UPDATE e DELETE
        public int ExecutaAtualizacao(string stringcnxs, string sql)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                //comando = new SqlCommand(sql, connection());
                comando.Connection = Connection(stringcnx, clavecriptografia);
                comando.CommandText = sql;
                //Executa a query sql.
                int result = comando.ExecuteNonQuery();
                sqlconnection.Close();
                // Retorna a quantidade de linhas afetadas
                return result;
            }
            catch (Exception)
            {
                // Retorna uma exceção simples que pode ser tratada por parte do desenvolvedor
                throw;
            }
            finally
            {
                if (comando != null)
                    comando.Dispose();
            }
        }
        public int ExecutaAtualizacaoWithIdentity(string stringcnxs, string sql)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                //comando = new SqlCommand(sql, connection());
                comando.Connection = Connection(stringcnx, clavecriptografia);
                comando.CommandText = sql;
                //Executa a query sql.
                int result = (int)comando.ExecuteScalar();
                sqlconnection.Close();
                // Retorna a quantidade de linhas afetadas
                return result;



            }
            catch (Exception)
            {
                // Retorna uma exceção simples que pode ser tratada por parte do desenvolvedor
                throw;
            }
            finally
            {
                if (comando != null)
                    comando.Dispose();
            }
        }
        #endregion

    }
}
