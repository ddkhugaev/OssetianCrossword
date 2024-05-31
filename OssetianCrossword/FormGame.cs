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
        // обработчик нажатий на кнопки экранной клавиатуры
        private void AlphabetButtonOnClick(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;
            crosswordField.CurrentCell.Value = button.Text;
            int y = crosswordField.CurrentCell.RowIndex;
            int x = crosswordField.CurrentCell.ColumnIndex + 1;
            crosswordField.CurrentCell = crosswordField[x, y];
        }
        public FormGame()
        {
            InitializeComponent();

            // добавляем 18 строк в нашей таблице для кроссворда
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

            // записываем номер в начальную ячейку слова, закрашиваем ячейки слова белым цветом (бета)
            for (int i = 0; i < crossword.GetLen(); i++)
            {
                int[] xy = crossword[i].GetXY();
                int x = xy[0];
                int y = xy[1];
                int wordLen = crossword[i].GetLen();
                string wordDirect = crossword[i].GetDirection();
                crosswordField[x, y].Value = crossword[i].GetNumber();

                for (int j = 0; j < wordLen; j++)
                {
                    crosswordField[x, y].Style.BackColor = Color.White;
                    if (wordDirect == "right")
                    {
                        x++;
                    }
                    else
                    {
                        y++;
                    }
                }
            }

            // добавление экранной клавиатуры
            string[] alphabet = "А Ӕ Б В Г Гъ Д Дз Дж Е Ё Ж З И Й К Къ Л М Н О П Пъ Р С Т Тъ У Ф Х Хъ Ц Цъ Ч Чъ Ш Щ ъ ы ь Э Ю Я".Split();
            int ind = 0;
            int top = 380;
            int left = 620;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i == 3 && j == 10)
                    {
                        break;
                    }
                    Button button = new Button();
                    button.Left = left;
                    button.Top = top;
                    button.Height = 40;
                    button.Width = 40;
                    button.Name = "btn" + i;
                    button.Text = alphabet[ind];
                    ind++;

                    button.Click += AlphabetButtonOnClick;

                    this.Controls.Add(button);
                    left += button.Width + 2;

                }
                left = 620;
                top += 42;
            }
        }
    }
}
