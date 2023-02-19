using System.Data.SqlClient;

namespace StudensDBApp
{
    internal static class AverageScore
    {
        internal static void ScoreMin(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Students WHERE AverageScore = (SELECT MIN(AverageScore) FROM Students)", sqlConnection);
            Show.ShowSelect(sqlCommand);
        }

        internal static void ScoreMax(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Students WHERE AverageScore = (SELECT MAX(AverageScore) FROM Students)", sqlConnection);
            Show.ShowSelect(sqlCommand);
        }

        internal static void Average(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT AVG(AverageScore) FROM Students", sqlConnection);
            Console.WriteLine($"Среднее значение всех баллов: {sqlCommand.ExecuteScalar()}");
        }

        internal static void Sum(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT SUM(AverageScore) FROM Students", sqlConnection);
            Console.WriteLine($"Сумма баллов: {sqlCommand.ExecuteScalar()}");
        }
    }
}
