using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polish_newNow
{
    /// <summary>
    /// Класс используется при загрузке тестов (см файл TestFirst.xaml)
    /// </summary>
    public class Question
    {
        public string question { get; set; }// Текст вопроса
        //Ответы:
        public string AnswerOne { get; set; }
        public string AnswerTwo { get; set; }
        public string AnswerThree { get; set; }
        public string AnswerFour { get; set; }
        public int RealAnswerID { get; set; } // ID правильного ответа
        public int AnswerUser { get; set; } // ID выбора пользователя 

        public Question(string QuestionQue, string answerOne, string answerTwo, string answerThree, string answerFour,
            int realAnswerID)
        {
            this.question = QuestionQue;
            this.AnswerOne = answerOne;
            this.AnswerTwo = answerTwo;
            this.AnswerThree = answerThree;
            this.AnswerFour = answerFour;
            this.RealAnswerID = realAnswerID;
            AnswerUser = -1;
        }
    }
}
