using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ_Snake_Game.Common
{
    internal abstract class BaseGameLogic : ConsoleInput.IArrowListener
    {
        public BaseGameState? currentState { get; protected set; }
        public double time { get; private set; }
        public int screenWidth { get; private set; }
        public int screenHeight { get; private set; }
        public void InitInput(ConsoleInput consoleInput)
        {
            consoleInput.Subscribe(this);
        }

        public void ChangeState(BaseGameState state) {
            currentState?.Reset();
            currentState = state;
        }

        public void DrawNewState(double deltaTime, ConsoleRenderer renderer)
        {
            time += deltaTime;

            screenWidth = renderer.width;
            screenHeight = renderer.height;

            currentState?.Update(deltaTime);
            currentState?.Draw(renderer);
            Update(deltaTime);
        }
        public abstract ConsoleColor[] CreatePallet();

        public abstract void OnArrowDown();

        public abstract void OnArrowLeft();

        public abstract void OnArrowRight();

        public abstract void OnArrowUp();

        public abstract void Update(double deltaTime);
    }
}
