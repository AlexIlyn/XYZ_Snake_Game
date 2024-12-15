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
        public int fieldWidth { get; set; }
        public int fieldHeight { get; set; }
        public const char snakeBody = '■';

        public override void Reset()
        {
            _currentDir = SnakeDir.Right;
            _timeToMove = 0;
            _body = new List<Cell>();
            int middleX = fieldWidth / 2;
            int middleY = fieldHeight / 2;
            _body.Add(new Cell(middleX, middleY));
        }

        public override void Update(double deltaTime)
        {
            _timeToMove -= deltaTime;
            if (_timeToMove > 0)
            {
                return;
            }
            else
            {
                _timeToMove = 1f / 5f;
            }
            var head = _body[0];
            var nextCell = ShiftToCurrentDir(head);
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
                    return new Cell((fieldWidth + cell.X - 1) % fieldWidth, cell.Y);
                case SnakeDir.Up:
                    return new Cell(cell.X, (fieldWidth + cell.Y - 1) % fieldHeight);
                case SnakeDir.Right:
                    return new Cell((fieldWidth + cell.X + 1) % fieldWidth, cell.Y);
                case SnakeDir.Down:
                    return new Cell(cell.X, (fieldWidth + cell.Y + 1) % fieldHeight);
            }

            return cell;
        }

        public override void Draw(ConsoleRenderer renderer)
        {
            for (int i = 0; i < _body.Count; i++)
            {
                renderer.SetPixel(_body[i].X, _body[i].Y, snakeBody, Convert.ToByte(i % 3));
            }
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
