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
        public List<otchet_zp> reports = new List<otchet_zp>();
        public ReportsForm()
        {
            InitializeComponent();

            reports = (from r in db.otchet_zp
                           select r).ToList();

            var query = (from r in reports
                         orderby r.id_ozp
                         select new { r.id_doctor, r.hours, r.data_ozp, r.zp, r.description }).ToList();

            dataGridView1.DataSource = reports;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].HeaderText = "Идентификатор отчета";
            dataGridView1.Columns[1].HeaderText = "Идентификатор доктора";
            dataGridView1.Columns[3].HeaderText = "кол-во отработанных часов доктора";
            dataGridView1.Columns[2].HeaderText = "дата создания отчета";
            dataGridView1.Columns[4].HeaderText = "Зарплата";
            dataGridView1.Columns[5].HeaderText = "Описание";
        }
    }
}
