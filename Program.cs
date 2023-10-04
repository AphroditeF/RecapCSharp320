using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TicTacToe // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static bool Checker(char[,] board)
            {
                bool isWinner = false;
                // TODO
                int i;
                int j = 0;

                for (i = 0; i < 3; i++)
                {
                    if ((board[i, j] == 'X') && (board[i, j + 1] == 'X') && (board[i, j + 2] == 'X'))
                        isWinner = true;
                    else if ((board[i, j] == 'O') && (board[i, j + 1] == 'O') && (board[i, j + 2] == 'O'))
                        isWinner = true;
                }

                i = 0;
                for (j = 0; j < 3; j++)
                {
                    if ((board[i, j] == 'X') && (board[i + 1, j] == 'X') && (board[i + 2, j] == 'X'))
                        isWinner = true;
                    else if ((board[i, j] == 'O') && (board[i + 1, j] == 'O') && (board[i + 2, j] == 'O'))
                        isWinner = true;
                }

                if ((board[i, i] == 'X') && (board[i + 1, i + 1] == 'X') && (board[i + 2, i + 2] == 'X'))
                    isWinner = true;
                else if ((board[i, i] == 'O') && (board[i + 1, i + 1] == 'O') && (board[i + 2, i + 2] == 'O'))
                    isWinner = true;

                int k, l;
                k = 0;
                l = 2;

                if ((board[k, l] == 'X') && (board[k + 1, l - 1] == 'X') && (board[k + 2, l - 2] == 'X'))
                    isWinner = true;
                else if ((board[k, l] == 'O') && (board[k + 1, l - 1] == 'O') && (board[k + 2, l - 2] == 'O'))
                    isWinner = true;

                return isWinner;
            }

            static void InitialiseMatrix(char[,] board)
            {

                char k = '1';
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = k;
                        k++;
                    }

                };
                
            }   

            static void DisplayMatrix(char[,] board) {

                Console.WriteLine("------------------------------------------------------------");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(board[i, j]);
                        Console.Write("|");
                    }
                    Console.WriteLine("\n------");
                };
            }

            static bool AskForPlaying()
            {
                Console.WriteLine("Do you want to play Tic Tac Toe?");
                string answer = Console.ReadLine();
                if ((answer =="yes")|| (answer == "yeah")||(answer == "y")||(answer == "Yes") || (answer == "Yeah")||(answer == "Y")||(answer == "YES") || (answer == "YEAH"))
                {
                    return true;
                }
                return false;
            }
            static void Play(string pl, int pos,char[,] board)
            {
                char c='A';
                if ((pl == "player X") || (pl == "X") || (pl == "x"))
                    c = 'X';
                else if ((pl == "player O") || (pl == "O") || (pl == "o"))
                    c = 'O';
                else
                {
                    c = 'Z';
                    Console.WriteLine("inside Play():player{0}",pl);
                }

                switch (pos) 
                {
                    case 1:
                        board[0, 0] = c;
                        if (Checker(board))
                            Console.WriteLine("Winner is player {0}", pl);
                        break;
                    case 2:
                        board[0, 1] = c;
                        if (Checker(board))
                            Console.WriteLine("Winner is player {0}", pl);
                        break;
                    case 3:
                        board[0, 2] = c;
                        if (Checker(board))
                            Console.WriteLine("Winner is player {0}", pl);
                        break;
                    case 4:
                        board[1, 0] = c;
                        if (Checker(board))
                            Console.WriteLine("Winner is player {0}", pl);
                        break;
                    case 5:
                        board[1, 1] = c;
                        if (Checker(board))
                            Console.WriteLine("Winner is player {0}", pl);
                        break;
                    case 6:
                        board[1, 2] = c;
                        if (Checker(board))
                            Console.WriteLine("Winner is player {0}", pl);
                        break;
                    case 7:
                        board[2, 0] = c;
                        if (Checker(board))
                            Console.WriteLine("Winner is player {0}", pl);
                        break;
                    case 8:
                        board[2, 1] = c;
                        if (Checker(board))
                            Console.WriteLine("Winner is player {0}", pl);
                        break;
                    case 9:
                        board[2, 2] = c;
                        if (Checker(board))
                            Console.WriteLine("Winner is player {0}", pl);
                        break;
                    

                }
                
            }
            


            char[,] matrix = new char[3, 3];
            InitialiseMatrix(matrix);
            DisplayMatrix(matrix);
            bool userAnswerForPlayingIsPositive=AskForPlaying();
            string player;
            while (userAnswerForPlayingIsPositive)
            { 
                int t = 0;
                int userInput;

                player = "player X";
                char sign = 'X';
                
                do
                {
                    t = 0;
                    Console.WriteLine("It's turn of {0} From Positions 1 to 9 where do you want to put your \"{1}\"?", player, sign);
                    try
                    {
                        userInput = Int32.Parse(Console.ReadLine());
                        Play(player, userInput, matrix);

                        DisplayMatrix(matrix);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("problem");
                        break;
                    }

                    t++;
                    if (player == "player X")
                    {
                        player = "player O";
                        sign = 'O';
                    }
                    else if (player == "player O")
                    {
                        player = "player X";
                        sign = 'X';
                    }
                } while ((t <= 9)&& !Checker(matrix) );
                userAnswerForPlayingIsPositive = AskForPlaying();

            } 

            Console.WriteLine("Bye");

        }
    }
}
