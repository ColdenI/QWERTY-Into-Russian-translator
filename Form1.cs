using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QWERTY_ЙЦУКЕН_keyboard
{
    public partial class Form1 : Form
    {

        private static char[] en = "`qwertyuiop[]asdfghjkl;'zxcvbnm,./~@#$%^&QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?".ToCharArray();
        private static char[] ru = "ёйцукенгшщзхъфывапролджэячсмитьбю.Ё\"№;%:?ЙЦУКЕНГШЩЗХЪ/ФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,".ToCharArray();

        public bool tbChange = false;
        public string docPath = "";

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string fileName) // Открытие программы документом
        {
            InitializeComponent();



            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                try
                {

                    FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(file, Encoding.Default);
                    richTextBox1.Text = reader.ReadToEnd();
                    reader.Close();
                    docPath = fileName;
                    tbChange = false;

                    richTextBox1.Select(0, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public void SaveOrAsSaveFile()
        {
            if (docPath != "")
            {
                FileWork_.SaveFile(ref richTextBox2, ref tbChange, ref docPath);
            }
            else
            {
                FileWork_.SaveAsFile(ref richTextBox2, ref tbChange, ref docPath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(richTextBox1.Text.Length > 0)) return;
            if (en.Length != ru.Length) return;
            
            char[] textIn = richTextBox1.Text.ToCharArray();
            char[] textOut = new char[textIn.Length];

            for (int i = 0; i < textIn.Length; i++)
            {
                if (en.Contains(textIn[i]))
                    for (int _i = 0; _i < en.Length; _i++)
                    {
                        if (textIn[i] == en[_i]) textOut[i] = ru[_i];
                        
                    }
                else textOut[i] = textIn[i];
            }

            string str = "";
            foreach (char ch in textOut) str += ch.ToString();

            richTextBox2.Text = str;
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(richTextBox1.Text.Length > 0)) return;
            if (en.Length != ru.Length) return;

            char[] textIn = richTextBox1.Text.ToCharArray();
            char[] textOut = new char[textIn.Length];

            for (int i = 0; i < textIn.Length; i++)
            {
                if (ru.Contains(textIn[i]))
                    for (int _i = 0; _i < ru.Length; _i++)
                    {
                        if (textIn[i] == ru[_i]) textOut[i] = en[_i];

                    }
                else textOut[i] = textIn[i];
            }

            string str = "";
            foreach (char ch in textOut) str += ch.ToString();

            richTextBox2.Text = str;
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = Properties.Settings.Default.Width;
            this.Height = Properties.Settings.Default.Height;

            Font font = Properties.Settings.Default.Font;
            richTextBox1.Font = font;
            richTextBox2.Font = font;

            richTextBox1.ZoomFactor = Properties.Settings.Default.ZoomFac1;
            richTextBox2.ZoomFactor = Properties.Settings.Default.ZoomFac2;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Font = richTextBox1.Font;
            Properties.Settings.Default.ZoomFac1 = richTextBox1.ZoomFactor;
            Properties.Settings.Default.ZoomFac2 = richTextBox2.ZoomFactor;

            Properties.Settings.Default.Save();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = richTextBox1.Font;
            DialogResult = fontDialog.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
                richTextBox2.Font = fontDialog.Font;
            }
        }

        private void поле1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = 1f;
        }

        private void поле2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.ZoomFactor = 1f;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveOrAsSaveFile();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileWork_.SaveAsFile(ref richTextBox2, ref tbChange, ref docPath);
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
            richTextBox1.Font = richTextBox2.Font;
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0) richTextBox1.Copy();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0) richTextBox1.Cut();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0) richTextBox1.SelectedText = "";
        }

        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S)) SaveOrAsSaveFile();
            if (keyData == (Keys.Control | Keys.V)) richTextBox1.Font = richTextBox2.Font;
            if (keyData == (Keys.Control | Keys.S | Keys.Shift)) FileWork_.SaveAsFile(ref richTextBox2, ref tbChange, ref docPath);
            if (keyData == (Keys.Alt | Keys.F4)) Application.Exit();


            //Console.WriteLine(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
