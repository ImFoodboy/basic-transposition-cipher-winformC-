using System.IO;

namespace Transposition_cipher
{
    public partial class Form1 : Form
    {
        Transposition t;
        public Form1()
        {
            InitializeComponent();
            t = new Transposition();
        }
        OpenFileDialog openFile;
        SaveFileDialog saveFile;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(outputTextBox.Text);
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            t.SetKey(keyTextBox.Text);
            outputTextBox.Text = t.Encrypt(inputTextBox.Text);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            t.SetKey(keyTextBox.Text);
            outputTextBox.Text = t.Decrypt(inputTextBox.Text);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputTextBox.Text = "";
            inputTextBox.Text = "";
            keyTextBox.Text = "";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.Filter = "|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFile.FileName);
                inputTextBox.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFile = new SaveFileDialog();
            saveFile.Filter = "|*.txt";
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFile.FileName);
                sw.Write(outputTextBox.Text);
                sw.Close();
            }
        }
    }
}