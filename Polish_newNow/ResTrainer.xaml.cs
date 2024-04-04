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
    /// Логика взаимодействия для ResTrainer.xaml
    /// </summary>
    public partial class ResTrainer : Window
    {
        public ResTrainer(int questions, int RealAnswers)
        {
            InitializeComponent();
            double ProcRightAnswers = RealAnswers / questions;
            int mark = 2;
            if (ProcRightAnswers >= 0.55)
                mark++;
            if (ProcRightAnswers >= 0.7)
                mark++;
            if (ProcRightAnswers > 0.85)
                mark++;

            ResultTrainTextBlock.Text = "Количество вопросов: " + questions +
            "\nКоличество правильных ответов: " + RealAnswers +
            "\nВаша оценка: " + mark;
        }

        private void StatButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
