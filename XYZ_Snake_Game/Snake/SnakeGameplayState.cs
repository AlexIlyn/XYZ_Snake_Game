using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZ_Snake_Game.Common;

namespace XYZ_Snake_Game.Snake
{
    internal class SnakeGameplayState : BaseGameState
    {
        private SnakeDir _currentDir;
        private double _timeToMove;
        private List<Cell> _body;
        public Cell _apple { get; private set; }
        public int level { get; set; }

        private Random _random = new Random();

        public int fieldWidth { get; set; }
        public int fieldHeight { get; set; }
        public bool gameOver { get; private set; }
        public bool hasWon { get; private set; }

        public const char snakeBody = '■';
        public const char appleChar = 'O';

        private Cell CreateApple() {
            var x = _random.Next(fieldWidth);
            var y = _random.Next(fieldHeight);
            Cell cell = new Cell(x, y);
            if(cell.Equals(_body[0])) {
                if(y > fieldHeight/2) {
                    cell.Y -= 1;
                } else {
                    cell.Y += 1;
                }
            }
            return cell;
        }

        public override void Reset()
        {
            gameOver = false;
            hasWon = false;
            _currentDir = SnakeDir.Right;
            _timeToMove = 0;
            _body = new List<Cell>();
            int middleX = fieldWidth / 2;
            int middleY = fieldHeight / 2;
            _body.Add(new Cell(middleX, middleY));
            _apple = CreateApple();
        }

        public override void Update(double deltaTime)
        {
            _timeToMove -= deltaTime;
            if (_timeToMove > 0 || gameOver)
            {
                return;
            }
            else
            {
                _timeToMove = 1f / (5f + level);
            }
            var head = _body[0];
            var nextCell = ShiftToCurrentDir(head);
            if (nextCell.Equals(_apple)) {
                _body.Insert(0, _apple);
                if(_body.Count >= level + 3) {
                    hasWon = true;
                }
                _apple = CreateApple();
            }
            if (nextCell.X < 0 || nextCell.X > fieldWidth || nextCell.Y < 0 || nextCell.Y > fieldHeight)
            {
                gameOver = true;
                return;
            }
            _body.Insert(0, nextCell);
            _body.RemoveAt(_body.Count - 1);
        }

        public void SetDirection(SnakeDir dirrection)
        {
            _currentDir = dirrection;
        }
        private Cell ShiftToCurrentDir(Cell cell)
        {
            switch (_currentDir)
            {
                case SnakeDir.Left:
                    return new Cell(cell.X - 1, cell.Y);
                case SnakeDir.Up:
                    return new Cell(cell.X, cell.Y - 1);
                case SnakeDir.Right:
                    return new Cell(cell.X + 1, cell.Y);
                case SnakeDir.Down:
                    return new Cell(cell.X, cell.Y + 1);
            }

            return cell;
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            renderer.DrawString($"Score: {_body.Count - 1}", 3, 1, ConsoleColor.White);
            renderer.DrawString($"Level: {level}", 3, 2, ConsoleColor.White);
            for (int i = 0; i < _body.Count; i++)
            {
                renderer.SetPixel(_body[i].X, _body[i].Y, snakeBody, 0);
            }
            renderer.SetPixel(_apple.X, _apple.Y, appleChar, 1);
        }

        public override bool IsDone()
        {
            return gameOver || hasWon;
        }

        internal struct Cell
        {

            public int X { get; set; }
            public int Y { get; set; }

            public Cell(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        internal enum SnakeDir
        {
            Left,
            Up,
            Right,
            Down
        }
    }
}
