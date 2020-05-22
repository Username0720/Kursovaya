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
    public partial class DoctorsForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        public List<pacient> pacients = new List<pacient>();
        doctor item;

        public DoctorsForm(doctor doc)
        {
            item = doc;
            InitializeComponent();

            textBox1.Text = item.surname.ToString() + " " + item.name.ToString();
            textBox2.Text = item.number.ToString();
            textBox3.Text = item.hours.ToString();

            pacients = (from p in db.pacient
                        select p).ToList();

            var query1 = (from p in pacients
                          where p.id_doctor == item.id_doctor
                          orderby p.id_pacient
                          select new { p.surname, p.name, p.number, p.polis, p.passport, p.addres, p.status }).ToList();

            dataGridView1.DataSource = query1;
            dataGridView1.ReadOnly = true;

            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Номер телефона";
            dataGridView1.Columns[3].HeaderText = "Полис";
            dataGridView1.Columns[4].HeaderText = "Серия номер пасспорта";
            dataGridView1.Columns[5].HeaderText = "Адрес проживания";
            dataGridView1.Columns[6].HeaderText = "Лечение";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<pacient> query = (from p in db.pacient
                                   select p).ToList();

            if (dataGridView1.SelectedCells.Count == 1)
            {
                if (Application.OpenForms.Count == 1)
                {
                    pacient item = query.First(w => w.surname.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());

                    EditPacientForm editP = new EditPacientForm(item);
                    editP.Owner = this;
                    editP.Show();
                }
                else Application.OpenForms[0].Focus();
            }
        }
    }
}
