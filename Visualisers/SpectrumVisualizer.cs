using NeoVibe.Interfaces;

namespace NeoVibe.Visualisers
{
    internal class SpectrumVisualizer : IVisualizer
    {
        private int _width = 0;
        private int _height = 0;
        //private bool[,] _previousFrame;

        bool[,] IVisualizer.RenderFrame(float[] fftData, int width, int height)
        {
            ValidateSize(width, height);

            for (int i = 0; i < fftData.Length; i++)
            {
                fftData[i] *= 10;
            }

            int[] heights = new int[_width];
            for (int i = 0; i < _width; i++)
            {
                heights[i] = (int)(fftData[i] * height);
            }

            bool[,] frame = new bool[width, height];
            for (int i = 0; i < _width; i++)
                for (int j = 0; j < _height; j++)
                    frame[i, j] = (_height - heights[i] - 1) < j;

            return frame;

            //return _previousFrame;
        }

        private void ValidateSize(int width, int height)
        {
            if (width != _width || height != _height)
            {
                _width = width;
                _height = height;
                //_previousFrame = new bool[width, height];
            }
        }
    }
}
