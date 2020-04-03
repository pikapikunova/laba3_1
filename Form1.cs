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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Entity> books = new List<Entity>();
        Entity book = new Entity();
        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\Nasty\source\repos\WindowsFormsApp2\WindowsFormsApp2\Read.txt", System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] { ';' });
                    bool q = book.check(words, book);
                    if (q == true)
                        dataGridView1.Rows.Add(words);
                    else
                    {
                        this.Close();
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.Owner = this;
            secondForm.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Form3 thirdForm = new Form3();
                thirdForm.Owner = this;
                thirdForm.textBox1.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                thirdForm.textBox2.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                thirdForm.textBox3.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                thirdForm.dateTimePicker1.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                thirdForm.dateTimePicker2.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                thirdForm.comboBox1.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
                thirdForm.textBox4.Text = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
                thirdForm.Show();
        }
    }


    private void button2_Click(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow != null)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }
    }

    private void button4_Click_1(object sender, EventArgs e)
    {
        using (StreamWriter sr = new StreamWriter(@"C:\Users\Nasty\source\repos\WindowsFormsApp2\WindowsFormsApp2\Out.txt", false, System.Text.Encoding.Default))
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                string str = "";
                for (int j = 0; j < 7; j++)
                {
                    str += dataGridView1[j, i].Value.ToString() + ';';
                }
                str = str.Substring(0,str.Length - 1);
                sr.WriteLine(str);
            }
        }
        this.Close();
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            button4_Click_1(sender, e);
        }


        private void toolStripMenuItem7_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            button4_Click_1(sender, e);
        }
    }
}
public class Entity
{
    public int ID
    {
        get; set;
    }

    public string FIO
    { get; set; }

    public string Name
    { get; set; }

    public DateTime DateOfIssue
    { get; set; }

    public DateTime ControlDate
    { get; set; }

    public bool Return
    { get; set; }

    public float Mark
    { get; set; }

    public bool isInt(string str)
    {
        int num;
        bool isNum = int.TryParse(str, out num);
        if (isNum)
            return true;
        else
            return false;
    }

    public bool isFloat(string str)
    {
        float num;
        bool isNum = float.TryParse(str, out num);
        if (isNum)
            return true;
        else
            return false;
    }

    public bool check(string[] str, Entity book1)
    {
        bool l = true;

        if (book1.isInt(str[0]) == true)
            book1.ID = int.Parse(str[0]);
        else
        {
            MessageBox.Show("Не является числом");
            l = false;
        }

        string[] word = str[1].Split(new char[] { ' ' });
        if (word.Length != 2)
        {
            MessageBox.Show("Не является ФИО");
            l = false;
        }
        else
            book1.FIO = str[1];

        book1.Name = str[2];

        book1.DateOfIssue = DateTime.Parse(str[3]);

        if (DateTime.Parse(str[4]) < DateTime.Parse(str[3]))
        {
            MessageBox.Show("Контрольная дата не может быть меньше даты выдачи книги");
            l = false;
        }
        else
            book1.ControlDate = DateTime.Parse(str[4]);

        book1.Return = bool.Parse(str[5]);

        if (book1.isFloat(str[6]))
        {

            if (float.Parse(str[6]) < 0 || float.Parse(str[6]) > 5.0)
            {
                MessageBox.Show("Выходит за рамки допустимых значений");
                l = false;
            }
            else
            {
                book1.Mark = float.Parse(str[6]);
            }
        }
        else
        {
            MessageBox.Show("Не является числом с плавающей точкой");
            l = false;
        }
        return l;
}
}


   


