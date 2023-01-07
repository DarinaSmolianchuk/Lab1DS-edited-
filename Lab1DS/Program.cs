using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1DS
{
    class Program
    {
        static void Main(string[] args)
        {
            GameAccount player1 = new GameAccount("Player1");
            GameAccount player2 = new GameAccount("Player2");

            
            player1.winGame(player2, 25);
            player1.loseGame(player2, 29);
            player1.loseGame(player2, -26);
            player2.loseGame(player1, 22);
            player2.winGame(player1, 21);
            player2.winGame(player1, 27);

            player1.getStats();
            player2.getStats();
            
        }
    }
}
