using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZ_Snake_Game.Common;

namespace XYZ_Snake_Game.Snake
{
    internal class SnakeGameLogic : BaseGameLogic
    {

        private SnakeGameplayState _gameplayState = new SnakeGameplayState();

        public override void OnArrowLeft()
        {
            if(currentState != _gameplayState) {
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
            if (currentState != _gameplayState)
            {
                GotoGameplay();
            }
        }

        public void GotoGameplay()
        {
            _gameplayState.fieldWidth = screenWidth;
            _gameplayState.fieldHeight = screenHeight;
            _gameplayState.Reset();
            currentState = _gameplayState;
            ChangeState(_gameplayState);
        }

        public override ConsoleColor[] CreatePallet()
        {
            return [ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.DarkYellow];
        }
    }
}
