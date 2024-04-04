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
using System.Windows.Shapes;

namespace Polish_newNow
{
    /// <summary>
    /// Окно Меню, переход к регистрации, входу уже регистрировавшихся
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Функция отрабатывающая переход к окну Входа (для тех, у кого уже имеется аккаунт)
        /// </summary>
        private void ComeIn_Click(object sender, RoutedEventArgs e)
        {
            Entry Entry = new Entry();
            Entry.Show();
            Close();
        }
        /// <summary>
        /// Функция отрабатывающая переход к окну Регистрации
        /// </summary>
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration Registr = new Registration();
            Registr.Show();
            this.Close();
        }
        /// <summary>
        /// Открытие информации о приложении
        /// </summary>
        private void Information_Click(object sender, RoutedEventArgs e)
        {
            //Открытие документа с информацией о приложении
            string path = @"Information.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadToEnd();
                MessageBox.Show(text, "Кратко о приложении");
            }
        }
        /// <summary>
        /// Осуществляется выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Go_Out_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage image = MessageBoxImage.Question;
            MessageBoxResult result;
            result = MessageBox.Show("Выйти из приложения?",
                "Выход", button, image, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                Menu Menu = new Menu();
                Menu.Close();
                this.Close();
            }
        }
    }
}
