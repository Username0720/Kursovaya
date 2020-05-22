using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Курсовая
{
    public partial class LoginForm : Form
    {
        hospitalEntities db = new hospitalEntities();
        public List<pacient> pacientsheet;
        public List<doctor> doctorsheet;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string pas = textBox2.Text;
            Autorization user = new Autorization(login, pas);
            user.CheckUser();
            textBox1.ResetText();
            textBox2.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
