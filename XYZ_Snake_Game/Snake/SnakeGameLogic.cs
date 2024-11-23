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
            _gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Left);
        }

        public override void OnArrowUp()
        {
            _gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Up);
        }

        public override void OnArrowRight()
        {
            _gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Right);
        }

        public override void OnArrowDown()
        {
            _gameplayState.SetDirection(SnakeGameplayState.SnakeDir.Down);
        }

        public override void Update(double deltaTime)
        {
            _gameplayState.Update(deltaTime);
        }

        public void GotoGameplay()
        {
            _gameplayState.Reset();
        }
    }
}
