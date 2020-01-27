using System;

namespace DiceRoller
{
    class Die
    {
        Random rand = new Random();
        private int _sides;
        public int Roll;

        public Die(int sides)
        {
            Roll = rand.Next(1, sides + 1);
            _sides = sides;
        }

        public int NumSides()
        {
            return _sides;
        }
    }
}