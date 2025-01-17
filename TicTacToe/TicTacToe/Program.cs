﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        private static bool Xturn = true;
        private static readonly int rows = 3;
        private static readonly int columns = 3;
        private static char current = 'X';
        private static readonly char initChar = ' ';
        private static char[,] board = new char[rows, columns];
        private static readonly string[] commands = { "Start a new game", "Exit" };
        private static readonly string[] inGameCommands = { "Play", "Print Board", "Leave Game" };
        static void Main(string[] args)
        {
            InitBoard(board, rows, columns, initChar);
            Console.Clear();
            //Main Menu
            int ans = 0;
            do {
                Console.WriteLine("Tic Tac Toe Main Menu");
                Console.WriteLine("---------------------");
                for (int i = 0; i < commands.Length; i++)
                {
                    Console.WriteLine((i + 1) + "." + commands[i]);
                }
                Console.WriteLine("Pick an option:");
                try
                {
                    ans = Convert.ToInt32(Console.ReadLine());

                } catch (Exception)
                {
                    Console.WriteLine("The input must be a number between 1 to " + commands.Length);
                }
                ans--; //All the values in the menu are (i+1) therefore, we must adjust the input to the array by decreasing the input by 1
                if (ans == 0)
                {
                    Console.Clear();
                    Game(board, Xturn);
                    Console.Clear();
                }
                else if (ans > commands.Length - 1 || ans < commands.Length - 1)
                {
                    Console.Clear();
                    Main(null);

                }
            } while (ans != commands.Length - 1 && ans < commands.Length - 1);//Exit command will be the last value in the array


        }
        private static void InitBoard(char[,] board, int rows, int columns, char init)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0; k < columns; k++)
                {
                    board[i, k] = init;
                }
            }
        }
        /**
         * Checks the board for winnnig
         * return true if finds one
         *
         */
        private static bool CheckBoardForWinning(char[,] board)
        {
            for (int i = 0; i < rows; i++)// Check Horizontal
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i ,0] != initChar)
                {
                    return true;
                }
            }
            for (int i = 0; i < columns; i++)// Check Vertical 
            {
                if (board[0,i] == board[1, i] && board[0, i] == board[2, i] && board[0,i] != initChar)
                {
                    return true;
                }
            }
            if (((board[0, 0] == board[1, 1] && board[2, 2] == board[0, 0])
                || (board[1, 1] == board[2, 0] && board[1, 1] == board[0, 2])) && board[1, 1] != initChar)//Check Diagonals
            {
                return true;
            }
            return false;
        }

        /**
         * Checks for empty slots in the board
         * true ----> There is still free space
         * false ---->  There is no empty space
         */
        private static bool CheckBoardForEmptySpaces(char[,] board, char initC)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int k = 0;k < columns; k++)
                {
                    if (board[i, k] == initC)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool ChangeTurn(bool turn)
        {
            if (turn)
            {
                current = 'O';
                return false;
            }
            else
            {
                current = 'X';
                return true;
            }
        }
        private static void Game(char[,] board, bool turn)
        {
            int n;
            bool exit = false;
            bool win;
            do
            {
                Console.WriteLine("Current Turn: {0}", current);
                n = InGameMenu();
                exit = DoMove(n, exit);
                win = CheckBoardForWinning(board);
                if(!exit)
                {
                    Xturn = ChangeTurn(Xturn);
                }

            }
            while (CheckBoardForEmptySpaces(board, initChar) && !exit && !win);
           
            if(!exit&& !win) // if no one wins and no one quited from the game
            {
                Console.WriteLine("It's a tie!");
                Main(null);

            }
            else if(win && !exit)// if someone won
            {
                switch (!Xturn)
                {
                    case true:
                        Console.WriteLine("The Winner is X");
                        break;
                    case false:
                        Console.WriteLine("The Winner is O");
                        break;
                }
                Console.Read();
                Main(null);

            }
        }

        private static bool DoMove(int n, bool exit)
        {
            int slot;
            int[] coordinate;
            switch (n)
            {
                case 1:
                    slot = GetSlotNum();
                    coordinate = Methods.TranslateNumberToCoordinate(slot);
                    while (board[coordinate[0], coordinate[1]] != initChar)
                    {
                        slot = GetSlotNum();
                        coordinate = Methods.TranslateNumberToCoordinate(slot);
                    }
                    board[coordinate[0], coordinate[1]] = current;
                    PrintBoard(board);
                    break;
                case 2:
                    PrintBoard(board);
                    DoMove(InGameMenu(), exit);
                    break;
                case 3:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Please enter a valid number");
                    DoMove(InGameMenu(), exit);
                    break;
            }
            return exit;
        }
        /// <summary>
        /// Get from the user the number of the slot. In addition checks if the input is valid(1<=number<=9)
        /// </summary>
        /// <returns>slot number</returns>
        private static int GetSlotNum()
        {
            int pick;
            Console.WriteLine("Where do you want to put {0}:", current);
            try
            {
                 pick = Convert.ToInt32(Console.ReadLine());
                if(pick >9 || pick<1)
                {
                    Console.WriteLine("Please enter slot number between 1 to 9");
                    return GetSlotNum();
                }
            }
            catch(Exception )
            {
                Console.WriteLine("Couldn't parse the input. Please try again");
                return GetSlotNum();
                
            }
            return pick;
        }

        private static int InGameMenu()
        {
            int pick = 0;
            for(int i = 0; i <inGameCommands.Length;i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, inGameCommands[i]);
                
            }
            Console.WriteLine("Pick an option:");
            try
            {
                pick = Convert.ToInt32(Console.ReadLine());
                if (pick > inGameCommands.Length || pick <= 0)
                {
                    Console.WriteLine("Please pick a number between 1 to {0}\n Press any key to continue...", inGameCommands.Length);
                    Console.ReadLine();
                    return InGameMenu();
                }
            }
            catch (Exception)
            {
                Console.Clear();
                
                Console.WriteLine("Couldn't parse the input... please try again");
                return InGameMenu();

            }
            return pick;
        }

        private static void PrintBoard(char[,] board)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |      ");
        }
    }
}
