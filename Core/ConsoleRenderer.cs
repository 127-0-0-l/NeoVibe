using NeoVibe.Layout;
using System.Text;

namespace NeoVibe.Core
{
    internal static class ConsoleRenderer
    {
        private static int _consoleHeight;
        private static int _consoleWidth;
        private static Viewport[] _viewports;
		private static ConsoleColor[] _consoleColors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
		private static int _currentConsoleColorIndex = 1;

        internal static void Init(Viewport[] viewports)
        {
            _viewports = viewports;
            CheckResize();
            Console.CursorVisible = false;
        }

        internal static void KeyPress(ConsoleKey key)
        {
            switch (key)
            {
				case ConsoleKey.RightArrow:
					_currentConsoleColorIndex = _currentConsoleColorIndex < _consoleColors.Length - 1 ? ++_currentConsoleColorIndex : 1;
					Console.ForegroundColor = _consoleColors[_currentConsoleColorIndex];
					break;
				case ConsoleKey.LeftArrow:
					_currentConsoleColorIndex = _currentConsoleColorIndex > 1 ? --_currentConsoleColorIndex : _consoleColors.Length - 1;
					Console.ForegroundColor = _consoleColors[_currentConsoleColorIndex];
					break;
                case ConsoleKey.Escape:
                    Environment.Exit(Environment.ExitCode);
                    break;
                default:
                    return;
            }
        }

        internal static void RenderFrame(int counter)
        {
            CheckResize();

            var viewport = _viewports[0].GetViewport();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _consoleHeight; i++)
                for (int j = 0; j < _consoleWidth; j++)
                    sb.Append(viewport[j, i]);

            string c = counter.ToString("D2");
            for (int i = 0; i < c.Length; i++)
                sb[i] = c[i];

            Console.SetCursorPosition(0, 0);
            Console.Write(sb);
        }

        static void CheckResize()
        {
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;

            if (_consoleHeight != height || _consoleWidth != width)
            {
                try
                {
                    Console.Clear();
                    Console.SetBufferSize(width, height);

                    _consoleWidth = width;
                    _consoleHeight = height;

                    foreach (var v in _viewports)
                        v.Resize(_consoleWidth, _consoleHeight);
                }
                catch { }
            }
        }

        private static void SetViewportsSizes()
        {

        }
    }
}
