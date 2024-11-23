using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ_Snake_Game.Common
{
    internal abstract class BaseGameLogic : ConsoleInput.IArrowListener
    {
        public void InitInput(ConsoleInput consoleInput)
        {
            consoleInput.Subscribe(this);
        }
        public abstract void OnArrowDown();

        public abstract void OnArrowLeft();

        public abstract void OnArrowRight();

        public abstract void OnArrowUp();

        public abstract void Update(double deltaTime);
    }
}
