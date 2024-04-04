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
    /// Страница, содержащая конструктор для размещения теории по польским временам
    /// </summary>
    public partial class TheoryTwo : Page
    {
        public TheoryTwo()
        {
            InitializeComponent();
            //Загрузка теоритических текстов из БД
            TextBlockTheoryTwo1.Text = MyDataBase.loadTheory(4);
            TextBlockTheoryTwo2.Text = MyDataBase.loadTheory(5);
            TextBlockTheoryTwo3.Text = MyDataBase.loadTheory(6);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Theory());
        }
    }
}
