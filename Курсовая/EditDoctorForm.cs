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
    public partial class EditDoctorForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        doctor item;

        public EditDoctorForm(doctor doc)
        {
            item = doc;
            InitializeComponent();

            textBox1.Text = item.surname.ToString();
            textBox2.Text = item.name.ToString();
            textBox3.Text = item.number.ToString();
            textBox4.Text = item.login.ToString();
            textBox5.Text = item.pas.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter s = new StreamWriter(@"doctors.txt");
            var result = ((AdminForm)Owner).db.doctor.SingleOrDefault(w => w.id_doctor == item.id_doctor);
            result.surname = textBox1.Text.ToString();
            result.name =    textBox2.Text.ToString();
            result.number =  textBox3.Text.ToString();
            result.login =   textBox4.Text.ToString();
            result.pas =     textBox5.Text.ToString();

            ((AdminForm)Owner).doctors = ((AdminForm)Owner).db.doctor.OrderBy(o => o.id_doctor).ToList();

            this.Close();
        }
    }
}
