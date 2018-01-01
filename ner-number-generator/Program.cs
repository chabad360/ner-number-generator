using System;

namespace ner_number_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            Console.WriteLine("Please enter the amount of LEDs you wish to control (max. 52)");
            string numS = Console.ReadLine();
            int num = Convert.ToInt16(numS);
            if (num > 52 || num <= 0)
            {
                Console.WriteLine("Please enter the a number between 1 and 52");
                goto start;
            }
            Console.WriteLine("Please Save the following output:");
            Console.WriteLine();
            Console.WriteLine("#define amount " + num);
            Console.WriteLine(" ");
            Console.Write("int leds[" + num + "] = { 53");
            for (int i = 2; i <= num; i++)
            {
                Console.Write(", " + i);
            }
            Console.WriteLine(" };");
            Console.WriteLine(" ");
            Console.Write("String nums[" + num + "] = { \"1\"");
            for (int i = 2; i <= num; i++)
            {
                Console.Write(", \"" + i + "\"");
            }
            Console.Write(" };");
            Console.Read();

        }
    }
}
