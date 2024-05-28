using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OssetianCrossword
{
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();

            // добавляем 30 строк в нашей таблице для кроссворда
            for (int i = 0; i < 18; i++)
            {
                crosswordField.Rows.Add();
                crosswordField.Rows[i].Height = 30;

            }

            // считываем файл со словами кроссворда
            StreamReader SR = new StreamReader("Crosswords/Animals.txt");

            // создаем объект класса Crossword
            Crossword crossword = new Crossword();

            // считываем слова из файла со словами, создаем объекты класса Word, добавляем их в объект класса Crossword
            string s = "";
            while ((s = SR.ReadLine()) != null)
            {
                string[] args = s.Trim().Split('_');
                int number = Convert.ToInt32(args[0]);
                int x = Convert.ToInt32(args[1]);
                int y = Convert.ToInt32(args[2]);
                int count = Convert.ToInt32(args[3]);
                string direction = args[4];
                string ossetianWord = args[5];
                string russianWord = args[6];
                Word word = new Word(number, x, y, count, direction, ossetianWord, russianWord);
                crossword.AddWord(word);
            }
        }
    }
}
