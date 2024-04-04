using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Страница, содержащая ссылки на теоритический материал
    /// </summary>
    public partial class UsefulLinkPage : Page
    {
        public UsefulLinkPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Theory());
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://start-eu.com.pl/ru/forma-obrashhenyj-v-polskom-yazke/");
            }
            catch (Exception)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage image = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show("Проверьте подключение к интернету!",
                    "Problem", button, image, MessageBoxResult.OK);
            }
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://lingvofon.club/");
            }
            catch (Exception)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage image = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show("Проверьте подключение к интернету!",
                    "Problem", button, image, MessageBoxResult.OK);
            }

        }

        private void Hyperlink_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://app.memrise.com/course/1522641/polskii-3/1/");
            }
            catch (Exception)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage image = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show("Проверьте подключение к интернету!",
                    "Problem", button, image, MessageBoxResult.OK);
            }

        }

        private void Hyperlink_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://www.tourister.ru/world/europe/poland/publications/824");
            }
            catch (Exception)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage image = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show("Проверьте подключение к интернету!",
                    "Problem", button, image, MessageBoxResult.OK);
            }

        }

        private void Hyperlink_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://tutpl.ru/1-1-alfavit.html");
            }
            catch (Exception)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage image = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show("Проверьте подключение к интернету!",
                    "Problem", button, image, MessageBoxResult.OK);
            }

        }

        private void Hyperlink_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("https://www.youtube.com/@Mikitko");
            }
            catch (Exception)
            {
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage image = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show("Проверьте подключение к интернету!",
                    "Problem", button, image, MessageBoxResult.OK);

            }

        }
    }
}
