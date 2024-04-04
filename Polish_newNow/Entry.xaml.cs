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
using System.Windows.Shapes;

namespace Polish_newNow
{
    /// <summary>
    /// Страница, через которую к основному окну (MainPage.xaml)
    /// проходят ранее зарегистрированные 
    /// </summary>
    public partial class Entry : Window
    {
        public Entry()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Функция вызываемая нажатием кнопки "Войти".
        /// Программа сверяет пароль и имя пользователя через БД, ищет совпадения,
        /// также загружаются имя и аватарка пользователя
        /// для дальнейшего отображения на основной странице приложения (MainPage.xaml)
        /// </summary>
        private void ComeIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MyDataBase.EntryDB(NameBox.Text, PasswordBox.Text))
                {
                    User NewUser = new User(NameBox.Text); //Запись имени входящего пользователя для отображения его имени в TextBox
                    User NewAvatar = new User(NameBox.Text, 1); //Подгружается аватар
                    MainPage MainPage = new MainPage(); //Открытие страницы MainPage и закрытие данного окна
                    MainPage.Show();
                    this.Close();
                }
                else
                {
                    MessageBoxButton buttonEmail = MessageBoxButton.OK;
                    MessageBoxImage imageEmail = MessageBoxImage.Error;
                    MessageBoxResult resultEmail;
                    resultEmail = MessageBox.Show("Что-то неверно!",
                        "О, нет!", buttonEmail, imageEmail, MessageBoxResult.OK);
                }
            }
            catch
            {
                MessageBoxButton buttonEmail = MessageBoxButton.OK;
                MessageBoxImage imageEmail = MessageBoxImage.Error;
                MessageBoxResult resultEmail;
                resultEmail = MessageBox.Show("Что-то неверно!",
                    "О, нет!", buttonEmail, imageEmail, MessageBoxResult.OK);
            }
        }
        /// <summary>
        /// Возврат к Меню
        /// </summary>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Menu Menu = new Menu();
            Menu.Show();
            this.Close();
        }
        /// <summary>
        /// Переход к окну Регистрации
        /// </summary>
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration Registr = new Registration();
            Registr.Show();
            this.Close();
        }
    }
}
