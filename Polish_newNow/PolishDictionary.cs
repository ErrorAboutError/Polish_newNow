using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polish_newNow
{
    /// <summary>
    /// Класс содержит поля -  составляющие словаря, 
    /// необходим при загрузке страницы Dictionary.xaml
    /// </summary>
    public class PolishDictionary
    {
        public string ID { get; set; }
        public string PolishWord { get; set; }
        public string Transcript { get; set; }
        public string RusWord { get; set; }

        public PolishDictionary()
        {
            ID = "def";
            PolishWord = "def";
            Transcript = "def";
            RusWord = "def";
        }

        public PolishDictionary(string id, string polishword, string transript, string rusword)
        {
            ID = id;
            PolishWord = polishword;
            Transcript = transript;
            RusWord = rusword;
        }
    }
}
