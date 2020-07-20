using System;
using System.ComponentModel.DataAnnotations;

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

            Console.WriteLine("Welcome to the Grand Circus Casino!");
            while (!possible)
            {
                sides = GetValidInteger("How many sides should each die have? ");
                //Console.WriteLine(sides);
                possible = PossibleDieCheck(sides);
                //Console.WriteLine(possible);
            }
            roll1 = RollDie(sides);
            roll2 = RollDie(sides);
            Console.WriteLine($"You rolled a {roll1} and a {roll2}");
            //DisplayDice();
            //CheckResult();


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

    }
}
