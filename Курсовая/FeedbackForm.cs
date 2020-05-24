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
    public partial class FeedbackForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        pacient item;

        public FeedbackForm(pacient pac)
        {
            item = pac;
            InitializeComponent();
            textBox1.Text = item.id_pacient.ToString();
            textBox2.Text = item.id_doctor.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = ((SelectDoctorForm)Owner).db.feedback.SingleOrDefault(w => w.id_pacient == item.id_pacient);
                result.id_pacient = Int32.Parse(textBox1.Text.ToString());
                result.id_doctor = Int32.Parse(textBox2.Text.ToString());
                result.description = textBox3.Text.ToString();

                ((SelectDoctorForm)Owner).feedbacks = ((SelectDoctorForm)Owner).db.feedback.OrderBy(o => o.id_pacient).ToList();
            }
            catch(Exception ee) { MessageBox.Show(ee.Message); }
        }
    }
}
