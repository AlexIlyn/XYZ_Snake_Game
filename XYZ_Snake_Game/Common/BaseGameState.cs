using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ_Snake_Game.Common
{
    internal abstract class BaseGameState
    {

        public abstract void Update(double deltaTime);
        public abstract void Reset();
        public abstract void Draw(ConsoleRenderer renderer);
        public abstract bool IsDone();
    }
}
