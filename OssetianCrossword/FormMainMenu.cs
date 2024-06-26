using System;
using System.IO;
using System.Windows.Forms;

namespace OssetianCrossword
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();

            // добавляем в комбобокс названия всех кроссвордов
            string[] allCrosswords = Directory.GetFiles("Crosswords");
            for (int i = 0; i < allCrosswords.Length; i++)
            {
                StreamReader SR = new StreamReader(allCrosswords[i]);
                comboBoxLevels.Items.Add(SR.ReadLine());
                SR.Close();
            }
            comboBoxLevels.SelectedItem = comboBoxLevels.Items[0];
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // при нажатии на кнопку Начать, создается и открывается новое окно с игрой
            string path = "";

            string[] allCrosswords = Directory.GetFiles("Crosswords");
            for (int i = 0; i < allCrosswords.Length; i++)
            {
                StreamReader SR = new StreamReader(allCrosswords[i]);
                string crosswordName = SR.ReadLine();
                SR.Close();
                if (crosswordName == comboBoxLevels.SelectedItem.ToString())
                {
                    path = allCrosswords[i];
                }
            }

            FormGame fg = new FormGame(path);
            fg.Show();
        }
    }
}
