using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polish_newNow
{
    public class MyDataBase
    {
        /// <summary>
        /// Регистрация пользователя в БД
        /// </summary>
        /// <param name="Email">Почта пользователя</param>
        /// <param name="Name">Имя пользователя</param>
        /// <param name="Avatar">Аватарка пользователя</param>
        /// <param name="Password">Пароль</param>
        static public void RegistrationDB(string Email, string Name, string Avatar, string Password)
        {
            using (var dataBase = new SqliteConnection("Data Source=PolskyAppDB.db"))
            {
                string Query = "INSERT INTO Users (Email, Name, Avatar, Password) Values( '" + Email + "','" + Name + "','" + Avatar + "','" + Password + "');";
                SqliteCommand command = dataBase.CreateCommand();
                command.CommandText = Query;
                dataBase.Open();
                command.ExecuteScalar();
                dataBase.Close();

            }
        }
        /// <summary>
        /// Проверка введенного имени и пароля, есть ли они в БД
        /// Возвращает True, если пользователь найден
        /// </summary>
        /// <param name="Name">Имя пользователя</param>
        /// <param name="Password">Пароль пользователя</param>
        /// <returns></returns>
        static public bool EntryDB(string Name, string Password)
        {
            using (var dataBase = new SqliteConnection("Data Source=PolskyAppDB.db"))
            {
                dataBase.Open();
                SqliteCommand command = dataBase.CreateCommand();
                command.CommandText = "SELECT Name FROM Users WHERE Name='" + Name + "';";
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    command.CommandText = "SELECT Password FROM Users WHERE Name='" + Name + "';";
                    string actualPassword = command.ExecuteScalar().ToString();
                    if (actualPassword == Password)
                    {
                        dataBase.Close();
                        return true;
                    }
                }
                dataBase.Close();
                return false;
            }
        }
        /// <summary>
        /// Возвращет имя пользователя
        /// </summary>
        /// <param name="Name">Имя пользователя</param>
        /// <returns></returns>
        static public string NameDB(string Name)
        {
            using (var dataBase = new SqliteConnection("Data Source=PolskyAppDB.db"))
            {
                dataBase.Open();
                SqliteCommand command = dataBase.CreateCommand();
                command.CommandText = "SELECT Name FROM Users WHERE Name='" + Name + "';";
                var result = command.ExecuteScalar();
                dataBase.Close();
                if (result.ToString() != null)
                {
                    return result.ToString();
                }
                else return "Ошибка";
            }
        }
        /// <summary>
        /// Возвращает ссылку (в виде строки) на аватар пользователя
        /// </summary>
        /// <param name="Avatar">Аватар пользователя</param>
        /// <returns></returns>
        static public string AvatarDB(string Avatar)
        {
            using (var dataBase = new SqliteConnection("Data Source=PolskyAppDB.db"))
            {
                dataBase.Open();
                SqliteCommand command = dataBase.CreateCommand();
                command.CommandText = "SELECT Avatar FROM Users WHERE Avatar='" + Avatar + "';";
                var result = command.ExecuteScalar();
                dataBase.Close();
                return result.ToString();
            }
        }
        /// <summary>
        ///Возвращет аватар для конкретного имени пользователя
        /// </summary>
        /// <param name="Name">Имя пользователя</param>
        /// <returns></returns>
        static public string AvatarDBEntry(string Name)
        {
            using (var dataBase = new SqliteConnection("Data Source=PolskyAppDB.db"))
            {
                dataBase.Open();
                SqliteCommand command = dataBase.CreateCommand();
                command.CommandText = "SELECT Avatar FROM Users WHERE Name='" + Name + "';";
                var result = command.ExecuteScalar();
                dataBase.Close();
                return result.ToString();
            }
        }
        /// <summary>
        /// Загружаем теоритический материал
        /// </summary>
        /// <param name="ID">Номер теоритического материала в БД</param>
        /// <returns></returns>
        static public string TheoryBatch(int ID)
        {
            using (var dataBase = new SqliteConnection("Data Source=PolskyAppDB.db"))
            {
                dataBase.Open();
                SqliteCommand command = dataBase.CreateCommand();
                command.CommandText = "SELECT Text FROM Theory WHERE Id=" + ID + ";";
                var result = command.ExecuteScalar();
                dataBase.Close();
                return result.ToString();

            }
        }
        /// <summary>
        /// Загружаем словарь, возвращаем список, который содержит элементы словаря
        /// </summary>
        static public List<PolishDictionary> DictionaryBatch()
        {
            List<PolishDictionary> list = new List<PolishDictionary>();
            using (var dataBase = new SqliteConnection("Data Source=PolskyAppDB.db"))
            {
                dataBase.Open();
                SqliteCommand command = dataBase.CreateCommand();
                command.CommandText = "SELECT Id FROM DictionaryPolsky;";
               var reader = command.ExecuteReader();
               if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int tmp = reader.GetInt32(0);
                        SqliteCommand quest = dataBase.CreateCommand();
                        quest.CommandText = "SELECT * FROM DictionaryPolsky WHERE Id=" + tmp + "";
                        var quests = quest.ExecuteReader();
                        while (quests.Read())
                        {
                            list.Add(new PolishDictionary(quests.GetString(0), quests.GetString(1),
                                quests.GetString(2), quests.GetString(3))); //Заполнение словаря
                        }
                    }
                }
                dataBase.Close();
            }
            return list;
        }
        /// <summary>
        /// Загрузка вопросов из БД
        /// </summary>
        /// <param name="Test">Номер теста</param>
        /// <returns></returns>

        static public List<Question> loadQuestions(int Test)
        {
            List<Question> list = new List<Question>();// Список вопросов
            try
            {
                using (var dataBase = new SqliteConnection("Data Source=PolskyAppDB.db"))
                {
                    dataBase.Open();
                    SqliteCommand command = dataBase.CreateCommand();
                    command.CommandText = "SELECT Id FROM TestsQue, Tests WHERE TestsQue.Id = Tests.IDQue AND Tests.IDTest = " + Test + ";"; //ORDER BY Random() limit 3
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int tmp = reader.GetInt32(0);
                            SqliteCommand getquest = dataBase.CreateCommand();
                            getquest.CommandText = "SELECT * FROM TestsQue WHERE Id = " + tmp + ";";
                            var quest = getquest.ExecuteReader();
                            while (quest.Read())
                            {
                                list.Add(new Question(quest.GetString(1), quest.GetString(2), quest.GetString(3), quest.GetString(4), quest.GetString(5), quest.GetInt32(6)));
                            }

                        }
                    }
                    dataBase.Close();
                }
            }
            catch (Exception)
            {

            }
            return list;
        }

        /// <summary>
        /// Обновление статистики
        /// </summary>
        /// <param name="username">Почта пользователя</param>
        /// <param name="question">Количество вопросов на которые ответил пользователь</param>
        /// <param name="realAnswer">Количество правильных ответов</param>
        public static void UpdateStatistic(string username, int question, int realAnswer)
        {
            // username - имя пользователя
            // question - количество ответов пользователя
            // realAnswer - количество верных ответов
            try
            {
                // Открытие БД и обновление данных в ней
                using (var db = new SqliteConnection("Data Source=PolskyAppDB.db"))
                {
                    db.Open();
                    SqliteCommand sql_cmd = db.CreateCommand();
                    sql_cmd.CommandText = "Update Stat Set Test = Test + 1 Where UserName = '" + username + "';";
                    sql_cmd.ExecuteScalar();
                    sql_cmd.CommandText = "Update Stat Set Question = Question + " + question + " Where UserName = '" + username + "';";
                    sql_cmd.ExecuteScalar();
                    sql_cmd.CommandText = "Update Stat Set RealAnswer = RightAnswer + " + realAnswer + " Where UserName = '" + username + "';";
                    sql_cmd.ExecuteScalar();
                    db.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Загружаем теорию из базы данных, таблицы TheoryFirst
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string loadTheory(int id)
        {
            try
            {
                using (var db = new SqliteConnection("Data Source=PolskyAppDB.db"))
                {
                    db.Open();
                    SqliteCommand command = db.CreateCommand();
                    command.CommandText = "SELECT TextTheory FROM TheoryFirst Where ID = " + id + ";";
                    var result = command.ExecuteScalar();
                    db.Close();
                    return result.ToString();  //Ссылка на объект не указывает на экземпляр объекта
                }
            }
            catch (Exception)
            {
                return "Ошибка отображения теории";
            }
        }



        /// <summary>
        /// Загрузка вопросов из БД
        /// </summary>
        /// <param name="Train">Номер теста</param>
        /// <returns></returns>

        static public List<QuestionForTrainer> loadQuestionsTrainer(int Train)
        {
            List<QuestionForTrainer> list = new List<QuestionForTrainer>();// Список вопросов
            try
            {
                using (var dataBase = new SqliteConnection("Data Source=PolskyAppDB.db"))
                {
                    dataBase.Open();
                    SqliteCommand command = dataBase.CreateCommand();
                    command.CommandText = "SELECT Id FROM TrainersQue, Trainers WHERE TrainersQue.Id = Trainers.IDQue AND Trainers.IDTrain = " + Train + " ORDER BY Random() limit 2;";
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int tmp = reader.GetInt32(0);
                            SqliteCommand getquest = dataBase.CreateCommand();
                            getquest.CommandText = "SELECT * FROM TrainersQue WHERE Id = " + tmp + ";";
                            var quest = getquest.ExecuteReader();
                            while (quest.Read())
                            {
                                list.Add(new QuestionForTrainer(quest.GetString(1), quest.GetString(2), quest.GetString(3), quest.GetString(4), quest.GetString(5), quest.GetInt32(6)));
                            }

                        }
                    }
                    dataBase.Close();
                }
            }
            catch (Exception)
            {

            }
            return list;
        }

    }
}
