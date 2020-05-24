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
    public partial class AddSalaryForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        otchet_zp otchet;

        public AddSalaryForm(otchet_zp zp)
        {
            otchet = zp;
            InitializeComponent();
            textBox1.Text = otchet.id_doctor.ToString();
            textBox3.Text = otchet.data_ozp.ToString();
            textBox4.Text = otchet.hours.ToString();
            textBox5.Text = otchet.zp.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = ((BuhgalterForm)Owner).db.otchet_zp.SingleOrDefault(w => w.id_ozp == otchet.id_ozp);
                result.id_doctor = Int32.Parse(textBox1.Text.ToString());
                result.data_ozp = DateTime.Parse(textBox3.Text.ToString());
                result.hours = Int32.Parse(textBox4.Text.ToString());
                result.hours = Int32.Parse(textBox5.Text.ToString());
                result.description = textBox6.Text.ToString();

                ((BuhgalterForm)Owner).zp = ((BuhgalterForm)Owner).db.otchet_zp.OrderBy(o => o.id_ozp).ToList();
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
