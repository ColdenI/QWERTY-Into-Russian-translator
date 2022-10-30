using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace QWERTY_ЙЦУКЕН_keyboard
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://akylinandrej.wixsite.com/colden-i");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://akylinandrej.wixsite.com/colden-i");
        }
    }
}
