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
                Console.WriteLine("ex. 3d6+3 will roll a six sided die three times then add three to the total");
                Console.Write(" ");
                string input = Console.ReadLine();
                if (input.ToLower() == "q" || input.ToLower() == "quit")
                {
                    Console.Clear();
                    Console.WriteLine("Program End");
                    break;
                }
                try
                {
                    int dieSplit = input.ToLower().IndexOf("d");
                    int numDice;
                    int sides;
                    int bonusSplit;
                    int damageBonus;
                    string sidesStr;

                    if (dieSplit == 0)
                    {
                        numDice = 1;
                    }
                    else
                    {
                        string numDiceStr = input.Substring(0, dieSplit);
                        numDice = Int32.Parse(numDiceStr);
                    }

                    if(input.IndexOf("+") == -1 && input.IndexOf("-") == -1)
                    {
                        sidesStr = input.Substring(dieSplit + 1, input.Length - dieSplit -1);
                        damageBonus = 0;
                    }
                    else if (input.IndexOf("+") != -1 )
                    {
                        bonusSplit = input.ToLower().IndexOf("+");
                        sidesStr = input.Substring(dieSplit + 1,bonusSplit - dieSplit -1);
                        string damageBonusStr = input.Substring(bonusSplit + 1, input.Length - bonusSplit -1);
                        damageBonus = Int32.Parse(damageBonusStr);
                    }
                    else
                    {
                        bonusSplit = input.ToLower().IndexOf("-");
                        sidesStr = input.Substring(dieSplit + 1,bonusSplit - dieSplit -1);
                        string damageBonusStr = input.Substring(bonusSplit + 1, input.Length - bonusSplit -1);
                        damageBonus = -(Int32.Parse(damageBonusStr));

                    }
                    sides = Int32.Parse(sidesStr);
                    Console.WriteLine("");
                    RollDice(numDice, sides, damageBonus);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Invalid entry, please try again.");
                    //Console.WriteLine(ex);
                }
                Console.ReadKey();
            }
        }

        public static void RollDice(int numDice, int sides, int damageBonus)
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
            total += damageBonus;

            string numDiceText;
            if (numDice == 1)
            {
                numDiceText = "";
            }
            else
            {
                numDiceText = $"{numDice}";
            }

            string damageBonusText = "";
            if (damageBonus < 0)
            {
                damageBonusText = $"{damageBonus}";
            }
            if (damageBonus > 0)
            {
                damageBonusText = $"+{damageBonus}";
            }

            Console.WriteLine($"     Rolling {numDiceText}d{sides}{damageBonusText}, your total was {total}{rollText}");
        }
    }
}
