using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BitRaceServer.QuestionTypes;
using static BitRaceServer.Enums;
using static BitRaceServer.Enums.Difficulty;

namespace BitRaceServer
{
    static class MSSQLConnector
    {
        static string connectionString;
        static SqlConnection sqlConnection;

        static string ConnectionString
        {
            get { return connectionString; }
        }

        public static void BuildConnection(string serverName, string databaseName)
        {
            //connectionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={userName};Password={password}";
            connectionString = $"Integrated Security=SSPI;Pooling=false;Data Source={serverName};Initial Catalog={databaseName}";
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
            }
            catch (SqlException)
            {
                throw new InvalidOperationException("SqlException has thrown due to some incorrect parameter.");
            }
        }

        public static IEnumerable<Question> QueryQuestions(int limit, Difficulty difficulty)
        {
            List<Question> result = new List<Question>();
            string sql = $"SELECT TOP {limit} ID, Text FROM Questions WHERE Difficulty = N'{(((difficulty == Difficulty.hard) ? "nehez" : (difficulty == Difficulty.normal) ? "kozepes" : "könnyű"))}'";

            using (SqlCommand comm = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int questionId = int.Parse(reader["ID"].ToString());
                        string questionText = reader["Text"].ToString();

                        Question question;

                        if (difficulty == Difficulty.hard)
                            question = new MainQuestion(questionId, questionText, new Dictionary<char, string>());
                        else if (difficulty == Difficulty.normal)
                            question = new PrimaryExtensionQuestion(questionId, questionText, new Dictionary<char, string>());
                        else
                            question = new SecondaryExtensionQuestion(questionId, questionText, new Dictionary<char, string>());

                        result.Add(question);
                    }
                }
            }

            foreach (var x in result)
            {
                x.OptionalAnswers = QueryAnswers(x.Id);
            }
            return result;
        }

        public static Dictionary<char, string> QueryAnswers(int questionId)
        {
            Dictionary<char, string> result = new Dictionary<char, string>();
            string sql = "SELECT Character_key, IsCorrectAnswer, [Text] FROM Answers WHERE Question_Id = @questionID";

            using (SqlCommand comm = new SqlCommand(sql, sqlConnection))
            {
                comm.Parameters.AddWithValue("@questionID", questionId);

                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        char char_key = char.Parse(reader["Character_key"].ToString());
                        string text = reader["Text"].ToString();
                        result.Add(char_key, text);
                    }
                }
            }
            return result;
        }

        public static bool IsCorrectAnswer(int questionId, char characterKey) //Dummy
        {
            bool isCorrect = false;
            string sql = "SELECT IsCorrectAnswer FROM Answers WHERE Question_Id = @questionID AND Character_key = @charKey";

            using (SqlCommand comm = new SqlCommand(sql, sqlConnection))
            {
                comm.Parameters.AddWithValue("questionID", questionId);
                comm.Parameters.AddWithValue("charKey", characterKey);

                isCorrect = bool.Parse(comm.ExecuteScalar().ToString());
            }
            return isCorrect;
        }

        public static bool InsertOrGetPlayer(ref Player insertable)
        {
            try
            {
                int score = insertable.Score;
                int id = -1;
                string sql = "sp_InsertOrGetPlayer";
                using (SqlCommand comm = new SqlCommand(sql, sqlConnection))
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("i_UserName", insertable.Name);
                    comm.Parameters.AddWithValue("o_Score", score).Direction = System.Data.ParameterDirection.Output;
                    comm.Parameters.AddWithValue("o_ID", id).Direction = System.Data.ParameterDirection.Output;
                    comm.ExecuteNonQuery();
                    insertable.Score = Convert.ToInt32(comm.Parameters["o_Score"].Value);
                    insertable.Id = Convert.ToInt32(comm.Parameters["o_ID"].Value);
                }

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

    }
}
