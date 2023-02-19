using System.Data.SqlClient;

namespace StudensDBApp
{
    //Методы сортировки
    internal static class Sort
    {
        //Сортировка по возрастанию
        internal static void SortBy(SqlConnection sqlConnection)
        {
            try
            {
                Console.WriteLine("Введите параметр сортировки:");
                string command = Console.ReadLine();
                //Команда сортировки
                SqlCommand sqlCommand = new SqlCommand($"Select * FROM Students ORDER BY {command}", sqlConnection);
                //Вызов метода отображения данных
                Show.ShowSelect(sqlCommand);
            }
            //Обработка исключений
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Сортировка по убыванию
        internal static void SortByDesc(SqlConnection sqlConnection)
        {
            try
            {
                Console.WriteLine("Введите параметр сортировки:");
                string command = Console.ReadLine();
                //Команда сортировки
                SqlCommand sqlCommand = new SqlCommand($"Select * FROM Students ORDER BY {command} DESC", sqlConnection);
                //Вызов метода отображения данных
                Show.ShowSelect(sqlCommand);
            }
            //Обработка исключений
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
