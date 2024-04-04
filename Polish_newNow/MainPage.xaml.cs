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
    /// Логика основного окна приложения MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            AppFrame.Content = new Download(); //Загрузка приветсвенной страницы
            TextBlockUserName.Text = MyDataBase.NameDB(User.Name); //Имя пользователя вставляется в блок отображения его имени,
                                                                   //имя находится через работу с БД
            ImgBox.Source = new BitmapImage(new Uri(MyDataBase.AvatarDBEntry(User.Avatar))); //Открывается аватарка
        }
        /// <summary>
        /// Переход к странице с теорией
        /// </summary>
        private void Theory_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Content = new Theory();
        }
        /// <summary>
        /// Переход к тренажёрам
        /// </summary>
        private void Trainer_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Content = new Trainer();
        }
        /// <summary>
        /// Переход к тестам
        /// </summary>
        private void Tests_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Content = new Tests();
        }
        /// <summary>
        /// Страница с результатами 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Results_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Content = new Results();
        }

        /// <summary>
        /// Выход из аккаунта и переход к окну Меню
        /// </summary>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {//Выход из аккаунта
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage image = MessageBoxImage.Question;
            MessageBoxResult result;
            result = MessageBox.Show("Выйти из аккаунта?",
                "Выход", button, image, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                Menu Menu = new Menu();
                Menu.Show();
                this.Close();
            }
        }
        /// <summary>
        /// Переход к странице со словарем
        /// </summary>
        private void Dictionary_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Content = new Dictionary(); //Переход к странице со словарем
        }
    }
}
