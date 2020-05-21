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

        //public static hospitalEntities db = new hospitalEntities();
        //public static List<pacient> pacients;
        //public static List<doctor> doctors;

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
            if(login == "admin" && pas == "admin")
            {
                Form6 f6 = new Form6();
                f6.Show();
            }

            else if (login == "buhgalter" && pas == "buhgalter")
            {
                Form5 f5 = new Form5();
                f5.Show();
            }

            else
            {
                bool check = false;

                StreamReader p = new StreamReader(@"pacients.txt");
                string str;
                while ((str = p.ReadLine()) != null)
                {

                    Autorization user = new Autorization(str);
                    if ((user.login == this.login) && (user.pas == this.pas))
                    {
                        check = true;
                        Form2 f3 = new Form2();
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
                        Form2 f3 = new Form2();
                        f3.Show();
                        break;
                    }
                }
                d.Close();

                if (!check) MessageBox.Show("Неверный логин и/или пароль");
            }
        }
    }
}
