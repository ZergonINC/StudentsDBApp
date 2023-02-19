using StudensDBApp;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

class Program
{
    //Строка подключения
    private static string connectionString = ConfigurationManager.ConnectionStrings["Students"].ConnectionString;
    private static SqlConnection sqlConnection;

    static void Main(string[] args)
    {
        //Подключение к БД
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        bool work = true;

        Console.WriteLine("StudentsDB\n");

        //Переменная для хранения команд
        string command = string.Empty;

        while (work)
        {
            //Ожидание ввода команды
            Console.Write(">");
            command = Console.ReadLine();

            //Выход из приложения
            if (command.ToLower().Equals("exit"))
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
                break;
            }

            //Кейсы команд
            switch (command.ToLower())
            {
                //Отображение всей таблицы
                case "show":
                    Show.All(sqlConnection);
                    break;

                //Добавление данных в БД
                case "insert":
                    Add.Insert(sqlConnection);
                    break;

                //Удаление данных в БД
                case "delete":
                    Delete.Remove(sqlConnection);
                    break;

                //Обновление данных в БД
                case "update":
                    Update.Change(sqlConnection);
                    break;

                //Сортировка по возрастанию
                case "orderby":
                    Sort.SortBy(sqlConnection);
                    break;

                //Сортировка по убыванию
                case "orderbydesc":
                    Sort.SortByDesc(sqlConnection);
                    break;

                //Минимальное значение среднего балла
                case "scoremin":
                    AverageScore.ScoreMin(sqlConnection);
                    break;

                //Максимальное значение cреднего балла
                case "scoremax":
                    AverageScore.ScoreMax(sqlConnection);
                    break;

                //Среднее значение всех баллов
                case "score":
                    AverageScore.Average(sqlConnection);
                    break;

                //Сумма значение cреднего балла
                case "scoresum":
                    AverageScore.Sum(sqlConnection);
                    break;

                //Команда позволяющая найти студента по ФИО
                case "findname":
                    Search.SearchByName(sqlConnection);
                    break;

                //Команда позволяющая найти студента по дате рождения
                case "find":
                    Search.SearchByBirthday(sqlConnection);
                    break;

                //Команда позволяющая самостоятельно ввести sql-запрос
                case "search":
                    Search.Select(sqlConnection);
                    break;

                //Выход
                case "exit":
                    work = false;
                    break;

                //Информация о доступных командах
                case "помощь":
                case "h":
                case "help":
                    Console.WriteLine("Доступные команды:\n" +
                        "Показать таблицу из базы - show\n" +
                        "Добавление в базу - insert\n" +
                        "Удаление из базы - delete\n" +
                        "Изменение записи в базе - update\n" +
                        "Сортировка по возрастанию - ordrby\n" +
                        "Сортировка по убыванию - ordrbydesc\n" +
                        "Минимальное значение среднего балла - scoremin\n" +
                        "Максимальное значение cреднего балла - scoremax\n" +
                        "Среднее значение всех баллов - score\n" +
                        "Сумма значение cреднего балла - scoresum\n" +
                        "Найти студента по ФИО - findname\n" +
                        "Найти студента по дате рождения - find\n" +
                        "Самостоятельный ввод запроса - search\n" +
                        "Выход - exit");
                    break;
                //Обработка неверных команд
                default:
                    Console.WriteLine($"Команда {command} некорректна!\nДля помощи введите коммпанду: help");
                    break;
            }
        }
    }
}