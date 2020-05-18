using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Курсовая
{
    public partial class Form1 : Form
    {
        hospitalEntities db = new hospitalEntities();
        public List<pacient> pacientsheet;
        public List<doctor> doctorsheet;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*if ()
            {
                Form3 f3 = new Form3();
                f3.Owner = this;
                f3.Show();
            }*/

            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                Form6 f6 = new Form6();
                f6.Owner = this;
                f6.Show();
            }

            if (textBox1.Text == "buhgalter" && textBox2.Text == "buhgalter")
            {
                Form5 f5 = new Form5();
                f5.Owner = this;
                f5.Show();
            }

            else
            {
                label4.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
