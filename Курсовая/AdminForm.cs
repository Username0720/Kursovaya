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
            doctors = (from d in db.doctor
                       select d).ToList();

            var query = (from d in doctors
                         orderby d.id_doctor
                         select new { d.surname, d.name, d.number, d.hours }).ToList();

            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;

            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Номер телефона";
            dataGridView1.Columns[3].HeaderText = "Отработанные часы";

            pacients = (from p in db.pacient
                       select p).ToList();

            var query1 = (from p in pacients
                         orderby p.id_pacient
                         select new { p.surname, p.name, p.number, p.polis, p.passport, p.addres, p.status }).ToList();

            dataGridView2.DataSource = query1;
            dataGridView2.ReadOnly = true;

            dataGridView2.Columns[0].HeaderText = "Фамилия";
            dataGridView2.Columns[1].HeaderText = "Имя";
            dataGridView2.Columns[2].HeaderText = "Номер телефона";
            dataGridView2.Columns[3].HeaderText = "Полис";
            dataGridView2.Columns[4].HeaderText = "Серия номер пасспорта";
            dataGridView2.Columns[5].HeaderText = "Адрес проживания";
            dataGridView2.Columns[6].HeaderText = "Лечение";

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
            doctors = (from d in db.doctor
                       select d).ToList();

            var query = (from d in doctors
                         orderby d.id_doctor
                         select new { d.surname, d.name, d.number, d.hours }).ToList();

            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;

            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Номер телефона";
            dataGridView1.Columns[3].HeaderText = "Отработанные часы";

            pacients = (from p in db.pacient
                        select p).ToList();

            var query1 = (from p in pacients
                          orderby p.id_pacient
                          select new { p.surname, p.name, p.number, p.polis, p.passport, p.addres, p.status }).ToList();

            dataGridView2.DataSource = query1;
            dataGridView2.ReadOnly = true;

            dataGridView2.Columns[0].HeaderText = "Фамилия";
            dataGridView2.Columns[1].HeaderText = "Имя";
            dataGridView2.Columns[2].HeaderText = "Номер телефона";
            dataGridView2.Columns[3].HeaderText = "Полис";
            dataGridView2.Columns[4].HeaderText = "Серия номер пасспорта";
            dataGridView2.Columns[5].HeaderText = "Адрес проживания";
            dataGridView2.Columns[6].HeaderText = "Лечение";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
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
                if (Application.OpenForms.Count == 1)
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
            if (Application.OpenForms.Count == 1)
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
                if (Application.OpenForms.Count == 1)
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
