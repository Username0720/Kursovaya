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
    public partial class AdminForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        public List<doctor> doctors = new List<doctor>();
        public List<pacient> pacients = new List<pacient>();

        public AdminForm()
        {
            InitializeComponent();
            FillForm show = new FillForm();
            show.FillDoctors(dataGridView1);
            show.FillPacients(dataGridView2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FillForm show = new FillForm();
            show.FillDoctors(dataGridView1);
            show.FillPacients(dataGridView2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                AddPacientForm addP = new AddPacientForm();
                addP.Owner = this;
                addP.Show();
            }
            else Application.OpenForms[1].Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<pacient> query = (from p in db.pacient
                                   select p).ToList();

            if (dataGridView2.SelectedCells.Count == 1)
            {
                if (Application.OpenForms.Count == 2)
                {
                    pacient item = query.First(w => w.surname.ToString() == dataGridView2.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

                    EditPacientForm editP = new EditPacientForm(item);
                    editP.Owner = this;
                    editP.Show();
                }
                else Application.OpenForms[1].Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                AddDoctorForm addD = new AddDoctorForm();
                addD.Owner = this;
                addD.Show();
            }
            else Application.OpenForms[1].Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<doctor> query = (from d in db.doctor
                                   select d).ToList();

            if (dataGridView1.SelectedCells.Count == 1)
            {
                if (Application.OpenForms.Count == 2)
                {
                    doctor item = query.First(w => w.surname.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

                    EditDoctorForm editD = new EditDoctorForm(item);
                    editD.Owner = this;
                    editD.Show();
                }
                else Application.OpenForms[1].Focus();
            }
        }
    }
}
