using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFSpells
{
    public partial class ErrorWindow : Form
    {
        public ErrorWindow(List<string> failedSpells)
        {
            InitializeComponent();
            string combined = String.Join(",\r\n", failedSpells.ToArray());
            textBox1.Text = combined;
            if (failedSpells.Count == 1)
                label2.Text = "The following spell failed";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
