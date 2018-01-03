using System;

namespace ner_number_generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int num = 0;
            string numS = "0";
            start:
            try
            {   
                if (args == null || args.Length == 0)
                {
                    Console.WriteLine("Please enter the amount of LEDs you wish to control (max. 52)");
                    numS = Console.ReadLine();
                }
                else
                {
                    numS = args[1].ToString();
                }
                num = Convert.ToInt16(numS);
                if (num < 1)
                {
                    throw new NumberIsTooSmall();
                }
                else if (num > 52)
                {
                    throw new NumberIsTooBig();
                }
            }
            catch(NumberIsTooSmall)
            {
                Console.WriteLine("Please enter a number between 1 and 52");
                goto start;
            }
            catch(NumberIsTooBig)
            {
                Console.WriteLine("Please enter a number between 1 and 52");
                goto start;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a number between 1 and 52");
                goto start;
            }
            Console.WriteLine("Please Save the following output:");
            Console.WriteLine();
            print(num);
        }

        public static void print(int num)
        {
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
        }
    }

    public class NumberIsTooBig : Exception
    {
        public NumberIsTooBig()
        {
        }
    }
    
    public class NumberIsTooSmall : Exception
    {
        public NumberIsTooSmall()
        {
        }
    }
}
