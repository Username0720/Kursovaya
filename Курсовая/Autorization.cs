using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Курсовая
{
    class Autorization
    {
        public string login { get; set; }
        public string pas { get; set; }

        public static hospitalEntities db = new hospitalEntities();
        Form1 f1 = new Form1();

        public Autorization(string login, string pas)
        {
            this.login = login;
            this.pas = pas;
        }

        public Autorization(string str)
        {
            string[] array = str.Split(' ');
            this.login = array[0].Trim();
            this.pas = array[1].Trim();
        }
        public void CheckUser()
        {
            bool check = false;

            if (login == "admin" && pas == "admin")
            {
                check = true;
                Form6 f6 = new Form6();
                f6.Show();
            }

            else if (login == "buhgalter" && pas == "buhgalter")
            {
                check = true;
                Form5 f5 = new Form5();
                f5.Show();
            }

            else
            {

                StreamReader p = new StreamReader(@"pacients.txt");
                string str;
                while ((str = p.ReadLine()) != null)
                {

                    Autorization user = new Autorization(str);
                    if ((user.login == this.login) && (user.pas == this.pas))
                    {
                        check = true;
                        Form3 f3 = new Form3();
                        f3.Show();
                        break;
                    }
                }
                p.Close();

                StreamReader d = new StreamReader(@"doctors.txt");
                string str1;
                while ((str1 = d.ReadLine()) != null)
                {

                    Autorization user = new Autorization(str1);
                    if ((user.login == this.login) && (user.pas == this.pas))
                    {
                        check = true;
                        Form3 f3 = new Form3();
                        f3.Show();
                        break;
                    }
                }
                d.Close();
            }//else

            if (!check) MessageBox.Show("Неверный логин и/или пароль");

        }//CheckUser

        public bool CheckFill()
        {
            var pacients = (from p in db.pacient
                            where p.login == login
                            select new { p.name, p.surname, p.number, p.polis, p.passport, p.addres, p.status }).ToString();
            var doctors = (from d in db.doctor
                           where d.login == login
                           select new { d.name, d.surname, d.number, d.hours }).ToString();
            if (pacients != null)
                return true;
            else return false;
        }

        public string FillingForm()
        {
            string name, surname, number, polis, passport, addres, status, hours;

            var pacients = (from p in db.pacient
                            where p.login == login
                            select new { p.name, p.surname, p.number, p.polis, p.passport, p.addres, p.status}).ToList();
            var doctors = (from d in db.doctor
                            where d.login == login
                            select new { d.name, d.surname, d.number, d.hours }).ToList();

            string[] array = pacients.Split(',');

            if (pacients == null)
            {
                array = doctors.Split(',');
                name = array[0];
                surname = array[1];
                number = array[2];
                hours = array[3];
                return name + surname + number + hours;
            }
            else
            {
                name = array[0];
                surname = array[1];
                number = array[2];
                polis = array[3];
                passport = array[4];
                addres = array[5];
                status = array[6];
                return name + surname + number + polis + passport + addres + status;
            }
        }

    }
}
