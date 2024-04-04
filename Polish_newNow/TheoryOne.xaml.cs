using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class TheoryOne : Page
    {
        public TheoryOne()
        {
            InitializeComponent();
            //Загрузка теоритических текстов из БД
            TextBlock3.Text = MyDataBase.loadTheory(1);
            TextBlock4.Text = MyDataBase.loadTheory(2);
            TextBlock5.Text = MyDataBase.loadTheory(3);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Theory());
        }
    }
}
