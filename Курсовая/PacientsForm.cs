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
    public partial class PacientsForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        pacient item;
        public PacientsForm(pacient pac)
        {
            item = pac;
            InitializeComponent();
            try
            {
                textBox1.Text = item.surname.ToString() + " " + item.name.ToString();
                textBox2.Text = item.number.ToString();
                textBox3.Text = item.polis.ToString();
                textBox4.Text = item.passport.ToString();
                textBox5.Text = item.addres.ToString();
                textBox6.Text = item.status.ToString();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                LoginForm f1 = new LoginForm();
                f1.Owner = this;
                f1.Show();
            }
            else Application.OpenForms[1].Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                SelectDoctorForm f4 = new SelectDoctorForm();
                f4.Owner = this;
                f4.ShowDialog();
            }
            else Application.OpenForms[1].Focus();
        }
    }
}
