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
    public partial class PacientStatusForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        pacient item;

        public PacientStatusForm(pacient pac)
        {
            item = pac;
            InitializeComponent();
            textBox1.Text = item.status.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = ((DoctorsForm)Owner).db.pacient.SingleOrDefault(w => w.id_pacient == item.id_pacient);
            result.status = item.status;
            ((DoctorsForm)Owner).pacients = ((DoctorsForm)Owner).db.pacient.OrderBy(o => o.id_pacient).ToList();

            this.Close();
        }
    }
}
