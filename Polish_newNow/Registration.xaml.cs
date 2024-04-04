using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Открытие окна Регстрации
    /// </summary>
    public partial class Registration : Window
    {
        AvatarClass currentAvatar; //Определение автара пользователя
        public Registration()
        {
            InitializeComponent();
            currentAvatar = new AvatarClass();
        }
        /// <summary>
        /// Открытие проводника и сохранение картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Avatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Изображение-файл (*.jpg)|*.jpg|Все файлы (*.*)|*.*";
            fileDialog.FilterIndex = 0;
            fileDialog.DefaultExt = "png";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            fileDialog.Title = "Установление аватарки";

            if (fileDialog.ShowDialog() != true) return;

            currentAvatar.currentAvatarPath = fileDialog.FileName;
            ImageBox.Source = new BitmapImage(new Uri(currentAvatar.currentAvatarPath));
            User AvatarNew = new User(ImageBox.Source.ToString(), 1);
        }
        /// <summary>
        /// Возвращение к окну Меню Menu.xaml
        /// </summary>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Menu Menu = new Menu();
            Menu.Show();
            this.Close();
        }
        /// <summary>
        /// Действия, осущствляемые программой после нажатия кнопки "Зарегистрироваться"
        /// </summary>
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (ImageBox.Source == null)
            {
                currentAvatar.currentAvatarPath = Environment.CurrentDirectory + @"\defaultAvatar.png"; //Комбинируется
                                                                                                        //путь до exe-файла к
                                                                                                        //до дефолтной картинки
                ImageBox.Source = new BitmapImage(new Uri(currentAvatar.currentAvatarPath)); //Записываем картинку
                User AvatarNew = new User(ImageBox.Source.ToString(), 1); //Заносим картинку в класс User
            }
            //Регулярное выражение проверки почты
            string regEmail = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))";
            //Проверка введенных данных, занесение их в Базу данных, обработка возникающих исключений, ошибок
            if ((Regex.IsMatch(EmailBox.Text, regEmail, RegexOptions.IgnoreCase) && (EmailBox.Text.Length <= 30 && EmailBox.Text.Length > 0)) &&
                (NameBox.Text.Length > 0 && NameBox.Text.Length <= 30) && (PasswordBox.Text.Length > 0 && PasswordBox.Text.Length <= 30))
            {
                try
                {
                    MyDataBase.RegistrationDB(EmailBox.Text, NameBox.Text, currentAvatar.currentAvatarPath, PasswordBox.Text);

                    User NewUser = new User(NameBox.Text); //Запись имени входящего пользователя для отображения его имени в TextBox
                    if (ImageBox.Source != null)
                    {
                        User NewAvatar = new User(NameBox.Text, 1); //Загрузка картинки
                    }
                    else
                    {
                        ImageBox.Source = new BitmapImage(new Uri("/Images/defaultAvatar.png"));
                        User NewAvatar = new User(NameBox.Text, 1); //Загрузка картинки
                    }
                    // NavigationService.Navigate(new Entry());
                    MainPage MainPage = new MainPage();
                    MainPage.Show();
                    this.Close();
                }
                catch
                {
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage image = MessageBoxImage.Error;
                    MessageBoxResult result;
                    result = MessageBox.Show("Возможно данный логин уже существует!",
                        "Problem", button, image, MessageBoxResult.OK);

                    Registration Registr = new Registration();
                    Registr.Show();
                    this.Close();
                }
            }
            else
            {
                if (!(Regex.IsMatch(EmailBox.Text, regEmail, RegexOptions.IgnoreCase)))
                {
                    MessageBoxButton buttonEmail = MessageBoxButton.OK;
                    MessageBoxImage imageEmail = MessageBoxImage.Error;
                    MessageBoxResult resultEmail;
                    resultEmail = MessageBox.Show("Почта не соотвествует стандартам",
                        "Problem", buttonEmail, imageEmail, MessageBoxResult.OK);
                    Registration Registr = new Registration();
                    Registr.Show();
                    this.Close();
                }
                else if (EmailBox.Text.Length >= 30)
                {
                    MessageBoxButton buttonEmail_2 = MessageBoxButton.OK;
                    MessageBoxImage imageEmail_2 = MessageBoxImage.Error;
                    MessageBoxResult result_Email_2;
                    result_Email_2 = MessageBox.Show("Общее количество символов в почте не должно превышать 30 символов!",
                        "Problem", buttonEmail_2, imageEmail_2, MessageBoxResult.OK);

                    Registration Registr = new Registration();
                    Registr.Show();
                    this.Close();
                }
                else if (EmailBox.Text.Length <= 0)
                {
                    MessageBoxButton buttonEmail_2 = MessageBoxButton.OK;
                    MessageBoxImage imageEmail_2 = MessageBoxImage.Error;
                    MessageBoxResult result_Email_2;
                    result_Email_2 = MessageBox.Show("Где Ваша почта?",
                        "Problem", buttonEmail_2, imageEmail_2, MessageBoxResult.OK);

                    Registration Registr = new Registration();
                    Registr.Show();
                    this.Close();
                }
                else if (NameBox.Text.Length <= 0)
                {
                    MessageBoxButton buttonEmail_2 = MessageBoxButton.OK;
                    MessageBoxImage imageEmail_2 = MessageBoxImage.Error;
                    MessageBoxResult result_Email_2;
                    result_Email_2 = MessageBox.Show("Где Ваше имя?",
                        "Problem", buttonEmail_2, imageEmail_2, MessageBoxResult.OK);

                    Registration Registr = new Registration();
                    Registr.Show();
                    this.Close();
                }
                else if (NameBox.Text.Length >= 0)
                {
                    MessageBoxButton buttonEmail_3 = MessageBoxButton.OK;
                    MessageBoxImage imageEmail_3 = MessageBoxImage.Error;
                    MessageBoxResult result_Email_3;
                    result_Email_3 = MessageBox.Show("Имя превышает 30 символов!",
                        "Problem", buttonEmail_3, imageEmail_3, MessageBoxResult.OK);

                    Registration Registr = new Registration();
                    Registr.Show();
                    this.Close();
                }
                else if (PasswordBox.Text.Length >= 0)
                {
                    MessageBoxButton buttonPass_2 = MessageBoxButton.OK;
                    MessageBoxImage imagePass_2 = MessageBoxImage.Error;
                    MessageBoxResult result_Pass_2;
                    result_Pass_2 = MessageBox.Show("Имя превышает 30 символов!",
                        "Problem", buttonPass_2, imagePass_2, MessageBoxResult.OK);

                    Registration Registr = new Registration();
                    Registr.Show();
                    this.Close();
                }
                else if (PasswordBox.Text.Length <= 30)
                {
                    MessageBoxButton buttonPass_2 = MessageBoxButton.OK;
                    MessageBoxImage imagePass_2 = MessageBoxImage.Error;
                    MessageBoxResult result_Pass_2;
                    result_Pass_2 = MessageBox.Show("Пароль превышает 30 символов!",
                        "Problem", buttonPass_2, imagePass_2, MessageBoxResult.OK);

                    Registration Registr = new Registration();
                    Registr.Show();
                    this.Close();
                }
            }
        }
    }
}
