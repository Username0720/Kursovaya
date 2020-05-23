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
    public partial class ReportsForm : Form
    {
        public hospitalEntities db = new hospitalEntities();

        public ReportsForm()
        {
            InitializeComponent();
            FillForm show = new FillForm();
            show.FillReports(dataGridView1);
        }
    }
}
