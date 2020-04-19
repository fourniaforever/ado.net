using System;
using System.IO;
namespace Task1
{

    public class Program
    {
        static void Main()
        {
            InpOutFile FL = new InpOutFile();
            Triangle[] ar = FL.Input("input.txt");
            FL.Output(ar);
            foreach (Triangle item in ar)
            { 
                Console.WriteLine(item.Show());
            }
           
        }
    }
}