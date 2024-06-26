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
