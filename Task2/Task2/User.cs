using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class User
    {
        public string surname;
        public string name;
        public string middlename;
        public DateTime date;
        public int age;

        public User(string s, string n, string m, DateTime d)
        {
            surname=s;
            name = n;
            middlename = m;
            date = d;
            age = Age;
        }

        public int Age
        {
            get 
            {
                DateTime now = DateTime.Today;
                int age = now.Year - date.Year;
                if (date > now.AddYears(-age))  age--;
                return age;
            }
            set
            {
                DateTime now = DateTime.Today;
                int age = now.Year - date.Year;
                if (date > now.AddYears(-age))  age--;
            }
        }
        public virtual string Show()
        {
            return "ФИО:" +surname +" "+ name +" "+ middlename + "\n"+"Дата рождения:"+date+"\n"+"Возраст:"+age+"\n";
        }
    }
}
