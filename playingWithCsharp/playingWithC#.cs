using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            bool closeProgram = true;
            bool loopAgain = true;

            Console.WriteLine("Hello! Please enter your name below.");
            Console.WriteLine("Or enter 'close' to close the program.");

        start:
            while (closeProgram)
            {
                input = Console.ReadLine();
                string upper = input.ToUpper();

                if (upper.Length > 25)
                {
                    Console.WriteLine("That name is too long. Try again.");
                }
                else if (upper == "CLOSE")
                {
                    goto end;
                }
                else
                {
                    Console.WriteLine("Hello " + input + " nice to meet you!");
                    Console.WriteLine("Would you like to enter another name? if Yes enter 'Y', if no enter 'N'.");

                    playAgain:
                    while (loopAgain)
                    {
                        input = Console.ReadLine();
                        string yesNo = input.ToUpper();

                        if (yesNo == "Y")
                        {
                            Console.WriteLine("Please enter another name.");
                            goto start;
                        }
                        else if (yesNo == "N")
                        {
                            goto end;
                        }
                        else if (yesNo != "N" || yesNo != "Y")
                        {
                            Console.WriteLine("test1");
                            goto playAgain;
                        }

                    }
                }
            }
                end:
                Console.WriteLine("Thanks for playing!");
                Console.WriteLine("***Program Closed***");
            
        }
    }

}
