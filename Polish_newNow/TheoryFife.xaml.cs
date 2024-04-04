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
    public partial class TheoryFife : Page
    {
        public TheoryFife()
        {
            InitializeComponent();
            //Загрузка теоритических текстов из БД
            TextBlockTheoryFife1.Text = MyDataBase.loadTheory(8);
            TextBlockTheoryFife2.Text = MyDataBase.loadTheory(9);
            TextBlockTheoryFife3.Text = MyDataBase.loadTheory(10);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Theory());
        }
    }
}
