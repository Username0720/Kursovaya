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
    public partial class AddDoctorForm : Form
    {
        hospitalEntities db = new hospitalEntities();

        public AddDoctorForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter s = new StreamWriter(@"doctors.txt", true);
            int number_of_doctor = db.doctor.Max(n => n.id_doctor) + 1;

            doctor new_doctor = new doctor
            {
                id_doctor = number_of_doctor,
                surname = textBox1.Text,
                name = textBox2.Text,
                number = textBox3.Text,
                login = textBox4.Text,
                pas = textBox5.Text
            };

            db.doctor.Add(new_doctor);
            s.Write(textBox4.Text + " ");
            s.WriteLine(textBox5.Text);
            s.Close();
            db.SaveChanges();
            this.Close();
        }
    }
}
