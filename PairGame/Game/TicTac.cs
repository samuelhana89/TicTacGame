using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class TicTac : IBoardGame
    { 
        static void Main(string[] args)
        {
            string[,] board =new string[3, 3]; // 2 dimensional array holds 3 row(i) , 3 column (j)
            string currentPlayer = "X";

            TicTac game = new TicTac();
            game.initGame(board);
            do
            {
                Console.WriteLine("The Current player is : " + currentPlayer);
                Console.WriteLine("Please , choose empty cell from 1:9");
                game.printboard(board);

                int currentposition = Convert.ToInt32(Console.ReadLine());
                bool valid = game.updateGame(currentposition, board, currentPlayer);

                if (!valid)
                {
                    Console.WriteLine("the number you enter is not valid, please try again");
                }
                else
                {

                    if (game.HasWon(board, currentPlayer))
                    {
                        Console.WriteLine("Congrat! player " + currentPlayer + " has won!!!!!");
                        break;
                    }
                    else
                    {
                        if (game.isBoardFull(board))
                        {
                            Console.WriteLine("Its Tie");
                            break;
                        }
                    }
                    currentPlayer = currentPlayer.Equals("X") ? "O" : "X";
                }
            } while (true);

            Console.ReadLine();







        }

        public bool updateGame(int currentposition , string [,] board, String currentPlayer)
        {
            if (currentposition > 0 && currentposition < 10)
            {
                int i = getI(currentposition, board.GetLength(0));
                int j = getj(currentposition, i, board.GetLength(0));
                
                if (board[i, j].Equals(currentposition+""))
                {
                    
                    board[i, j] = currentPlayer;
                    return true;
                }
            }

            return false;      
        }

        public int getI (int currentposition, int sizeOfI)
        {
            return (currentposition - 1) / sizeOfI;
        }

        public int getj(int currentposition, int i, int sizeOfI)
        {
            return currentposition - ((i * sizeOfI) + 1);
        }

        public void initGame(string[,] board)
        {
            int count = 1; // init the board with cell #
            for (int i = 0; i < board.GetLength(0); i++) 
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = count+"" ;
                    count++;
                }
            }
        }

        public void printboard(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                    if (j < board.GetLength(1) - 1)
                    {
                      Console.Write(" | ");

                    }

                }
                Console.WriteLine();

                if (i < board.GetLength(0) - 1)
                {
                    Console.WriteLine("----------");

                }


            }
            Console.WriteLine("");
        }
        public bool HasWon(string[,] board , string currentPlayer )
        {
            // column check 
            bool hasWon = true;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                hasWon = true;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (!board[i , j].Equals(currentPlayer))
                    {
                        hasWon = false;
                        break;

                    }
                }
                if (hasWon) return true;
            }

            
            // row check 
            for (int i = 0; i < board.GetLength(0); i++)
            {
                hasWon = true;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (!board[j, i].Equals(currentPlayer))
                    {
                        hasWon = false;
                        break;

                    }
                }
                if (hasWon) return true;
            }

            // diagonal 1 check
            for (int i = 0; i < board.GetLength(0); i++)
            {
                hasWon = true;
                if (!board[i, i].Equals(currentPlayer))
                {
                    hasWon = false;
                    break;
                }
            }

            if (hasWon) return true;
            
            int z = board.GetLength(0) -1;
            for(int i=z ; i >0; i--)
            {
                
                hasWon = true;
                
                if (!board[i, (board.GetLength(0)-1) - i].Equals( currentPlayer))
                {
                    hasWon = false;
                    break;
                }
            }

            return hasWon;
        }

        public bool isBoardFull (string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (!board[i, j].Equals("O") &&  !board[i, j].Equals("X"))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

   
}
