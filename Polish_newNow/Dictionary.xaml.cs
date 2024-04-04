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
    /// Вывод данных из БД таблицы - DictPolsk
    /// с дальнейшим корректным выводом на страницу Dictionary.xaml
    /// </summary>
    /// <param name="dict">Список содержимого словаря</param>
    public partial class Dictionary : Page
    {
        public Dictionary()
        {
            InitializeComponent();
            
            List<PolishDictionary> dict; 
            dict = MyDataBase.DictionaryBatch();
            // i = 0int;
            for (int i=0; i<dict.Count; i++)
            {
                TextBlockDictionary.Text += dict[i].ID + " ";
                TextBlockDictionary.Text += dict[i].PolishWord + " ";
                TextBlockDictionary.Text += dict[i].Transcript + " ";
                TextBlockDictionary.Text += dict[i].RusWord + "\n";
            }  
        }
    }
}
