using NeoVibe.Interfaces;

namespace NeoVibe.Visualisers
{
    internal class SpectrumVisualizer : IVisualizer
    {
        private int _width = 0;
        private int _height = 0;
        private bool[,] _previousFrame;

        bool[,] IVisualizer.RenderFrame(float[] fftData, int width, int height)
        {
            ValidateSize(width, height);

            return _previousFrame;
        }

        private void ValidateSize(int width, int height)
        {
            if (width != _width || height != _height)
            {
                _width = width;
                _height = height;
                _previousFrame = new bool[width, height];
            }
        }
    }
}
