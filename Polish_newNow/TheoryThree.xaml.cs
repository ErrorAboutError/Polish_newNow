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
    public partial class TheoryThree : Page
    {
        public TheoryThree()
        {
            InitializeComponent();
            //Загрузка теоритических текстов из БД
            TextBlockTheoryThree1.Text = MyDataBase.loadTheory(7);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Theory());
        }
    }
}
