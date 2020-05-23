using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    class FillForm
    {
        public hospitalEntities db = new hospitalEntities();

        public FillForm()
        {

        }

        public void FillReports(DataGridView d)
        {
            List<otchet_zp> reports = (from r in db.otchet_zp
                       select r).ToList();

            var query = (from r in reports
                         orderby r.id_ozp
                         select new { r.id_doctor, r.hours, r.data_ozp, r.zp, r.description }).ToList();

            d.DataSource = reports;
            d.ReadOnly = true;
            d.Columns[0].HeaderText = "Идентификатор отчета";
            d.Columns[1].HeaderText = "Идентификатор доктора";
            d.Columns[3].HeaderText = "кол-во отработанных часов доктора";
            d.Columns[2].HeaderText = "дата создания отчета";
            d.Columns[4].HeaderText = "Зарплата";
            d.Columns[5].HeaderText = "Описание";
        }

        public void FillPacients(DataGridView d) 
        {
            List<pacient> pacients = (from p in db.pacient
                        select p).ToList();

            var query1 = (from p in pacients
                          orderby p.id_pacient
                          select new { p.surname, p.name, p.number, p.polis, p.passport, p.addres, p.status }).ToList();

            d.DataSource = query1;
            d.ReadOnly = true;

            d.Columns[0].HeaderText = "Фамилия";
            d.Columns[1].HeaderText = "Имя";
            d.Columns[2].HeaderText = "Номер телефона";
            d.Columns[3].HeaderText = "Полис";
            d.Columns[4].HeaderText = "Серия номер пасспорта";
            d.Columns[5].HeaderText = "Адрес проживания";
            d.Columns[6].HeaderText = "Лечение";
        }

        public void FillDoctors(DataGridView d)
        {
            List<doctor> doctors = (from doc in db.doctor
                                    select doc).ToList();

            var query = (from doc in doctors
                         orderby doc.id_doctor
                         select new { doc.surname, doc.name, doc.number, doc.hours }).ToList();

            d.DataSource = query;
            d.ReadOnly = true;

            d.Columns[0].HeaderText = "Фамилия";
            d.Columns[1].HeaderText = "Имя";
            d.Columns[2].HeaderText = "Номер телефона";
            d.Columns[3].HeaderText = "Отработанные часы";
        }
    }
}
