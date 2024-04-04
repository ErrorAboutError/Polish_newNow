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
    //// <summary>
    ///Приветсвенное окно приложения
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Window;
        public MainWindow()
        {
            InitializeComponent();
            Window = this;
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Далее"
        /// Переход к окну Меню
        /// </summary>
        private void Further_Click(object sender, RoutedEventArgs e)
        {
            Menu Menu = new Menu();
            Menu.Show();
            this.Close();
        }
        /// <summary>
        /// Функция выхода из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage image = MessageBoxImage.Question;
            MessageBoxResult result;
            result = MessageBox.Show("Выйти из приложения?",
                "Выход", button, image, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes) this.Close();
        }

        /// <summary>
        /// Функция обеспечения движения окна
        /// </summary>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Window.DragMove();
            }
        }


    }
}
