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

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Entity book1 = new Entity();

        private void button1_Click(object sender, EventArgs e)
        {
            string[] words = { textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text, dateTimePicker2.Text, comboBox1.Text, textBox4.Text };

            if (book1.check(words, book1) == true)
            {
                string str = textBox1.Text + ';' + textBox2.Text + ';' + textBox3.Text + ';' + dateTimePicker1.Text + ';' + dateTimePicker2.Text + ';' + comboBox1.Text + ';' + textBox4.Text;

                using (StreamWriter sw = new StreamWriter(@"C: \Users\Nasty\source\repos\WindowsFormsApp2\WindowsFormsApp2\Out.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(str);
                }
                Form1 main = this.Owner as Form1;
                if (main != null)
                {
                    main.dataGridView1.Rows.Add(words);
                }
                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
