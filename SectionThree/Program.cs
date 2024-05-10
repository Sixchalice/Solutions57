using System;
using System.Text;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hellorld!");

            NumericalExpression NumEx = new NumericalExpression(53211857887609);
            Console.WriteLine(NumEx);

            


            //LinkedList list = new LinkedList(2);
            //list.Prepend(10);
            //list.Append(2222);
            //list.Prepend(15);
            //list.Append(3333);
            //list.Append(332);

            //foreach (int i in list.ToList())
            //{
            //    Console.WriteLine(i.ToString());
            //}

            //Console.WriteLine("--------------------");


            //Node max = list.GetMaxNode();
            //Console.WriteLine("Max node: " + max.GetValue());

            //Node min = list.GetMinNode();
            //Console.WriteLine("Min node: " + min.GetValue());

            //Console.WriteLine("SORTING: ");
            //list.Sort();
            //foreach (int i in list.ToList())
            //{
            //    Console.Write(i + ", ");
            //}
            //Console.WriteLine();
            //max = list.GetMaxNode();
            //Console.WriteLine("Max node: " + max.GetValue());

            //min = list.GetMinNode();
            //Console.WriteLine("Min node: " + min.GetValue());
        }
    }
}