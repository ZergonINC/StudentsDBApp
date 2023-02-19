using System.Data.SqlClient;

namespace StudensDBApp
{
    //Метод для добавления данных в БД
    internal static class Add
    {
        internal static void Insert(SqlConnection sqlConnection)
        {
            try
            {
                //Пользователю требуется ввести полное имя
                Console.WriteLine("Введите ФИО:");
                string fullName = Console.ReadLine();

                //Пользователю требуется ввести дату рождения
                Console.WriteLine("Введите дату рождения:");
                string birthDate = Console.ReadLine();

                //Пользователю требуется ввести университет
                Console.WriteLine("Введите название университет:");
                string university = Console.ReadLine();

                //Пользователю требуется ввести факультет
                Console.WriteLine("Введите факультет:");
                string faculty = Console.ReadLine();

                //Пользователю требуется ввести номер группы
                Console.WriteLine("Введите номер группы:");
                string groupNumber = Console.ReadLine();

                //Пользователю требуется ввести курс
                Console.WriteLine("Введите номер курс:");
                string course = Console.ReadLine();

                //Пользователю требуется ввести средний балл
                Console.WriteLine("Введите средний балл:");
                string avgScore = Console.ReadLine();

                //Запрос на добавление данных в бд
                SqlCommand SqlCommand = new SqlCommand($"INSERT INTO Students (FullName, Birthday, University, Faculty, GroupNumber, Course, AverageScore) " +
                    $"VALUES (N'{fullName}', '{birthDate}', N'{university}', N'{faculty}', '{groupNumber}', '{course}', '{avgScore}')", sqlConnection);

                SqlCommand.ExecuteNonQuery();
                //Уведомление об изменениях
                Console.WriteLine("Строка добавлена");
            }
            //Обработка исключений
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
