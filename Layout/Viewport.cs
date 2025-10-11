namespace NeoVibe.Layout
{
    internal abstract class Viewport
    {
        internal int X { get; set; }

        internal int Y { get; set; }

        internal int Width { get; private set; }

        internal int Height { get; private set; }

        protected char[,] _charMap;

        internal Viewport()
        {
            X = 0;
            Y = 0;
            Width = 1;
            Height = 1;
            _charMap = new char[Width, Height];
            InitCharMap();
        }

        internal Viewport(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = Math.Max(width, 1);
            Height = Math.Max(height, 1);
            _charMap = new char[Width, Height];
            InitCharMap();
        }

        internal void Resize(int width, int height)
        {
            Width = Math.Max(width, 1);
            Height = Math.Max(height, 1);
            _charMap = new char[Width, Height];
            InitCharMap();
        }

        internal char[,] GetViewport() => _charMap;

        internal abstract void KeyPress(ConsoleKey key);

        private void InitCharMap()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    _charMap[i, j] = ' ';
                }
            }
        }
    }
}
