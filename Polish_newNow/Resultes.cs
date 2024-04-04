using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polish_newNow
{
    public class Resultes
    {
        public static string OurResultText { get; set; }
        /// <summary>
        /// Класс для записи результатов выполнения тестов
        /// </summary>
        /// <param name="questions">Количество вопросов</param>
        /// <param name="rightAnswers">Количество верных ответов</param>
        /// <returns></returns>
        public static string GetResults(int questions, int rightAnswers)
        {
            double cofRightAnswers = rightAnswers / questions;
            int mark = 2;
            if (cofRightAnswers >= 0.55)
                mark++;
            if (cofRightAnswers >= 0.7)
                mark++;
            if (cofRightAnswers > 0.85)
                mark++;

            return "Пользователь: " + User.Name + "\nКоличество вопросов: " + questions +
            "\nКоличество правильных ответов: " + rightAnswers +
            "\nВаша оценка: " + mark;
        }
    }
}
