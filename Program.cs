using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace DiceRolling
{
    class Program
    {
        static void Main(string[] args)
        {

            int sides = 0;
            bool possible = false;
            int roll1 = 0;
            int roll2 = 0;
            bool proceed = true;

            Console.WriteLine("Welcome to the Grand Circus Casino!");

            do
            {
                while (!possible)
                {
                    sides = GetValidInteger("How many sides should each die have? ");
                    //Console.WriteLine(sides);
                    possible = PossibleDieCheck(sides);
                    //Console.WriteLine(possible);
                }

                roll1 = RollDie(sides);
                roll2 = RollDie(sides);
                Console.WriteLine($"You rolled a {roll1} and a {roll2}.");
                //DisplayDice();
                if (sides == 6)
                {
                    CheckResult(roll1, roll2);
                }
                proceed = PlayAgain();
                Console.WriteLine();
            } while (proceed);
            


        }
        
        static int GetValidInteger(string question)
        {
            string input = "";
            bool isValid = false;
            int sides = 0;
            

            while (!isValid)
            {
                Console.Write(question);
                input = Console.ReadLine();
                isValid = int.TryParse(input, out sides);
                if (!isValid)
                {
                    Console.Write("That was not an integer, Please try again: ");
                }
            }
            return sides;
        }

        static bool PossibleDieCheck(int sides)
        {
            bool exist = false;
            if (sides < 2)
            {
                Console.WriteLine("Your die cannot exist without changing the laws of physics please try again ");
                exist = false;
            }
            else if (sides == 2)
            {
                Console.WriteLine("Looks like we are flipping a coin");
                exist = true;
            }
            else if (sides == 20)
            {
                Console.WriteLine("A True Gamer!!!");
                exist = true;
            }
            else
            {
                exist = true;
            }

            return exist;
        }

        static int RollDie(int upperbounds)
        {
            int result = 0;
            upperbounds = upperbounds + 1;
            Random rand = new Random();
            result = rand.Next(1, upperbounds);

            return result;
        }

        static void CheckResult(int num1, int num2)
        {
            int total = num1 + num2;
            if (num1 == 1 && num2 == 1)
            {
                Console.WriteLine("Snake Eyes: Two 1s");
            }
            else if (num1 == 1 && num2 == 2)
            {
                Console.WriteLine("Ace Deuce: A 1 and a 2");
            }
            else if (num1 == 2 && num2 == 1)
            {
                Console.WriteLine("Ace Deuce: A 1 and a 2");
            }
            else if (num1 == 6 && num2 == 6)
            {
                Console.WriteLine("Boxcars: Two 6s");
            }

            if (total == 7 || total == 11)
            {
                Console.WriteLine("Win!");
            }
            if (total ==2 || total == 3 || total == 12)
            {
                Console.WriteLine("Craps!");
            }
        }

        static bool PlayAgain()
        {
            bool proceed = false;
            bool isValid;

            do
            {
                Console.Write("Roll again? (y/n): ");
                string input = Console.ReadLine();
                input = input.ToUpper();
                if (input == "Y" || input == "YES")
                {
                    proceed = true;
                    isValid = true;
                }
                else if (input == "N" || input == "NO")
                {
                    Console.WriteLine("Goodbye!");
                    proceed = false;
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    Console.Write("That was not a valid input. ");
                }
            } while (!isValid);

            return proceed;
        }

    }
}
