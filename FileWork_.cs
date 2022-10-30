using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace QWERTY_ЙЦУКЕН_keyboard
{
    class FileWork_
    {
        public string programmName = "QWERTY -> ЙЦУКЕН";
        static Form1 mainForm;
        /*
                public static void CreateFile(ref RichTextBox textBox1, ref bool tbChange, ref string docPath) // Метод "Создать новый документ"
                {
                    textBox1.Clear();
                    docPath = "";
                    tbChange = false;     
                }

                public static void OpenFile(ref RichTextBox notebox, ref bool tbChange, ref string docPath) // Метод "Открыть документ"
                {
                    try
                    {
                        string programmName = Properties.Settings.Default.programmName;
                        OpenFileDialog openDocument = new OpenFileDialog();
                        openDocument.Title = "Открыть текстовый документ";
                        openDocument.Filter = "Текстовые файлы (*.txt) |*.txt| Все файлы (*.*)|*.*";
                        if (openDocument.ShowDialog() == DialogResult.OK)
                        {
                            FileStream file = new FileStream(openDocument.FileName, FileMode.Open, FileAccess.Read);
                            StreamReader reader = new StreamReader(file, Encoding.Default);
                            notebox.Text = reader.ReadToEnd();
                            reader.Close();
                            docPath = openDocument.FileName;
                            tbChange = false;
                            MainForm.ActiveForm.Text = openDocument.SafeFileName + " — " + programmName;
                        }
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("Файл занят!\n Файл используется другой программой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
        */

        public static void SaveFile(ref RichTextBox notebox, ref bool tbChange, ref string docPath) // Метод "Сохранить документ"
        {
            FileStream file = new FileStream(docPath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file, Encoding.Default);
            writer.Write(notebox.Text);
            writer.Close();
            tbChange = false;
            
        }

        public static void SaveAsFile(ref RichTextBox notebox, ref bool tbChange, ref string docPath) // Метод "Сохранить документ как..."
        {
            SaveFileDialog saveAsDocument = new SaveFileDialog();
            saveAsDocument.Title = "Сохранить документ как...";
            saveAsDocument.FileName = "Текстовый документ";
            saveAsDocument.Filter = "Текстовые файлы (*.txt) |*.txt| Все файлы (*.*)|*.*";


            if (saveAsDocument.ShowDialog() == DialogResult.OK) //Если пользователь подтвердил сохранение
            {
                //Создаем файл по пути, выбранному в окне сохранения
                FileStream file = new FileStream(saveAsDocument.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(file, Encoding.Default);
                writer.Write(notebox.Text); //записываем содержимое в файл
                writer.Close(); //закрываем поток

                tbChange = false;
                docPath = saveAsDocument.FileName;
            }
            else
            {
                tbChange = true;
                return;
            }
        }

    }
}
