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
            if (num => 52 || num < 0)
            {
                Console.WriteLine("Please enter the a number between 1 and 52");
                goto start;
            }
            Console.WriteLine("Please Save the following output:");
            Console.WriteLine();
            Console.WriteLine("#define amount " + num + " // The amount of LEDs, necessary to turn them on.");
            Console.WriteLine(" ");
            Console.Write("/* All our LEDs (in the addressable mode) */ int leds[amount] = { 53 /* This is LED number 1 but because we use serial, we need to have it at another pin, and 53 works */");
            for (int i = 2; i <= num; i++)
            {
                Console.Write(", " + i);
            }
            Console.WriteLine(" };");
            Console.WriteLine(" ");
            Console.Write("/* All our LEDs (the way we type them) */ String nums[amount] = { \"1\"");
            for (int i = 2; i <= num; i++)
            {
                Console.Write(", \"" + i + "\"");
            }
            Console.Write(" };");
            Console.Read();

        }
    }
}
