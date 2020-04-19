using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task2
{
    class InOutFile
    {
        public User[] InputUser(string path)
        {
            User[] ar = null;
            using (StreamReader fileIn = new StreamReader(path))
            {
                int n;
                if (int.TryParse(fileIn.ReadLine(), out n))
                {
                    ar = new User[n];

                    for (int i = 0; i < n; i++)
                    {
                        string[] text = fileIn.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        DateTime d;
                        int a;
                        int w;
                        if (text.Length == 4)
                        {
                            if (DateTime.TryParse(text[3], out d))
                            {
                                d = Convert.ToDateTime(text[3]);
                            }
                            else
                            {
                                throw new ArgumentException("Wrong parametr.");
                            }

                          
                            ar[i] = new User(text[0], text[1], text[2], d);
                        }


                        if (text.Length == 6)
                        {

                            if (DateTime.TryParse(text[3], out d))
                            {
                                d = Convert.ToDateTime(text[3]);
                            }
                            else
                            {
                                throw new ArgumentException("Wrong parametr.");
                            }

                           
                            if (int.TryParse(text[5], out w))
                            {
                                w = int.Parse(text[5]);
                            }
                            else
                            {
                                throw new ArgumentException("Wrong parametr.");
                            }
                           
                            
                            DateTime date = d;
                            if (DateTime.Now.Year - date.Year > 18)
                            {
                                 ar[i] = new Employee(text[0], text[1], text[2], d, text[4], w);
                            }
                            else
                            {
                                throw new ArgumentException("Wrong parametr.");
                            }
                        }

                    }
                }
                return ar;

            }
        }
        public void OutputUser(User[] ar)
        {
            using (StreamWriter fileOut = new StreamWriter("output.txt"))
            {
                foreach (User item in ar)
                {
                    fileOut.Write(item.Show());
                    fileOut.WriteLine();
                }
            }
        }
        public Circle[] InputCircle(string path)
        {
            Circle[] ar = null;
            using (StreamReader fileIn = new StreamReader(path))
            {
                int n;
                if (int.TryParse(fileIn.ReadLine(), out n))
                {
                    ar = new Circle[n];

                    for (int i = 0; i < n; i++)
                    {
                        string[] text = fileIn.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        double x;
                        double y;
                        Point centr = null;
                        double r;
                        double inner_r;
                        if (text.Length == 3)
                        {
                            if (double.TryParse(text[0], out x) && double.TryParse(text[1], out y))
                            {
                                centr = new Point(x, y);
                            }
                            else
                            {
                                throw new ArgumentException("Wrong parametr.");
                            }

                            if (double.TryParse(text[2], out r))
                            {
                                r = double.Parse(text[2]);
                            }
                            else
                            {
                                throw new ArgumentException("Wrong parametr.");
                            }
                            ar[i] = new Circle(centr,r);
                        }


                        if (text.Length == 4)
                        {
                            if (double.TryParse(text[0], out x) && double.TryParse(text[1], out y))
                            {
                                centr = new Point(x, y);
                            }
                            else
                            {
                                throw new ArgumentException("Wrong parametr.");
                            }
                            if (double.TryParse(text[2], out r))
                            {
                                r = double.Parse(text[2]);
                            }
                            else
                            {
                                throw new ArgumentException("Wrong parametr.");
                            }

                            if (double.TryParse(text[3], out inner_r))
                            {
                                inner_r = double.Parse(text[3]);
                            }
                            else
                            {
                                throw new ArgumentException("Wrong parametr.");
                            }
                            if (r > inner_r)
                            { 
                                ar[i] = new Ring(centr,r,inner_r);
                            }
                            else
                            {
                                throw new ArgumentException("Wrong parametr.");
                            }
                        }

                    }
                }
                return ar;

            }
        }
        public void OutputCircle(Circle[] ar)
        {
            using (StreamWriter fileOut = new StreamWriter("output1.txt"))
            {
                foreach (Circle item in ar)
                {
                    fileOut.Write(item.Show());
                    fileOut.Write("Площадь = {0}\n",item.S);
                    fileOut.Write("Длина = {0}\n", item.C_summ);
                    fileOut.WriteLine();
                }
            }
        }
    }
}
