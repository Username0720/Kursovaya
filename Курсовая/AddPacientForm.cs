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

namespace Курсовая
{
    public partial class AddPacientForm : Form
    {
        hospitalEntities db = new hospitalEntities();

        public AddPacientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter s = new StreamWriter(@"pacients.txt", true);
            int number_of_pacient = db.pacient.Max(n => n.id_pacient) + 1;

            pacient new_pacient = new pacient
            {
                id_pacient = number_of_pacient,
                surname = textBox1.Text,
                name = textBox2.Text,
                number = textBox3.Text,
                polis = textBox4.Text,
                passport = textBox5.Text,
                addres = textBox6.Text,
                login = textBox7.Text,
                pas = textBox8.Text
            };

            db.pacient.Add(new_pacient);
            s.Write(textBox7.Text + " ");
            s.WriteLine(textBox8.Text);
            s.Close();
            db.SaveChanges();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
