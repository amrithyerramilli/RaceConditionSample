using System;
using System.Threading;
// using System.Threading.Tasks;

namespace RaceConditionSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The Problem : ");
            Console.WriteLine("----------");
            Problem.Describe();

            Console.WriteLine("\n\n");            
            Console.WriteLine("The Solution : ");
            Console.WriteLine("----------");
            Solution.Show();
        }
    }
}
