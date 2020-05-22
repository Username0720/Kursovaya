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
    public partial class EditPacientForm : Form
    {
        public hospitalEntities db = new hospitalEntities();
        pacient item;

        public EditPacientForm(pacient pac)
        {
            item = pac;
            InitializeComponent();

            textBox1.Text = item.surname.ToString();
            textBox2.Text = item.name.ToString();
            textBox3.Text = item.number.ToString();
            textBox4.Text = item.polis.ToString();
            textBox5.Text = item.passport.ToString();
            textBox6.Text = item.addres.ToString();
            textBox7.Text = item.login.ToString();
            textBox8.Text = item.pas.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = ((AdminForm)Owner).db.pacient.SingleOrDefault(w => w.id_pacient == item.id_pacient);
            result.surname =  textBox1.Text.ToString();
            result.name =     textBox2.Text.ToString();
            result.number =   textBox3.Text.ToString();
            result.polis =    textBox4.Text.ToString();
            result.passport = textBox5.Text.ToString();
            result.addres =   textBox6.Text.ToString();
            result.login =    textBox7.Text.ToString();
            result.pas =      textBox8.Text.ToString();

            ((AdminForm)Owner).pacients = ((AdminForm)Owner).db.pacient.OrderBy(o => o.id_pacient).ToList();

            this.Close();
        }
    }
}
