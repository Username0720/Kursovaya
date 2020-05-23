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
    public partial class AppointmentForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        List<doctor> doctors = new List<doctor>();
        doctor item;
        pacient pac;

        public AppointmentForm(doctor doc)
        {
            item = doc;
            InitializeComponent();
            textBox1.Text = item.name + " " + item.surname;
            textBox2.Text = item.number;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = ((SelectDoctorForm)Owner).db.pacient.SingleOrDefault(w => w.id_pacient == pac.id_pacient);
            result.id_doctor = item.id_doctor;

            ((SelectDoctorForm)Owner).pacients = ((SelectDoctorForm)Owner).db.pacient.OrderBy(o => o.id_pacient).ToList();

            this.Close();
        }
    }
}
