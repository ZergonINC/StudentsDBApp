using System.Data.SqlClient;

namespace StudensDBApp
{
    //Метод для изменения данных в БД
    internal static class Update
    {
        internal static void Change(SqlConnection sqlConnection)
        {
            try
            {
                

                //Пользователю требуется ввести название колонки таблицы
                Console.WriteLine("Введите Id студента:");
                string firstName = Console.ReadLine();

                //Пользователю требуется ввести название колонки таблицы
                Console.WriteLine("Введите название столбца:");
                string secondName = Console.ReadLine();

                //Пользователю требуется ввести элемент
                Console.WriteLine("Введите новое значение элемента:");
                string middleName = Console.ReadLine();

                //Запрос на изменение данных по ключу
                SqlCommand SqlCommand = new SqlCommand($"UPDATE Students SET {firstName}=N'{secondName}' WHERE Id={middleName}", sqlConnection);
                int result = SqlCommand.ExecuteNonQuery();
                //Уведомление об изменениях
                Console.WriteLine(result > 0 ? result > 1 ? "Имененена 1 строка" : $"Изменено {result} строк(и)" : "Строки с такими параметрами отсутствуют!");
            }
            //Обработка исключений
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
