using NeoVibe.Interfaces;

namespace NeoVibe.Visualisers
{
    internal class SpectrumVisualizer : IVisualizer
    {
        private int _width = 0;
        private int _height = 0;
        private int[] _previousHeights;
		private const float _minFFTMax = 0.3f;
		private const float _heightFactor = 0.8f;

        bool[,] IVisualizer.RenderFrame(float[] fftData, int width, int height)
        {
            ValidateSize(width, height);

			for (int i = 0; i < fftData.Length; i++)
            {
                fftData[i] *= (float)Math.Sqrt(1 + i);
            }
			
			float[] blockFFT = new float[_width];
            int blockSize = fftData.Length / _width;
			for (int i = 0; i < blockFFT.Length; i++)
            {
                float sum = 0;
                for (int j = 0; j < blockSize; j++)
                    sum += fftData[i * blockSize + j];
                blockFFT[i] = sum / blockSize;
            }
			
			float maxFFT = Math.Max(blockFFT.Max(), _minFFTMax);
			for (int i = 0; i < blockFFT.Length; i++)
            {
                blockFFT[i] = blockFFT[i] / maxFFT * _heightFactor;
            }

			int[] heights = new int[blockFFT.Length];
            for (int i = 0; i < heights.Length; i++)
            {
                heights[i] = (int)(blockFFT[i] * _height);
                //heights[i] = heights[i] >= _previousHeights[i] ? heights[i] : _previousHeights[i] - 1;
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
