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
    /// Страница, содержащая кнопки-ссылки на окно с вопросами 
    /// </summary>
    public partial class Tests : Page
    {
        public Tests()
        {
            InitializeComponent();
        }
        private void TestOne_Click(object sender, RoutedEventArgs e)
        {
            ClassForLoadTest.NumberButton = 1;
            MainPage MainPage = new MainPage();
            TestFirst TestFirst = new TestFirst();
            TestFirst.Show();
            MainPage.Close();
            MainPage.Close();
        }

        private void TestTwo_Click(object sender, RoutedEventArgs e)
        {
            ClassForLoadTest.NumberButton = 2;
            MainPage MainPage = new MainPage();
            TestFirst TestFirst = new TestFirst();
            TestFirst.Show();
            MainPage.Close();
            MainPage.Close();
        }

        private void TestThree_Click(object sender, RoutedEventArgs e)
        {
            ClassForLoadTest.NumberButton = 3;
            MainPage MainPage = new MainPage();
            TestFirst TestFirst = new TestFirst();
            TestFirst.Show();
            MainPage.Close();
            MainPage.Close();
        }

        private void TestFour_Click(object sender, RoutedEventArgs e)
        {
            ClassForLoadTest.NumberButton = 4;
            MainPage MainPage = new MainPage();
            TestFirst TestFirst = new TestFirst();
            TestFirst.Show();
            MainPage.Close();
            MainPage.Close();
        }

        private void TestFife_Click(object sender, RoutedEventArgs e)
        {
            ClassForLoadTest.NumberButton = 5;
            MainPage MainPage = new MainPage();
            TestFirst TestFirst = new TestFirst();
            TestFirst.Show();
            MainPage.Close();
            MainPage.Close();
        }
    }
}
