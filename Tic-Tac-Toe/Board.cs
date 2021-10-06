using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Board
    {
        private char _player1Token;
        private char _player2Token;
        private char _currentToken;
        private char[,] _board;
        private int _currentTurnNumber;

        public void Start()
        {
            _player1Token = 'x';
            _player2Token = 'o';
            _currentToken = _player1Token;
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }

        /// <summary>
        /// Gets the input from the player.
        /// Sets the player token at the desired spot in the 2D array.
        /// Checks if there is a winner.
        /// Changes the current token in play.
        /// </summary>
        public void Update()
        {
            int input;
            
            if (CheckWinner())
            {
                if (_currentToken == _player2Token)
                    _currentToken = _player1Token;
                else
                    _currentToken = _player2Token;

                Console.Write($"\nPlayer {_currentToken} won!");
                Console.ReadKey(true);
                Game.SetCurrentScene(1);
            }
            else if (_currentTurnNumber == 9)
            {
                Console.Write("\nThe game has been tied!");
                Console.ReadKey(true);
                Game.SetCurrentScene(1);

            }
            else
            {
                Console.Write("> ");
                input = Game.GetInput() - 1;

                if (input >= 0 && input <= 8)
                {
                    int x = input / _board.GetLength(0);
                    int y = input % _board.GetLength(0);

                    if (SetToken(_currentToken, x, y))
                    {
                        _currentTurnNumber++;

                        if (_currentToken == _player1Token)
                            _currentToken = _player2Token;
                        else _currentToken = _player1Token;
                    }
                    else
                    {
                        Console.WriteLine("\nThat slot is taken already!");
                        Console.ReadKey(true);
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input!");
                    Console.ReadKey(true);
                }
            }
        }

        /// <summary>
        /// Draws the board and let's the players know whose turn it is
        /// </summary>
        public void Draw()
        {
            Console.WriteLine("Write the number of the slot you would like to place your token!");
            Console.WriteLine($"Current turn: {_currentToken}\n");
            Console.WriteLine($"\t{_board[0, 0]} | {_board[0, 1]} | {_board[0, 2]}\n" +
                                "\t_________\n" +
                                $"\t{_board[1, 0]} | {_board[1, 1]} | {_board[1, 2]}\n" +
                                "\t_________\n" +
                                $"\t{_board[2, 0]} | {_board[2, 1]} | {_board[2, 2]}");
        }
        public void End() 
        {
        }

        /// <summary>
        /// Assigns the spot at the given indices to the board array to be the given tokenn.
        /// </summary>
        /// <param name="token">The token to set the array index to.</param>
        /// <param name="posX">The x position of the token.</param>
        /// <param name="posY">The y position of the token.</param>
        /// <returns>Returns false if the indices are out of range.</returns>
        public bool SetToken(char token, int posX, int posY) 
        {
            if (!(_board[posX, posY] == _player1Token || _board[posX, posY] == _player2Token))
            {
                _board[posX, posY] = token;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the token appears three times consecutively vertically, horizontally, or diagonally.
        /// </summary>
        /// <returns></returns>
        public bool CheckWinner()
        {
            //Checks for matching tokens top down for each column
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                if (_board[0,j] == _board[1, j] && _board[1, j] == _board[2, j])
                    return true;
            }

            //Checks for matching tokens sideways for each row
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                if (_board[i, 0] == _board[i, 1] && _board[i, 1] == _board[i, 2])
                    return true;
            }

            if ((_board[0,0] == _board[1, 1] && _board[1, 1] == _board[2, 2]) || (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0]))
                return true;
            
            return false;
        }

        /// <summary>
        /// Resets the board to it's default state.
        /// </summary>
        public void ClearBoard() 
        {
            _currentTurnNumber = 0;
            _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        }
    }
}
