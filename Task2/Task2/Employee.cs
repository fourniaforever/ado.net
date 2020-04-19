using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Employee : User
    {
        public Employee(string s, string n, string m, DateTime d,  string p,int w) : base(s, n, m, d)
        {
            Position = p;
            Work_experience = w;
        }

        public string Position { get; set; }
        public int Work_experience { get; set; }

        public override string Show()
        {
            return base.Show() + "Должность:" + Position+"\n" + "Стаж работы:" + Work_experience + "\n";
        }
        //создать метод Age для рассчета возраста И ПРОВЕРКИ ТОЖЕ

    }
}
