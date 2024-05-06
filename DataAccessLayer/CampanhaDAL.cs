using System;
using System.Data;
using MySql.Data.MySqlClient;
using ToolAccessLayer;

namespace DataAccessLayer
{
    public class CampanhaDAL
    {
        private MySqlConnection MySqlConnection = new MySqlConnection("headin2023fabrinioandessantanalemos");

        public CampanhaDAL()
        {
            MySqlConnection.Open();
        }

        public int InserirCampanha(decimal vlrCampanha, DateTime dtInicio, DateTime dtFim, bool flAtiva, string dsPix, string dsPixInfo, int idPessoa, string file_path, decimal vlrMinimoSorte)
        {
            MySqlCommand command = MySqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO TbCampanha (vlrCampanha, dtInicio, dtFim, flAtiva, dsPix, dsPixInfo, idPessoa, file_path, vlrMinimoSorte) " +
                                  "VALUES (@vlrCampanha, @dtInicio, @dtFim, @flAtiva, @dsPix, @dsPixInfo, @idPessoa, @file_path, @vlrMinimoSorte)";
            command.Parameters.AddWithValue("@vlrCampanha", vlrCampanha);
            command.Parameters.AddWithValue("@dtInicio", dtInicio);
            command.Parameters.AddWithValue("@dtFim", dtFim);
            command.Parameters.AddWithValue("@flAtiva", flAtiva);
            command.Parameters.AddWithValue("@dsPix", dsPix);
            command.Parameters.AddWithValue("@dsPixInfo", dsPixInfo);
            command.Parameters.AddWithValue("@idPessoa", idPessoa);
            command.Parameters.AddWithValue("@file_path", file_path);
            command.Parameters.AddWithValue("@vlrMinimoSorte", vlrMinimoSorte);

            return command.ExecuteNonQuery();
        }

        public int AtualizarCampanha(int id, decimal vlrCampanha, DateTime dtInicio, DateTime dtFim, bool flAtiva, string dsPix, string dsPixInfo, int idPessoa, string file_path, decimal vlrMinimoSorte)
        {
            MySqlCommand command = MySqlConnection.CreateCommand();
            command.CommandText = "UPDATE TbCampanha SET vlrCampanha = @vlrCampanha, dtInicio = @dtInicio, dtFim = @dtFim, flAtiva = @flAtiva, " +
                                  "dsPix = @dsPix, dsPixInfo = @dsPixInfo, idPessoa = @idPessoa, file_path = @file_path, vlrMinimoSorte = @vlrMinimoSorte " +
                                  "WHERE id = @id";
            command.Parameters.AddWithValue("@vlrCampanha", vlrCampanha);
            command.Parameters.AddWithValue("@dtInicio", dtInicio);
            command.Parameters.AddWithValue("@dtFim", dtFim);
            command.Parameters.AddWithValue("@flAtiva", flAtiva ? 1 : 0);
            command.Parameters.AddWithValue("@dsPix", dsPix);
            command.Parameters.AddWithValue("@dsPixInfo", dsPixInfo);
            command.Parameters.AddWithValue("@idPessoa", idPessoa);
            command.Parameters.AddWithValue("@file_path", file_path);
            command.Parameters.AddWithValue("@vlrMinimoSorte", vlrMinimoSorte);
            command.Parameters.AddWithValue("@id", id);

            return command.ExecuteNonQuery();
        }

        public int ExcluirCampanha(int id)
        {
            MySqlCommand command = MySqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM TbCampanha WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);

            return command.ExecuteNonQuery();
        }

        public DataTable ConsultarCampanhas()
        {
            MySqlCommand command = MySqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM TbCampanha";

            DataTable dataTable = new DataTable();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        public DataTable ConsultarCampanha(int id)
        {
            MySqlCommand command = MySqlConnection.CreateCommand();
            command.CommandText = "SELECT * FROM TbCampanha WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);

            DataTable dataTable = new DataTable();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }
            return dataTable;
        }
    }
}
