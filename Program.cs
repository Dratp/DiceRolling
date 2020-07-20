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
            int proceed = 1;

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
                int total = roll1 + roll2;
                if (sides == 2)
                {
                    CoinFlip(roll1, roll2);
                }
                else if (sides == 6)
                {
                    DisplayDice(roll1, roll2);
                    Console.WriteLine($"You rolled a {roll1} and a {roll2} ({total} total)");
                    CheckResult(roll1, roll2);
                }
                else
                {
                    Console.WriteLine($"You rolled a {roll1} and a {roll2} ({total} total)");
                }
                proceed = PlayAgain();
                Console.WriteLine();
                if (proceed == 2)
                {
                    possible = false;
                }
            } while (proceed!=0);
            


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

        static int PlayAgain()
        {
            //Returns 0 if not playing again, Returns 1 if playing again, returns 2 if needing to change dice
            int proceed=3;  
            bool isValid;

            do
            {
                Console.Write("Roll again or change die? (y/n/change): ");
                string input = Console.ReadLine();
                input = input.ToUpper();
                if (input == "Y" || input == "YES")
                {
                    proceed = 1;
                    isValid = true;
                }
                else if (input == "N" || input == "NO")
                {
                    Console.WriteLine("Goodbye!");
                    proceed = 0;
                    isValid = true;
                }
                else if(input == "CHANGE")
                {
                    proceed = 2;
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

        static void DisplayDice(int die1, int die2)
        {
            Console.WriteLine(" ___   ___");
            // Top dots
            if (die1 == 6 || die1 == 5 || die1 == 4)
            {
                if (die2 == 6 || die2 == 5 || die2 == 4)
                {
                    Console.WriteLine($"{TwoDot()} {TwoDot()}");
                }
                else if (die2 == 1)
                {
                    Console.WriteLine($"{TwoDot()} {NoDot()}");
                }
                else
                {
                    Console.WriteLine($"{TwoDot()} {RightDot()}");
                }
            }
            else if (die1 == 1)
            {
                if (die2 == 6 || die2 == 5 || die2 == 4)
                {
                    Console.WriteLine($"{NoDot()} {TwoDot()}");
                }
                else if (die2 == 1)
                {
                    Console.WriteLine($"{NoDot()} {NoDot()}");
                }
                else
                {
                    Console.WriteLine($"{NoDot()} {RightDot()}");
                }
            }
            else
            {
                if (die2 == 6 || die2 == 5 || die2 == 4)
                {
                    Console.WriteLine($"{RightDot()} {TwoDot()}");
                }
                else if(die2 == 1)
                {
                    Console.WriteLine($"{RightDot()} {NoDot()}");
                }
                else
                {
                    Console.WriteLine($"{RightDot()} {RightDot()}");
                }
            }
            //Middle Dots
            if (die1 == 5 || die1 == 3 || die1 == 1)
            {
                if (die2 == 5 || die2 == 3 || die2 == 1)
                {
                    Console.WriteLine($"{MidDot()} {MidDot()}");
                }
                else if (die2 == 6)
                {
                    Console.WriteLine($"{MidDot()} {TwoDot()}");
                }
                else
                {
                    Console.WriteLine($"{MidDot()} {NoDot()}");
                }
            }
            else if (die1 == 6)
            {
                if (die2 == 5 || die2 == 3 || die2 == 1)
                {
                    Console.WriteLine($"{TwoDot()} {MidDot()}");
                }
                else if (die2 == 6)
                {
                    Console.WriteLine($"{TwoDot()} {TwoDot()}");
                }
                else
                {
                    Console.WriteLine($"{TwoDot()} {NoDot()}");
                }
            }
            else
            {
                if (die2 == 5 || die2 == 3 || die2 == 1)
                {
                    Console.WriteLine($"{NoDot()} {MidDot()}");
                }
                else if (die2 == 6)
                {
                    Console.WriteLine($"{NoDot()} {TwoDot()}");
                }
                else
                {
                    Console.WriteLine($"{NoDot()} {NoDot()}");
                }
            }
            // Lower Dots
            if (die1 == 6 || die1 == 5 || die1 == 4)
            {
                if (die2 == 6 || die2 == 5 || die2 == 4)
                {
                    Console.WriteLine($"{TwoDot()} {TwoDot()}");
                }
                else if (die2 == 1)
                {
                    Console.WriteLine($"{TwoDot()} {NoDot()}");
                }
                else
                {
                    Console.WriteLine($"{TwoDot()} {LeftDot()}");
                }
            }
            else if (die1 == 1)
            {
                if (die2 == 6 || die2 == 5 || die2 == 4)
                {
                    Console.WriteLine($"{NoDot()} {TwoDot()}");
                }
                else if (die2 == 1)
                {
                    Console.WriteLine($"{NoDot()} {NoDot()}");
                }
                else
                {
                    Console.WriteLine($"{NoDot()} {LeftDot()}");
                }
            }
            else
            {
                if (die2 == 6 || die2 == 5 || die2 == 4)
                {
                    Console.WriteLine($"{LeftDot()} {TwoDot()}");
                }
                else if (die2 == 1)
                {
                    Console.WriteLine($"{LeftDot()} {NoDot()}");
                }
                else
                {
                    Console.WriteLine($"{LeftDot()} {LeftDot()}");
                }
            }
            Console.WriteLine(" ˉˉˉ   ˉˉˉ");
        }

        static string TwoDot()
        {
            string dotdot = "|o o|";
            return dotdot;
        }
        static string RightDot()
        {
            string dotdot = "|  o|";
            return dotdot;
        }
        static string MidDot()
        {
            string dotdot = "| o |";
            return dotdot;
        }
        static string LeftDot()
        {
            string dotdot = "|o  |";
            return dotdot;
        }
        static string NoDot()
        {
            string dotdot = "|   |";
            return dotdot;
        }

        static void CoinFlip(int coin1, int coin2)
        {
            if (coin1 == 1)
            {
                Console.Write("Heads and ");
            }
            else
            {
                Console.Write("Tails and ");
            }
            if (coin2 == 1)
            {
                Console.WriteLine("Heads");
            }
            else
            {
                Console.WriteLine("Tails");
            }
               

        }

    }
}
