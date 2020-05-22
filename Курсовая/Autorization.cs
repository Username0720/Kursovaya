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
        LoginForm f1 = new LoginForm();

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
                AdminForm f6 = new AdminForm();
                f6.Show();
            }

            else if (login == "buhgalter" && pas == "buhgalter")
            {
                check = true;
                BuhgalterForm f5 = new BuhgalterForm();
                f5.Show();
            }

            else
            {
                List<pacient> query = (from p in db.pacient
                                       select p).ToList();
                StreamReader pac = new StreamReader(@"pacients.txt");
                string str;
                int i;
                while ((str = pac.ReadLine()) != null)
                {

                    Autorization user = new Autorization(str);
                    if ((user.login == this.login) && (user.pas == this.pas))
                    {
                        check = true;
                        pacient item = query.First(w => w.login.ToString() == login);
                        PacientsForm f3 = new PacientsForm(item);
                        f3.Show();
                        break;
                    }
                }
                pac.Close();


                List<doctor> query1 = (from d in db.doctor
                                       select d).ToList();
                StreamReader doc = new StreamReader(@"doctors.txt");
                string str1;
                int ii;
                while ((str1 = doc.ReadLine()) != null)
                {
                    Autorization user = new Autorization(str1);
                    if ((user.login == this.login) && (user.pas == this.pas))
                    {
                        check = true;
                        doctor item = query1.First(w => w.login.ToString() == login);
                        DoctorsForm f8 = new DoctorsForm(item);
                        f8.Show();
                        break;
                    }
                }
                doc.Close();
            }//else

            if (!check) MessageBox.Show("Неверный логин и/или пароль");

        }//CheckUser

    }
}
