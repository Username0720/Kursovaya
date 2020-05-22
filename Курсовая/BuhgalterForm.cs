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
    public partial class BuhgalterForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        public List<doctor> doctors = new List<doctor>();
        public List<feedback> feedbacks = new List<feedback>();

        public BuhgalterForm()
        {
            InitializeComponent();

            doctors = (from d in db.doctor
                       select d).ToList();

            var query = (from d in doctors
                         orderby d.id_doctor
                         select new { d.id_doctor, d.surname, d.name, d.number, d.hours}).ToList();

            dataGridView1.DataSource = query;
            dataGridView1.ReadOnly = true;

            dataGridView1.Columns[0].HeaderText = "Идентификатор";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Номер";
            dataGridView1.Columns[4].HeaderText = "Количество отработанных часов";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                ReportsForm r = new ReportsForm();
                r.Owner = this;
                r.Show();
            }
            else Application.OpenForms[2].Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
