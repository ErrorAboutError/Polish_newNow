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
    /// Страница с кнопками-ссылками на страницы, содержащие теоритический материал
    /// </summary>
    public partial class Theory : Page
    {
        public Theory()
        {
            InitializeComponent();
        }
        private void ModuleOne_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TheoryOne());
        }


        private void ModuleTwo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TheoryTwo());
        }

        private void ModuleThree_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TheoryThree());
        }

        private void ModuleFour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TheoryFour());
        }

        private void ModuleFife_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TheoryFife());
        }

        private void UsefulLinks_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UsefulLinkPage());
        }
    }
}
