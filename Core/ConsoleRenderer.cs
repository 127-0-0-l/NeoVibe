using NeoVibe.Layout;
using System.Text;

namespace NeoVibe.Core
{
    internal static class ConsoleRenderer
    {
        private static int _consoleHeight;
        private static int _consoleWidth;
        private static Viewport[] _viewports;

        internal static void Init(Viewport[] viewports)
        {
            _viewports = viewports;
            CheckResize();
        }

        internal static void KeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(Environment.ExitCode);
                    break;
                default:
                    return;
            }
        }

        internal static void RenderFrame()
        {
            CheckResize();

            var viewport = _viewports[0].GetViewport();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _consoleHeight; i++)
                for (int j = 0; j < _consoleWidth; j++)
                    sb.Append(viewport[j, i]);

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
