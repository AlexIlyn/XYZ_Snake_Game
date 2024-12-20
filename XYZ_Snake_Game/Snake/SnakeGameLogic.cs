﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZ_Snake_Game.Common;

namespace XYZ_Snake_Game.Snake
{
    internal class SnakeGameLogic : BaseGameLogic
    {
        private bool newGamePending = false;
        private int currentLevel;
        private ShowTextState showTextState = new ShowTextState(2f);


        private SnakeGameplayState _gameplayState = new SnakeGameplayState();

        public override void OnArrowLeft()
        {
            if (currentState != _gameplayState)
            {
                return;
            }
            _gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Left);
        }

        public override void OnArrowUp()
        {
            if (currentState != _gameplayState)
            {
                return;
            }
            _gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Up);
        }

        public override void OnArrowRight()
        {
            if (currentState != _gameplayState)
            {
                return;
            }
            _gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Right);
        }

        public override void OnArrowDown()
        {
            if (currentState != _gameplayState)
            {
                return;
            }
            _gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Down);
        }

        public override void Update(double deltaTime)
        {
            if (currentState != null && !currentState.IsDone())
            {
                return;
            }
            if (currentState == null || currentState == _gameplayState && !_gameplayState.gameOver)
            {
                GoToNextLevel();
            }
            else if (currentState == _gameplayState && _gameplayState.gameOver)
            {
                GoToGameover();
            }
            else if (currentState != _gameplayState && newGamePending)
            {
                GoToNextLevel();
            }
            else if (currentState != _gameplayState && !newGamePending)
            {
                GoToGameplay();
            }
        }

        public void GoToGameplay()
        {
            _gameplayState.fieldWidth = screenWidth;
            _gameplayState.fieldHeight = screenHeight;
            _gameplayState.Reset();
            _gameplayState.level = currentLevel;
            currentState = _gameplayState;
            ChangeState(_gameplayState);
        }

        public void GoToNextLevel()
        {
            currentLevel++;
            newGamePending = false;
            showTextState.text = $"Next level: {currentLevel}";
            showTextState.Reset();
            ChangeState(showTextState);
        }

        public void GoToGameover()
        {
            currentLevel = 0;
            newGamePending = true;
            showTextState.text = "Game Over!";
            showTextState.Reset();
            ChangeState(showTextState);
        }

        public override ConsoleColor[] CreatePallet()
        {
            return [ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.White];
        }
    }
}
