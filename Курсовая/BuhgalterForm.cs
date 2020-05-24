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
        public List<otchet_zp> zp = new List<otchet_zp>();

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
                ReportsForm r = new ReportsForm();
                r.Owner = this;
                r.Show();
            }
            else Application.OpenForms[2].Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                List<otchet_zp> query = (from z in db.otchet_zp
                                      select z).ToList();
                otchet_zp item = query.First(w => w.id_doctor.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                AddSalaryForm s = new AddSalaryForm(item);
                s.Owner = this;
                s.Show();
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
