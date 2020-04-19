using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            InOutFile FL = new InOutFile();
            User[] ar = FL.InputUser("input.txt");
            FL.OutputUser(ar);

            InOutFile FL1= new InOutFile();
            Circle[] ar1 = FL1.InputCircle("input1.txt");
            FL1.OutputCircle(ar1);
        }
    }
}
