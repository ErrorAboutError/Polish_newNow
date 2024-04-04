using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Polish_newNow
{
    /// <summary>
    /// Окно, выводящее вопросы тестов
    /// </summary>

    public partial class TestFirst : Window
    {
        // Список вопросов
        List<Question> test;
        // ID текущего вопроса
        int current_id = 0;
        public TestFirst()
        {
            InitializeComponent();
            test = MyDataBase.loadQuestions(ClassForLoadTest.NumberButton); //Загрузка вопросв определенного теста из БД
            // Вывод первого вопроса
            LoadQuestion(0);
            // Добавление кнопок для перехода на вопросы
            AddQuestionsButtons();
        }
        /// <summary>
        /// Динамическое добавление кнопок
        /// </summary>
        private void AddQuestionsButtons()
        {
            for (int i = 0; i < test.Count; i++)
            {
                Button button = new Button();
                button.Content = i + 1;
                button.Style = (Style)Application.Current.Resources["StyleBtnInMain"];
                button.Width = 60;
                button.Height = 60;
                button.VerticalAlignment = VerticalAlignment.Bottom;
                button.HorizontalAlignment = HorizontalAlignment.Left;
                button.Click += (s, e) =>
                {
                    int id = Convert.ToInt32((s as Button).Content.ToString());
                    LoadQuestion(id - 1);
                };
                button.Margin = new Thickness(5, 5, 0, 0);
                QuestionsDockPanel.Children.Add(button);
            }
        }
        /// <summary>
        /// Загрузка вопросов, их оформление в окне
        /// </summary>
        /// <param name="id">Номера вопросов</param>
        private void LoadQuestion(int id)
        {

            QuestionText.Style = (Style)Application.Current.Resources["Text_Style_Test"];
            AnswerTextOne.Style = (Style)Application.Current.Resources["Text_Style_TestAnswer"];
            AnswerTextTwo.Style = (Style)Application.Current.Resources["Text_Style_TestAnswer"];
            AnswerTextThree.Style = (Style)Application.Current.Resources["Text_Style_TestAnswer"];
            AnswerTextFour.Style = (Style)Application.Current.Resources["Text_Style_TestAnswer"];

            current_id = id;
            QuestionText.Text = (id + 1) + ". " + test[id].question;
            AnswerTextOne.Text = test[id].AnswerOne;
            AnswerTextTwo.Text = test[id].AnswerTwo;
            AnswerTextThree.Text = test[id].AnswerThree;
            AnswerTextFour.Text = test[id].AnswerFour;
            if (test[id].AnswerUser != 0)
                AnswerOne.IsChecked = false;
            else
                AnswerOne.IsChecked = true;
            if (test[id].AnswerUser != 1)
                AnswerTwo.IsChecked = false;
            else
                AnswerTwo.IsChecked = true;
            if (test[id].AnswerUser != 2)
                AnswerThree.IsChecked = false;
            else
                AnswerThree.IsChecked = true;
            if (test[id].AnswerUser != 3)
                AnswerFour.IsChecked = false;
            else
                AnswerFour.IsChecked = true;
            if (current_id == test.Count - 1)
                NextButton.Content = "Всё! См. в Рез-ты";
            else
                NextButton.Content = "Вперёд";
        }
        //Функция проверки ответов
        private int CheckAnswers()
        {
            int count = 0;
            for (int i = 0; i < test.Count; i++)
                if (test[i].AnswerUser == test[i].RealAnswerID)
                    count++;
            return count;
        }
        //Слушатели RadioButtons
        private void AnswerOne_Checked(object sender, RoutedEventArgs e)
        {
            test[current_id].AnswerUser = 0;
        }

        private void AnswerTwo_Checked(object sender, RoutedEventArgs e)
        {
            test[current_id].AnswerUser = 1;
        }

        private void AnswerThree_Checked(object sender, RoutedEventArgs e)
        {
            test[current_id].AnswerUser = 2;
        }

        private void AnswerFour_Checked(object sender, RoutedEventArgs e)
        {
            test[current_id].AnswerUser = 3;
        }
        //Динамически изменяемая кнопка (либо выход из теста и загрузка результатов, либо переход к следующему вопросу)
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (current_id == test.Count - 1)
            {
                Resultes.OurResultText = Resultes.GetResults(test.Count, CheckAnswers());
                MyDataBase.UpdateStatistic(User.Name, test.Count, CheckAnswers());
                this.Close();
            }
            else
            {
                LoadQuestion(current_id + 1);
            }
        }
    }
}
