using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OssetianCrossword
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
            comboBoxLevels.Items.Add("Животные");
            comboBoxLevels.Items.Add("Еда");
            comboBoxLevels.SelectedItem = comboBoxLevels.Items[0];
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // при нажатии на кнопку Начать, создается и открывается новое окно с игрой
            string level = comboBoxLevels.SelectedItem.ToString();
            string path = "";
            if (level == "Животные")
            {
                path = "Crosswords/Animals.txt";
            }
            FormGame fg = new FormGame(path);
            fg.Show();
        }
    }
}
