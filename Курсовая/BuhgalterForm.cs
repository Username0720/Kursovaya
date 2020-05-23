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

        public BuhgalterForm()
        {
            InitializeComponent();
            FillForm show = new FillForm();
            show.FillDoctors(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                //doctor item = query.First(w => w.surname.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                //otchet_zp zp = query.First(w => w.surname.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                //AddSalaryForm s = new AddSalaryForm();
                //s.Owner = this;
                //s.Show();
            }
            else Application.OpenForms[2].Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                //AddSalaryForm s = new AddSalaryForm();
                //s.Owner = this;
                //s.Show();
            }
            else Application.OpenForms[2].Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                ReportsForm r = new ReportsForm();
                r.Owner = this;
                r.Show();
            }
            else Application.OpenForms[2].Focus();
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
