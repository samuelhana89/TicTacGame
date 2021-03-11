using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IBoardGame
    {
        void initGame(string[,] board); //initizlation to start the game with emtpy board
        void printboard(string[,] board); // to print the game 

    }
}

