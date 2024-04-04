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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Polish_newNow
{
    /// <summary>
    /// Логика взаимодействия для Trainer.xaml
    /// </summary>
    public partial class Trainer : Page
    {
        public Trainer()
        {
            InitializeComponent();
        }

        private void TrainerOne_Click(object sender, RoutedEventArgs e)
        {
            ClassForLoadTrainer.NumberButton = 1;
            MainPage MainPage = new MainPage();
            TrainerFirst TrainerFirst = new TrainerFirst();
            TrainerFirst.Show();
            MainPage.Close();
            MainPage.Close();
        }

        private void TrainerTwo_Click(object sender, RoutedEventArgs e)
        {
            ClassForLoadTrainer.NumberButton = 2;
            MainPage MainPage = new MainPage();
            TrainerFirst TrainerFirst = new TrainerFirst();
            TrainerFirst.Show();
            MainPage.Close();
            MainPage.Close();
        }

        private void TrainerThree_Click(object sender, RoutedEventArgs e)
        {
            ClassForLoadTrainer.NumberButton = 3;
            MainPage MainPage = new MainPage();
            TrainerFirst TrainerFirst = new TrainerFirst();
            TrainerFirst.Show();
            MainPage.Close();
            MainPage.Close();
        }

        private void TrainerFour_Click(object sender, RoutedEventArgs e)
        {
            ClassForLoadTrainer.NumberButton = 4;
            MainPage MainPage = new MainPage();
            TrainerFirst TrainerFirst = new TrainerFirst();
            TrainerFirst.Show();
            MainPage.Close();
            MainPage.Close();
        }

        private void TrainerFife_Click(object sender, RoutedEventArgs e)
        {
            ClassForLoadTrainer.NumberButton = 5;
            MainPage MainPage = new MainPage();
            TrainerFirst TrainerFirst = new TrainerFirst();
            TrainerFirst.Show();
            MainPage.Close();
            MainPage.Close();
        }
    }
}
