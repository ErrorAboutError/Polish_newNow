using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polish_newNow
{
    public class AvatarClass
    {
        /// <summary>
        /// Класс для хранения аватарки пользователя,
        /// также содержит путь до картнки по умолчанию 
        /// (если пользователь не выберет аватарку сам)
        /// </summary>
        public string currentAvatarPath { get; set; }

        public AvatarClass()
        {
            currentAvatarPath = "/Images/defaultAvatar.png";
        }
    }
    
}
