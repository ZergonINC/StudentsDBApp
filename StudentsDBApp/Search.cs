using System.Data.SqlClient;

namespace StudensDBApp
{
    internal static class Search
    {
        internal static void Select(SqlConnection sqlConnection)
        {
            try
            {
                Console.WriteLine("Введите SQL команду:");
                string command = Console.ReadLine();

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                Show.ShowSelect(sqlCommand);
            }
            //Обработка исключений
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal static void SearchByName(SqlConnection sqlConnection)
        {
            try
            {
                Console.WriteLine("Ведите ФИО студента:");
                string fullName = Console.ReadLine();

                SqlCommand sqlCommand = new SqlCommand($"Select * FROM Students WHERE FullName LIKE N'%{fullName}%'", sqlConnection);
                Show.ShowSelect(sqlCommand);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal static void SearchByBirthday(SqlConnection sqlConnection)
        {
            try
            {
                Console.WriteLine("Ведите дату рождения студента:");
                string birthday = Console.ReadLine();

                SqlCommand sqlCommand = new SqlCommand($"Select * FROM Students WHERE FullName LIKE N'%{birthday}%'", sqlConnection);
                Show.ShowSelect(sqlCommand);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
