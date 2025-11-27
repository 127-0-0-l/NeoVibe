using NeoVibe.Interfaces;

namespace NeoVibe.Visualisers
{
    internal class SpectrumVisualizer : IVisualizer
    {
        private int _width = 0;
        private int _height = 0;
        private int[] _previousHeights;

        bool[,] IVisualizer.RenderFrame(float[] fftData, int width, int height)
        {
            ValidateSize(width, height);
            int blockSize = fftData.Length / _width;

            for (int i = 0; i < fftData.Length; i++)
            {
                fftData[i] = fftData[i] * (1 + i / blockSize / 2);
            }

            int[] heights = new int[_width];
            for (int i = 0; i < _width; i++)
            {
                float sum = 0;
                for (int j = 0; j < blockSize; j++)
                {
                    sum += fftData[i + j];
                }
                heights[i] = (int)(sum / blockSize * _height);
                heights[i] = heights[i] >= _previousHeights[i] ? heights[i] : _previousHeights[i] - 1;
                heights[i] = (heights[i] + _previousHeights[i]) / 2;
            }

            for (int i = 0; i < _width; i++)
            {
                _previousHeights[i] = heights[i];
            }

            bool[,] frame = new bool[_width, _height];
            for (int i = 0; i < _width; i++)
                for (int j = 0; j < _height; j++)
                    frame[i, j] = (_height - heights[i] - 1) < j;

            return frame;
        }

        private void ValidateSize(int width, int height)
        {
            if (width != _width || height != _height)
            {
                _width = width;
                _height = height;
                _previousHeights = new int[_width];
            }
        }
    }
}
