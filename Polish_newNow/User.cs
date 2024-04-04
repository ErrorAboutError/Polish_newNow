using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polish_newNow
{
    public class User : INotifyPropertyChanged
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public static string Name { get; set; }
        public static string Avatar { get; set; }
        public string Password { get; set; }

        public string ResultTests { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //public string name
        //{
        //    get { return Name; }
        //    set
        //    {
        //        // Устанавливаем новое значение
        //        name = value;

        //    }
        //}

        public User()
        {
            Name = "Default";
        }
        public User(string avatar, int temp)
        {
            Avatar = avatar;

        }
        public User(string SomethingName)
        {
            Name = SomethingName;
        }
    }
}
