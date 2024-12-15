using System.Diagnostics;
using XYZ_Snake_Game.Snake;
using XYZ_Snake_Game.Common;

namespace XYZ_Snake_Game
{
    internal class Program
    {
        private const double targerFrameTime = 1 / 2;
        static void Main(string[] args)
        {
            var gameLogic = new SnakeGameLogic();

            var pallete = gameLogic.CreatePallet();

            var renderer0 = new ConsoleRenderer(pallete);
            var renderer1 = new ConsoleRenderer(pallete);

            var input = new ConsoleInput();
            gameLogic.InitInput(input);

            var previousRenderer = renderer0;
            var currentRenderer = renderer1;

            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var lastFrameTime = sw.Elapsed;
            var frameStartTime = sw.Elapsed;
            var frameEndTime = sw.Elapsed;
            while (true)
            {
                frameStartTime = sw.Elapsed;
                double deltaTime = (frameStartTime.TotalSeconds - lastFrameTime.TotalSeconds);
                input.Update();

                gameLogic.DrawNewState(deltaTime, currentRenderer);
                lastFrameTime = frameStartTime;

                if(!currentRenderer.Equals(previousRenderer)) {
                    currentRenderer.Render();
                }
                var tmpRndr = previousRenderer;
                previousRenderer = currentRenderer;
                currentRenderer = tmpRndr;
                currentRenderer.Clear();

                var nextFrameTime = frameStartTime + TimeSpan.FromSeconds(targerFrameTime);
                frameEndTime = sw.Elapsed;
                if (nextFrameTime > frameEndTime) {
                    Thread.Sleep(Convert.ToInt32((nextFrameTime - frameEndTime).TotalMilliseconds));
                }
            }
        }
    }
}
