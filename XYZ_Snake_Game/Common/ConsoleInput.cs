using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZ_Snake_Game.Common
{
    public class ConsoleInput
    {
        public interface IArrowListener
        {

            public abstract void OnArrowLeft();
            public abstract void OnArrowUp();
            public abstract void OnArrowRight();
            public abstract void OnArrowDown();
        }

        private HashSet<IArrowListener> _arrowListeners = new HashSet<IArrowListener>();

        public void Subscribe(IArrowListener arrowListener)
        {
            _arrowListeners.Add(arrowListener);
        }
        public void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        foreach (var listener in _arrowListeners)
                        {
                            listener.OnArrowLeft();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        foreach (var listener in _arrowListeners)
                        {
                            listener.OnArrowUp();
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        foreach (var listener in _arrowListeners)
                        {
                            listener.OnArrowRight();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        foreach (var listener in _arrowListeners)
                        {
                            listener.OnArrowDown();
                        }
                        break;
                }
            }
        }
    }
}
