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
            if (crosswordField.CurrentCell.Style.BackColor == Color.White)
            {
                crosswordField.CurrentCell.Value = button.Text;
                CheckCorrectWord(crosswordField, hintField);
                ChangeCurrentCell(crosswordField);
            }
            else if (crosswordField.CurrentCell.Style.BackColor == Color.Lime)
            {
                ChangeCurrentCell(crosswordField);
            }
        }

        // авто-смена выбранной ячейки
        static void ChangeCurrentCell(DataGridView crosswordField)
        {
            int x = crosswordField.CurrentCell.ColumnIndex;
            int y = crosswordField.CurrentCell.RowIndex;
            if (lastDirect == "right")
            {
                if (crosswordField[x + 1, y].Style.BackColor == Color.White || crosswordField[x + 1, y].Style.BackColor == Color.Lime)
                {
                    x++;
                    lastDirect = "right";
                }
                else if (crosswordField[x, y + 1].Style.BackColor == Color.White || crosswordField[x, y + 1].Style.BackColor == Color.Lime)
                {
                    y++;
                    lastDirect = "down";
                }

            }
            else if (lastDirect == "down")
            {
                if (crosswordField[x, y + 1].Style.BackColor == Color.White || crosswordField[x, y + 1].Style.BackColor == Color.Lime)
                {
                    y++;
                    lastDirect = "down";
                }
                else if (crosswordField[x + 1, y].Style.BackColor == Color.White || crosswordField[x + 1, y].Style.BackColor == Color.Lime)
                {
                    x++;
                    lastDirect = "right";
                }
            }
            crosswordField.CurrentCell = crosswordField[x, y];
        }

        // проверка правильности всех введенных слов в кроссворде
        static void CheckCorrectWord(DataGridView crosswordField, DataGridView hintField)
        {
            for (int i = 0; i < crossword.GetLen(); i++)
            {
                Word word = crossword[i];
                int[] xy = word.GetXY();
                int x = xy[0];
                int y = xy[1];
                string direct = word.GetDirection();
                string[] ossetianWord = word.GetOssetianWord();
                int count = word.GetLen();
                int number = word.GetNumber();
                for (int j = 0; j < count; j++)
                {
                    if (Convert.ToString(crosswordField[x, y].Value).ToLower() == Convert.ToString(ossetianWord[j]))
                    {
                        if (direct == "right")
                        {
                            x++;
                        }
                        else
                        {
                            y++;
                        }
                        if (j == count - 1)
                        {
                            FillGreenCell(xy[0], xy[1], count, direct, crosswordField);
                            FillGreenHint(number, hintField);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        // закрашивание подсказок, которые уже не нужны
        static void FillGreenHint(int number, DataGridView hintField)
        {
            hintField[1, number - 1].Style.BackColor = Color.Lime;
        }

        // закрашивание правильных слов в зеленый
        static void FillGreenCell(int x, int y, int count, string direct, DataGridView crosswordField)
        {
            for (int i = 0; i < count; i++)
            {
                crosswordField[x, y].Style.BackColor = Color.Lime;
                if (direct == "right")
                {
                    x++;
                }
                else
                {
                    y++;
                }
            }
        }

        // создаем объект класса Crossword
        static Crossword crossword = new Crossword();

        // создаем переменную, хранящую последнее направление перемещения курсора
        static string lastDirect = "right";
        public FormGame(string path)
        {
            InitializeComponent();

            // добавляем 18 строк в нашей таблице для кроссворда
            for (int i = 0; i < 18; i++)
            {
                crosswordField.Rows.Add();
                crosswordField.Rows[i].Height = 30;

            }

            // считываем файл со словами кроссворда
            StreamReader SR = new StreamReader(path);

            string crosswordName = SR.ReadLine();

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
                crosswordField[x, y].ToolTipText = Convert.ToString(crossword[i].GetNumber());

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

            // записываем подсказки в таблицу подсказок
            for (int i = 0; i < crossword.GetLen(); i++)
            {
                hintField.Rows.Add();
                hintField[0, i].Value = Convert.ToString(i + 1);
                hintField[1, i].Value = crossword[i].GetRussianWord();
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
                    Button button = new Button();
                    button.Left = left;
                    button.Top = top;
                    button.Height = 40;
                    button.Width = 40;
                    button.Name = "btn" + i;
                    if (i == 3 && j == 10)
                    {
                        button.Text = "<-";
                        button.Visible = false;
                    }
                    else
                    {
                        button.Text = alphabet[ind];
                    }
                    ind++;

                    button.Click += AlphabetButtonOnClick;

                    this.Controls.Add(button);
                    left += button.Width + 2;

                }
                left = 620;
                top += 42;
            }
        }

        private void FormGame_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            hintField.Rows.Clear();
        }
    }
}
