using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _201635037
{
    internal class TicTacToe_Run : TicTacToe_BaseApp
    {
        private String currentUser;
        public TicTacToe_Run()
        {
            currentUser = "X";
        }
        public override void Run()
        {
            while (true)
            {
                DrawBoard();
                Console.WriteLine("It's {0}'s turn.", currentUser);
                int pos;
                if (currentUser == "X")
                {
                    // User's turn
                    Console.Write("Enter a position to mark (1-9): ");
                    pos = Convert.ToInt32(Console.ReadLine());
                }else
                {
                    // Computer's turn
                    pos = FindNextPosByAI();
                }if (!AddInputToBoard(pos, currentUser))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }if (CheckWin(currentUser))
                {
                    Console.WriteLine("{0} wins!", currentUser);
                    break;
                }if (board.Count == 9)
                {
                    Console.WriteLine("The game ends in a tie.");
                    break;
                }
                currentUser = currentUser == "X" ? "O" : "X";
            }
        }

        protected override bool CheckWin(string user)
        {
            foreach (int[] winList in WinLists)
            {
                if (board.ContainsKey(winList[0]) && board.ContainsKey(winList[1]) && board.ContainsKey(winList[2]))
                {
                    if (board[winList[0]] == user && board[winList[1]] == user && board[winList[2]] == user)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
