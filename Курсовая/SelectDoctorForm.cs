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
    public partial class SelectDoctorForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        public List<pacient> pacients = new List<pacient>();
        public List<feedback> feedbacks = new List<feedback>();

        public SelectDoctorForm()
        {
            InitializeComponent();
            FillForm show = new FillForm();
            show.FillDoctors(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<doctor> query = (from d in db.doctor
                                  select d).ToList();

            if (dataGridView1.SelectedCells.Count == 1)
            {
                if (Application.OpenForms.Count == 3)
                {
                    doctor item = query.First(w => w.surname.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

                    AppointmentForm f = new AppointmentForm(item);
                    f.Owner = this;
                    f.Show();
                }
                else Application.OpenForms[2].Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<pacient> query = (from p in db.pacient
                                  select p).ToList();

            if (dataGridView1.SelectedCells.Count == 1)
            {
                if (Application.OpenForms.Count == 3)
                {
                    pacient item = query.First(w => w.surname.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

                    FeedbackForm f = new FeedbackForm(item);
                    f.Owner = this;
                    f.Show();
                }
                else Application.OpenForms[2].Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
