using System;
using System.IO;
using System.Windows.Forms;

namespace Task_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string defaultPath = "q2.rtf.gz";

        private void GetTextButton_Click(object sender, EventArgs e)
        {
            var opfd = new OpenFileDialog();
            if (File.Exists(defaultPath))
            {
                richTextBox1.Rtf = GZIPTextReader.LoadGZippedText(defaultPath);
            }
            else if (opfd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Rtf = GZIPTextReader.LoadGZippedText(opfd.FileName);
            }
        }
    }
}