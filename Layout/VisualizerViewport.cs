using static NeoVibe.Constants.AppConstants;

namespace NeoVibe.Layout
{
    internal class VisualizerViewport : Viewport
    {
        private Random _rnd = new Random();

        internal override void KeyPress(ConsoleKey key)
        {
            
        }

        internal void SetFrame(bool[,] visualizerFrame)
        {
            int width = visualizerFrame.GetLength(0);
            int height = visualizerFrame.GetLength(1);

            if (_charMap.GetLength(0) == width &&
                _charMap.GetLength(1) == height)
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (_charMap[i, j] == ' ' && visualizerFrame[i, j])
                            _charMap[i, j] = ConsoleCharset[_rnd.Next(ConsoleCharset.Length)];
                        else if (_charMap[i, j] != ' ' && !visualizerFrame[i, j])
                            _charMap[i, j] = ' ';
                    }
                }
            }
        }
    }
}
