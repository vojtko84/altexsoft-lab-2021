using System;

namespace Homework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var homework = new HomeWork();
            var result = homework.InvokePriceCalculatiion();

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}