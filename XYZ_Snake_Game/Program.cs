using System.Diagnostics;
using XYZ_Snake_Game.Snake;
using XYZ_Snake_Game.Common;

namespace XYZ_Snake_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameLogic = new SnakeGameLogic();
            var input = new ConsoleInput();
            gameLogic.InitInput(input);
            gameLogic.GotoGameplay();
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var lastFrameTime = sw.Elapsed.TotalSeconds;
            var frameStartTime = sw.Elapsed.TotalSeconds;
            while (true)
            {
                input.Update();
                frameStartTime = sw.Elapsed.TotalSeconds;
                double deltaTime = frameStartTime - lastFrameTime;
                gameLogic.Update(deltaTime);
                lastFrameTime = frameStartTime;
            }
        }
    }
}
