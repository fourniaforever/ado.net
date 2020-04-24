using System;
using System.Text;
using System.Collections.Generic;
namespace ThreeLayers.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private DateTime dateOfBirth;
        public List <Award> Awards { get; private set; }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value < DateTime.Now)
                    dateOfBirth = value;
                else
                    throw new ArgumentOutOfRangeException("Date of birth don't be more than the current date");
            }
        }
        public double Age { get => (int)DateTime.Now.Subtract(DateOfBirth).TotalDays / 365; }

        public User(string name, DateTime dateOfBirth)
        {
            Name = name;
            this.dateOfBirth = dateOfBirth;
            Awards = new List<Award>();
        }

        public User()
        {
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder($"Id: {Id}" + Environment.NewLine +
                $"Name: {Name}" + Environment.NewLine +
                $"DateOfBirth: {DateOfBirth}" + Environment.NewLine +
                $"Age: {Age}" + Environment.NewLine);
            foreach (Award item in Awards)
            {
                info.Append(item.ToString());
            }
            return info.ToString();
        }
    }
}