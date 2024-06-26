using System;
using System.Windows.Forms;

namespace OssetianCrossword
{
    public partial class FormEndGame : Form
    {
        public FormEndGame()
        {
            InitializeComponent();
        }

        private void buttonEndGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
