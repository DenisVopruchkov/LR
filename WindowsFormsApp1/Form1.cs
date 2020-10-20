using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static string line = "счастья,здоровья,хорошего настроения,продвижения по службе,долголетия,денег";
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
            int n = rand.Next(1, list.Length), j;
            string[] temp = new string[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                temp[i] = list[i];
            }
            string res = "";
            while (n != 0)
            {
                j = rand.Next(0, temp.Length - 1);
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
    }
}
