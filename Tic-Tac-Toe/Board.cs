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

        public void Start()
        {
            _player1Token = 'x';
            _player2Token = 'o';
            _currentToken = _player1Token;
            _board = new char[3, 3] { { '-', '-', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };
        }

        /// <summary>
        /// Gets the input from the player.
        /// Sets the player token at the desired spot in the 2D array.
        /// Checks if there is a winner.
        /// Changes the current token in play.
        /// </summary>
        public void Update()
        {
            if (Game.GetInput() == 1)
                _board[0, 0] = _currentToken;

            if (_currentToken == _player1Token)
                _currentToken = _player2Token;
            else _currentToken = _player1Token;
        }

        /// <summary>
        /// Draws the board and let's the players know whose turn it is
        /// </summary>
        public void Draw()
        {
            Console.WriteLine($"{_board[0, 0]} | {_board[0, 1]} | {_board[0, 2]}\n" +
                                "_________\n" +
                                $"{_board[1, 0]} | {_board[1, 1]} | {_board[1, 2]}\n" +
                                "_________\n" +
                                $"{_board[2, 0]} | {_board[2, 1]} | {_board[2, 2]}");
        }
        public void End() { }

        /// <summary>
        /// Assigns the spot at the given indices to the board array to be the given tokenn.
        /// </summary>
        /// <param name="token">The token to set the array index to.</param>
        /// <param name="posX">The x position of the token.</param>
        /// <param name="posY">The y position of the token.</param>
        /// <returns>Returns false if the indices are out of range.</returns>
        public bool SetToken(char token, int posX, int posY) 
        {
            return false;
        }

        /// <summary>
        /// Checks to see if the token appears three times consecutively vertically, horizontally, or diagonally.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool CheckWinner(char token)
        {
            return false;
        }

        /// <summary>
        /// Resets the board to it's default state.
        /// </summary>
        public void ClearBoard() { }
    }
}
