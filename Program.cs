using System;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What would you like to roll? (q to quit)");
                Console.WriteLine("ex. 3d6 will roll a six sided die three times");
                string input = Console.ReadLine();
                if (input.ToLower() == "q" || input.ToLower() == "quit")
                {
                    break;
                }
                try
                {
                    int split = input.ToLower().IndexOf("d");
                    string numDiceStr = input.Substring(0, split);
                    int numDice = Int32.Parse(numDiceStr);
                    string sidesStr = input.Substring(split + 1, input.Length - split -1);
                    int sides = Int32.Parse(sidesStr);
                    Console.WriteLine("");
                    RollDice(numDice, sides);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Invalid entry, please try again.");
                }
                Console.ReadKey();
            }
        }

        public static void RollDice(int numDice, int sides)
        {
            Die[] Dice = new Die[numDice];

            for (int i = 0; i < Dice.Length; i++)
            {
                Dice[i] = new Die(sides);
            }

            int total = 0;
            string rollText = " [ ";
            foreach (Die die in Dice)
            {
                rollText += $"{die.Roll} ";
                total += die.Roll;
            }

            rollText += "]";
            Console.WriteLine($"Rolling {numDice}d{sides}, your total was {total}{rollText}");
        }
    }
}
