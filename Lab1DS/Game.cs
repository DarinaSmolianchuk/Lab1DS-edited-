using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1DS
{
    class Game
    {
        //Кількість всіх ігр
        private static int gamesCount = 0;
        //Змінні гри
        public int ID { get; }
        public GameAccount FirstPlayer { get; }
        public GameAccount SecondPlayer { get; }
        public int Rating { get; }
        public bool IsWinFisrt { get; }

        //Конструктор
        public Game(GameAccount firstPlayer, GameAccount secondPlayer, int rating, bool isWinFisrt)
        {
            ID = gamesCount++;
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            Rating = rating;
            IsWinFisrt = isWinFisrt;
        }
    }
}