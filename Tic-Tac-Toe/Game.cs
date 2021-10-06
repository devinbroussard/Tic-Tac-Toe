using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
    class Game
    {
        //Defining/initializing variables;
        private static bool _endApplication = false;
        private Board _gameBoard;
        private static int _currentSceneIndex;
        private int _sceneCount = 2;

        /// <summary>
        /// Begins the game
        /// </summary>
        public void Run()
        {
            Start();
            while (!_endApplication)
            {
                Draw();
                Update();
            }
            End();
        }
        
        /// <summary>
        /// Called when the game starts
        /// </summary>
        private void Start()
        {
            _gameBoard = new Board();
            _gameBoard.Start();
        }

        /// <summary>
        /// Called every time the game loops
        /// </summary>
        private void Update()
        {
            switch (_currentSceneIndex)
            {
                case 0:
                    _gameBoard.Update();
                    break;
                case 1:
                    RestartGame();
                    break;
            }

        }

        /// <summary>
        /// Updates the display to reflect any changes made while running
        /// </summary>
        private void Draw() 
        {
            Console.Clear();
            if (_currentSceneIndex == 0)
                _gameBoard.Draw();
        }

        public static bool SetCurrentScene(int sceneIndex)
        {
            if (sceneIndex >= 0 && sceneIndex <= 1)
            {
                _currentSceneIndex = sceneIndex;
                return true;
            }
            return false;
        }

        //Called when the game ends
        private void End()
        {
            _gameBoard.End();
        }

        public static int GetInput()
        {
            int choice = -1;

            if (!int.TryParse(Console.ReadLine(), out choice))
                choice = -1;

            return choice;
        }

        public static void EndApplication()
        {
            _endApplication = true;
        }

        private void RestartGame()
        {
            Console.WriteLine("Would you like to play again?\n");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.Write("> ");

            int input = Game.GetInput();

            if (input == 1)
            {
                _currentSceneIndex = 0;
                _gameBoard.ClearBoard();
            }
            else if (input == 2)
                EndApplication();
            else
            {
                Console.WriteLine("Invalid input!");
                Console.ReadKey(true);
            }
        }
    }
}
