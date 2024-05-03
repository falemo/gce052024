using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolAccessLayer.Classes;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql;


namespace ToolAccessLayer
{
    public class SQLServerConexion
    {
        private string clavecriptografia ="";
        private string stringcnx = "";
        #region Objetos Estáticos
        // Objeto Connection para obter acesso ao SQL Server
        public static MySqlConnection MySqlConnection = new MySqlConnection();
        // Objeto SqlCommand para executar os com
        public static MySqlCommand comando = new MySqlCommand();
        // Objeto MySqlParameter para adicionar os parâmetros necessários em nossas consultas
        public static MySqlParameter parametro = new MySqlParameter();
        #endregion
        #region Abre Conexão
        public void Open()
        {
            if (MySqlConnection.State == ConnectionState.Closed)
            {
                MySqlConnection.Open();
            }
        }
        #endregion
        #region Fecha Conexão
        public void Close()
        {
            MySqlConnection.Close();
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

        public static MySqlConnection Connection(string stringcnxs, string clave)
        {
            try
            {
                string conString = stringcnxs;

                MySqlConnection = new MySqlConnection(conString);
                if (MySqlConnection.State == ConnectionState.Closed)
                {
                    MySqlConnection.Open();
                }
                return MySqlConnection;
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
                MySqlConnection = new MySqlConnection(stringcnx);
                if (MySqlConnection.State == ConnectionState.Closed)
                {
                    MySqlConnection.Open();
                }
                comando = new MySqlCommand();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static MySqlConnection Connection(string clave)
        {
            try
            {
                string conString = AesEncryption.DecryptString(ConfigurationManager.ConnectionStrings["CNXSQL"].ConnectionString, clave);

                MySqlConnection = new MySqlConnection(conString);
                if (MySqlConnection.State == ConnectionState.Closed)
                {
                    MySqlConnection.Open();
                }
                return MySqlConnection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static MySqlConnection Connection()
        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["CNXSQL"].ConnectionString;
                MySqlConnection = new MySqlConnection(conString);
                if (MySqlConnection.State == ConnectionState.Closed)
                {
                    MySqlConnection.Open();
                }
                return MySqlConnection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #region Adiciona Parâmetros 
        public void AdicionarParametro(string nome, MySqlDbType tipo, int tamanho, object valor)
        {

            parametro = new MySqlParameter();
            parametro.ParameterName = nome;
            parametro.MySqlDbType = tipo;
            parametro.Size = tamanho;
            parametro.Value = valor;
            // Adiciona ao comando SQL o parâmetro
            comando.Parameters.Add(parametro);
        }
        #endregion.     
        #region Adiciona Parâmetros
        public void AdicionarParametro(string nome, MySqlDbType tipo, object valor)
        {
            // Cria a instância do Parâmetro e adiciona os valores
            MySqlParameter parametro = new MySqlParameter
            {
                ParameterName = nome,
                MySqlDbType = tipo,
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
                MySqlConnection.Close();
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
                MySqlConnection.Close();
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

                string novoComandoSql = sql.Insert(index, " RETURNING LAST_INSERT_ID() ");

                comando.CommandText = novoComandoSql;

                comando.ExecuteNonQuery();

                //Executa a query sql.
                int id = (int)comando.LastInsertedId;

                //int id = (int)comando.GetGeneratedKeys().GetValue(0);

                MySqlConnection.Close();
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

                string novoComandoSql = sql.Insert(index, " RETURNING LAST_INSERT_ID() ");

                comando.CommandText = novoComandoSql;

                comando.ExecuteNonQuery();

                //Executa a query sql.
                int id = (int)comando.LastInsertedId;

                //int id = (int)comando.GetGeneratedKeys().GetValue(0);

                MySqlConnection.Close();
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
                MySqlConnection.Close();
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
                MySqlConnection.Close();
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
                int result = (int)comando.ExecuteNonQuery();
                MySqlConnection.Close();
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
