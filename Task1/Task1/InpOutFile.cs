using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Task1
{
    public class InpOutFile
    {
        public Triangle[] Input(string path)
        {
            Triangle[] ar = null;
            Triangle tr = new Triangle();
            using (StreamReader fileIn = new StreamReader(path))
            {
                int n;
                if (int.TryParse(fileIn.ReadLine(), out n))
                {
                    ar = new Triangle[n];

                    for (int i = 0; i < n; i++)
                    {
                        string[] text = fileIn.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        double x;
                        double y;
                        Point A = null;
                        Point B = null;
                        Point C = null;

                        if (double.TryParse(text[0], out x) && double.TryParse(text[1], out y))
                        {
                            A = new Point(x, y);
                        }
                        else 
                        { 
                            throw new ArgumentException("Wrong parametr.");
                        }

                        if (double.TryParse(text[2], out x) && double.TryParse(text[3], out y))
                        {
                            B = new Point(x, y); 
                        }
                        else
                        { 
                            throw new ArgumentException("Wrong parametr.");
                        }


                        if (double.TryParse(text[4], out x) && double.TryParse(text[5], out y))
                        { 
                            C = new Point(x, y);
                        }
                        else 
                        { 
                            throw new ArgumentException("Wrong parametr."); 
                        }

                        if ((tr.Path(A, B) + tr.Path(B, C) > tr.Path(C, A))
                            && (tr.Path(A, B) + tr.Path(C, A) > tr.Path(B, C))
                            && (tr.Path(B, C) + tr.Path(C, A) > tr.Path(A, B)))

                        {
                            ar[i] = new Triangle(A, B, C); 
                        }

                        else
                        {
                            throw new ArgumentException("Triangle doesn't exist.");
                        }
                    }
                }
                return ar;
            }
        }
        public void Output(Triangle[] ar)
        {
            using (StreamWriter fileOut = new StreamWriter("output.txt"))
            {
                foreach (Triangle item in ar)
                {
                    fileOut.WriteLine("Координаты точки a = ({0},{1})", item.a.x, item.a.y);
                    fileOut.WriteLine("Координаты точки b = ({0},{1})", item.b.x, item.b.y);
                    fileOut.WriteLine("Координаты точки c = ({0},{1})", item.c.x, item.c.y);
                    fileOut.WriteLine(item.P);
                    fileOut.WriteLine(item.S);
                    fileOut.WriteLine();
                }
            }
        }
    }
}
