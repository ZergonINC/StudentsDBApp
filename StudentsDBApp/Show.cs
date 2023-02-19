using System.Data.SqlClient;

namespace StudensDBApp
{
    //Метод для отображения всех данных в БД
    internal static class Show
    {
        internal static void All(SqlConnection sqlConnection)
        {
            //Команда для запроса всей таблицы
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Students", sqlConnection);
            //Считываем строки из результата запроса
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    //Форматируем и отображаем название колонок
                    string str = String.Format("| {0,1} | {1,-30} | {2,-10} | {3,-40} | {4,-20}| {5,1} | {6,1} | {7,1} |",
                        reader.GetName(0),
                        reader.GetName(1),
                        reader.GetName(2),
                        reader.GetName(3),
                        reader.GetName(4),
                        reader.GetName(5),
                        reader.GetName(6),
                        reader.GetName(7));
                    Console.WriteLine(str);

                    //Построчно считываем таблицу
                    while (reader.Read())
                    {
                        //Форматируем и отображаем данные в консоли
                        str = String.Format("| {0,-2} | {1,-30} | {2,1} | {3,-40} | {4,-20}| {5,-6} | {6,-11} | {7,-12} |",
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetDateTime(2).ToShortDateString(),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetInt32(5),
                            reader.GetInt32(6),
                            reader.GetDouble(7));
                        Console.WriteLine(str);
                    }
                }
                else
                {
                    Console.WriteLine("Данных по запросу не обнаружено.");
                }
            }
        }

        internal static void ShowSelect(SqlCommand sqlCommand)
        {
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]} | {reader["FullName"]} | " +
                            $"{reader["Birthday"]} | {reader["University"]} | " +
                            $"{reader["Faculty"]} | {reader["Course"]} | " +
                            $"{reader["GroupNumber"]} | {reader["AverageScore"]}");
                    }
                }
                else
                {
                    Console.WriteLine("Данных по запросу не обнаружено.");
                }
            }
        }
    }
}
