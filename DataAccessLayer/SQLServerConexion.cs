using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using ModelLayer;
using ToolAccessLayer;


namespace DataAccessLayer
{
    public class SQLServerConexion 
    {

        private MySQLS mysqls;

        //private MySQLS clavecriptografia = "";
        //private string stringcnx = "";

        #region Objetos Estáticos
        // Objeto Connection para obter acesso ao SQL Server
        //public static MySqlConnection MySqlConnection = new MySqlConnection();
        // Objeto SqlCommand para executar os com
        //public static MySqlCommand comando = new MySqlCommand();
        // Objeto MySqlParameter para adicionar os parâmetros necessários em nossas consultas
        //public static MySqlParameter parametro = new MySqlParameter();
        #endregion
        #region Abre Conexão
        public void Open()
        {
            try
            {
                if (mysqls.MySqlConnection.State == ConnectionState.Closed)
                {
                    mysqls.MySqlConnection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        #endregion
        #region Fecha Conexão
        public void Close()
        {
            try
            {
                mysqls.MySqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        #endregion
        public SQLServerConexion(string clave)
        {
            try
            {
                mysqls = new MySQLS();
                Funcoes.LogError(" mysqls = new MySQLS();", "");
                mysqls.Clavecriptografia = "";
                mysqls.Stringcnx = "";
                mysqls.MySqlConnection = new MySqlConnection();
                Funcoes.LogError("  mysqls.MySqlConnection = new MySqlConnection();", "");
                mysqls.comando = new MySqlCommand();
                mysqls.parametro = new MySqlParameter();
                Funcoes.LogError("mysqls.parametro = new MySqlParameter();", "");
                mysqls.Clavecriptografia = clave;
                mysqls.Stringcnx = AesEncryption.DecryptString(ConfigurationManager.ConnectionStrings["CNXSQL"].ConnectionString, mysqls.Clave);
                Funcoes.LogError("AesEncryption.DecryptString", mysqls.Stringcnx);
                Connection(clave, 0);
                Funcoes.LogError("Connection(clave, 0)", "");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        public SQLServerConexion()
        {
            try
            {
                mysqls = new MySQLS();
                Funcoes.LogError(" mysqls = new MySQLS();", "");
                mysqls.Clavecriptografia = "";
                mysqls.Stringcnx = "";
                mysqls.MySqlConnection = new MySqlConnection();
                Funcoes.LogError("  mysqls.MySqlConnection = new MySqlConnection();", "");
                mysqls.comando = new MySqlCommand();
                mysqls.parametro = new MySqlParameter();
                Funcoes.LogError("mysqls.parametro = new MySqlParameter();", "");
                mysqls.Clavecriptografia = mysqls.Clave;
                mysqls.Stringcnx = AesEncryption.DecryptString(ConfigurationManager.ConnectionStrings["CNXSQL"].ConnectionString, mysqls.Clave);
                Funcoes.LogError("AesEncryption.DecryptString", mysqls.Stringcnx);
                Connection(mysqls.Clave, 0);;
                Funcoes.LogError("Connection(clave, 0)", "");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        public SQLServerConexion(string stringcnxs, string clave)
        {
            try
            {
                mysqls = new MySQLS();
                mysqls.Clavecriptografia = "";
                mysqls.Stringcnx = "";
                mysqls.MySqlConnection = new MySqlConnection();
                mysqls.comando = new MySqlCommand();
                mysqls.parametro = new MySqlParameter();

                mysqls.Clavecriptografia = clave;
                mysqls.Stringcnx = stringcnxs;
                Connection(clave, 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        public static MySqlConnection Connection(string stringcnxs, string clave)
        {
            try
            {
                Funcoes.LogError("Connection(string clave, int nada)", "");
                string conString = stringcnxs;

                MySqlConnection mySqlConnection = new MySqlConnection(conString);
                Funcoes.LogError("MySqlConnection = new MySqlConnection(conString);", "");
                if (mySqlConnection.State == ConnectionState.Closed)
                {
                    Funcoes.LogError("MySqlConnection.State == ConnectionState.Closed", "");
                    mySqlConnection.Open();
                    Funcoes.LogError(" MySqlConnection.Open();", "");
                }
                return mySqlConnection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        public void Connection(string clave, int nada)
        {
            try
            {
                Funcoes.LogError("Connection(string clave, int nada)", "");
                mysqls.MySqlConnection = new MySqlConnection(mysqls.Stringcnx);
                Funcoes.LogError("MySqlConnection = new MySqlConnection(conString);", "");
                if (mysqls.MySqlConnection.State == ConnectionState.Closed)
                {
                    Funcoes.LogError("MySqlConnection.State == ConnectionState.Closed", "");
                    mysqls.MySqlConnection.Open();
                    Funcoes.LogError(" MySqlConnection.Open();", "");
                }
                mysqls.comando = new MySqlCommand();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        public static MySqlConnection Connection(string clave)
        {
            try
            {
                string conString = AesEncryption.DecryptString(ConfigurationManager.ConnectionStrings["CNXSQL"].ConnectionString, clave);

                MySqlConnection MySqlConnection = new MySqlConnection(conString);
                if (MySqlConnection.State == ConnectionState.Closed)
                {
                    MySqlConnection.Open();
                }
                return MySqlConnection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        public static MySqlConnection Connection()
        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["CNXSQL"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conString);
                if (mySqlConnection.State == ConnectionState.Closed)
                {
                    mySqlConnection.Open();
                }
                return mySqlConnection;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        #region Adiciona Parâmetros 
        public void AdicionarParametro(string nome, MySqlDbType tipo, int tamanho, object valor)
        {
            try { 

                mysqls.parametro = new MySqlParameter();
                mysqls.parametro.ParameterName = nome;
                mysqls.parametro.MySqlDbType = tipo;
                mysqls.parametro.Size = tamanho;
                mysqls.parametro.Value = valor;
                // Adiciona ao comando SQL o parâmetro
                mysqls.comando.Parameters.Add(mysqls.parametro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        #endregion.     
        #region Adiciona Parâmetros
        public void AdicionarParametro(string nome, MySqlDbType tipo, object valor)
        {
            try { 
            // Cria a instância do Parâmetro e adiciona os valores
            MySqlParameter parametro = new MySqlParameter
            {
                ParameterName = nome,
                MySqlDbType = tipo,
                Value = valor
            };
                // Adiciona ao comando SQL o parâmetro
                mysqls.comando.Parameters.Add(parametro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        #endregion
        #region Remove os parâmetros 
        public void RemoverParametro(string pNome)
        {
            try { 
            // Verifica se existe o parâmetro
            if (mysqls.comando.Parameters.Contains(pNome))
                    // Se exite remove o mesmo
                    mysqls.comando.Parameters.Remove(pNome);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "- Rastreio: " + ex.Source + "  - StackTracert:" + ex.StackTrace);
            }
        }
        #endregion
        #region Limpar Parâmetros
        public void LimparParametros()
        {
            mysqls.comando.Parameters.Clear();
        }
        #endregion
        #region Executar Consulta SQL
        public DataTable ExecutaConsulta(string sql)
        {
            try
            {
                // Pega conexão com a base SQL Server
                mysqls.comando.Connection = Connection(mysqls.Stringcnx, mysqls.Clavecriptografia);
                // Adiciona a instrução SQL
                mysqls.comando.CommandText = sql;
                //Executa a query sql.
                mysqls.comando.ExecuteScalar();
                // Ler os dados e passa para um DataTable
                IDataReader dtreader = mysqls.comando.ExecuteReader();
                DataTable dtresult = new DataTable();

                dtresult.Load(dtreader);
                // Fecha a conexão
                mysqls.MySqlConnection.Close();
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
                if (mysqls.comando != null)
                    mysqls.comando.Dispose();
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
                mysqls.comando.Connection = Connection(mysqls.Stringcnx, mysqls.Clavecriptografia);
                mysqls.comando.CommandText = sql;
                //Executa a query sql.
                int result = mysqls.comando.ExecuteNonQuery();
                mysqls.MySqlConnection.Close();
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
                if (mysqls.comando != null)
                    mysqls.comando.Dispose();
            }
        }
        public int ExecutaAtualizacaoWithIdentity(string sql)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                //comando = new SqlCommand(sql, Connection(stringcnx, clavecriptografia));
               /* comando.Connection = Connection(stringcnx, clavecriptografia);

                int index = sql.IndexOf("VALUES");

                string novoComandoSql = sql.Insert(index, " RETURNING LAST_INSERT_ID() ");

                comando.CommandText = novoComandoSql;

                comando.ExecuteNonQuery();

                //Executa a query sql.
                int id = (int)comando.LastInsertedId;

                //int id = (int)comando.GetGeneratedKeys().GetValue(0);

                MySqlConnection.Close();
                // Retorna a quantidade de linhas afetadas
                return id;*/

                mysqls.comando.Connection = Connection(mysqls.Stringcnx, mysqls.Clavecriptografia);
                mysqls.comando.CommandText = sql;

                // Executar a inserção
                mysqls.comando.ExecuteNonQuery();

                // Obter o último ID inserido usando LAST_INSERT_ID()
                mysqls.comando.CommandText = "SELECT LAST_INSERT_ID()";
                int id = Convert.ToInt32(mysqls.comando.ExecuteScalar());

                mysqls.MySqlConnection.Close();

                // Retorna o último ID inserido
                return id;

            }
            catch (Exception)
            {
                // Retorna uma exceção simples que pode ser tratada por parte do desenvolvedor
                throw;
            }
            finally
            {
                if (mysqls.comando != null)
                    mysqls.comando.Dispose();
            }
        }
        public int ExecutaAtualizacaoWithIdentityColuna(string sql, string nombrecolunaid)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                //comando = new SqlCommand(sql, Connection(stringcnx, clavecriptografia));
                /*comando.Connection = Connection(stringcnx, clavecriptografia);

                int index = sql.IndexOf("VALUES");

                string novoComandoSql = sql.Insert(index, " RETURNING LAST_INSERT_ID() ");

                comando.CommandText = novoComandoSql;

                comando.ExecuteNonQuery();

                //Executa a query sql.
                int id = (int)comando.LastInsertedId;

                //int id = (int)comando.GetGeneratedKeys().GetValue(0);

                MySqlConnection.Close();
                // Retorna a quantidade de linhas afetadas
                return id;*/

                mysqls.comando.Connection = Connection(mysqls.Stringcnx, mysqls.Clavecriptografia);
                mysqls.comando.CommandText = sql;

                // Executar a inserção
                mysqls.comando.ExecuteNonQuery();

                // Obter o último ID inserido usando LAST_INSERT_ID()
                mysqls.comando.CommandText = "SELECT LAST_INSERT_ID()";
                int id = Convert.ToInt32(mysqls.comando.ExecuteScalar());

                mysqls.MySqlConnection.Close();

                // Retorna o último ID inserido
                return id;


            }
            catch (Exception)
            {
                // Retorna uma exceção simples que pode ser tratada por parte do desenvolvedor
                throw;
            }
            finally
            {
                if (mysqls.comando != null)
                    mysqls.comando.Dispose();
            }
        }

        #endregion
        #region Executar Consulta SQL Descriptografia
        public DataTable ExecutaConsulta(string stringcnxs, string sql)
        {
            try
            {
                // Pega conexão com a base SQL Server
                mysqls.comando.Connection = Connection(mysqls.Stringcnx, mysqls.Clavecriptografia);
                // Adiciona a instrução SQL
                mysqls.comando.CommandText = sql;
                //Executa a query sql.
                mysqls.comando.ExecuteScalar();
                // Ler os dados e passa para um DataTable
                IDataReader dtreader = mysqls.comando.ExecuteReader();
                DataTable dtresult = new DataTable();

                dtresult.Load(dtreader);
                // Fecha a conexão
                mysqls.MySqlConnection.Close();
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
                if (mysqls.comando != null)
                    mysqls.comando.Dispose();
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
                mysqls.comando.Connection = Connection(mysqls.Stringcnx, mysqls.Clavecriptografia);
                mysqls.comando.CommandText = sql;
                //Executa a query sql.
                int result = mysqls.comando.ExecuteNonQuery();
                mysqls.MySqlConnection.Close();
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
                if (mysqls.comando != null)
                    mysqls.comando.Dispose();
            }
        }
        public int ExecutaAtualizacaoWithIdentity(string stringcnxs, string sql)
        {
            try
            {
                //Instância o sqlcommand com a query sql que será executada e a conexão.
                //comando = new SqlCommand(sql, connection());
                mysqls.comando.Connection = Connection(mysqls.Stringcnx, mysqls.Clavecriptografia);
                mysqls.comando.CommandText = sql;
                //Executa a query sql.
                int result = (int)mysqls.comando.ExecuteNonQuery();
                mysqls.MySqlConnection.Close();
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
                if (mysqls.comando != null)
                    mysqls.comando.Dispose();
            }
        }
        #endregion

    }
}
