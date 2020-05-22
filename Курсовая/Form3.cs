using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            if (textBox1.Text == "")
            {
                button5.Visible = false;
            }

            Form1 f1 = new Form1();

            Autorization user = new Autorization(f1.log, f1.pass);
            textBox6.Text = user.FillingForm();
            //user.FillingForm();
            /*string[] array = user.FillingForm().Split(',');
            if (user.CheckFill() == true)
            {
                textBox1.Text = array[0] + array[1];
                textBox2.Text = array[2];
                textBox3.Text = array[3];
                textBox4.Text = array[4];
                textBox5.Text = array[5];
                textBox6.Text = array[6];
            }
            else
            {
                textBox1.Text = array[0] + array[1];
                textBox2.Text = array[2];
                textBox3.Text = array[7];
            }*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Owner = this;
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Owner = this;
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();
        }
    }
}
