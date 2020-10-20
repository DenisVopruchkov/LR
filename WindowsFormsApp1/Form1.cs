using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static string line = "счастья,здоровья,хорошего настроения,продвижения по службе,долголетия,денег,любви,силы,большого энтузиазма,терпения,новых треков Оксимирона,красоты вокруг";
        string[] list = line.Split(',');

        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
            {
                button1.Enabled = true;
                сгенерироватьToolStripMenuItem.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                сгенерироватьToolStripMenuItem.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jopa = "";
            jopa += "Дорогой(ая) "+textBox1.Text+"!\n";
            jopa += "Поздравляем Вас с праздником "+textBox2.Text;
            jopa += "! Желаем " + Gen() + ".";
            richTextBox1.Text = jopa;
        }

        public string Gen()
        {
            Random rand = new Random();
            int n = rand.Next(1, list.Length+1), j;
            string[] temp = new string[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                temp[i] = list[i];
            }
            string res = "";
            while (n != 0)
            {
                j = rand.Next(0, temp.Length);
                res += temp[j] + ", ";
                for(int i = j; i < temp.Length - 2; i++)
                {
                    temp[i] = temp[i + 1];
                }
                Array.Resize(ref temp, temp.Length - 1);
                n--;
            }
            res = res.Remove(res.Length-2, 2);
            return res;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar==' ') && !(e.KeyChar == (char)Keys.Back)) e.Handled=true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (button1.Enabled) button1_Click(button1, new EventArgs());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            label3.Visible = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Visible = false;
            timer1.Stop();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == ' ') && !(e.KeyChar == (char)Keys.Back)
                && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}
