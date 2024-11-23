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

        public override void Reset()
        {
            _currentDir = SnakeDir.Right;
            _timeToMove = 0;
            _body = new List<Cell>();
            _body.Add(new Cell(0, 0));
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
                _timeToMove = 1f / 3f;
            }
            var head = _body[0];
            var nextCell = ShiftToCurrentDir(head);
            _body.Insert(0, nextCell);
            _body.RemoveAt(_body.Count - 1);
            Console.WriteLine($"Snake position X: {nextCell.X} Y: {nextCell.Y}");
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
