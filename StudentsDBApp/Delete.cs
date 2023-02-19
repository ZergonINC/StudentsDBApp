using System.Data.SqlClient;

namespace StudensDBApp
{
    //Метод для удаления данных из БД
    internal static class Delete
    {
        internal static void Remove(SqlConnection sqlConnection)
        {
            try
            {
                //Пользователю требуется ввести название колонки таблицы
                Console.WriteLine("Введите название столбца:");
                string command = Console.ReadLine();

                //Пользователю требуется ввести элемент
                Console.WriteLine("Введите элемент для удаления:");
                string element = Console.ReadLine();

                //Запрос на удаление данных по ключу
                SqlCommand SqlCommand = new SqlCommand($"DELETE FROM Students WHERE {command}={element}", sqlConnection);
                int result = SqlCommand.ExecuteNonQuery();
                // Уведомление об удалении
                Console.WriteLine(result > 0 ? result > 1 ? "Удалена 1 строка" : $"Удалено {result} строк" : "Строки с такими параметрами отсутствуют!");
            }
            //Обработка исключений
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
