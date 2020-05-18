using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    class Class1
    {
        public static hospitalEntities db = new hospitalEntities();
        public static List<pacient> pacients;

        public static string Autorization(string login, string pas)
        {
            int count = 0;
            pacients = (from p in db.pacient select p).ToList();
            foreach(var p in pacients)
            {
                if ( p.login == login && p.pas == pas)
                {
                    return "1";
                }
                else return "2";
            }
            return "0";
        }
    }
}
