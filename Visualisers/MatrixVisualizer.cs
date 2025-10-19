using NeoVibe.Interfaces;

namespace NeoVibe.Visualisers
{
    internal class MatrixVisualizer : IVisualizer
    {
        private bool[,] lastFrame;

        public bool[,] RenderFrame(float[] fftData, int width, int height)
        {
            if (lastFrame == null)
                lastFrame = new bool[width, height];

            int blockSize = fftData.Length / width;

            int[] heights = new int[width];
            for(int i = 0; i < width; i++)
            {
                int lastFrameH = GetColumnHeight(lastFrame, i);
                heights[i] = (int)(fftData[i + blockSize] * height);
                if (heights[i] < lastFrameH)
                    heights[i] = lastFrameH - 1;
            }

            bool[,] frame = new bool[width, height];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    frame[i, j] = (height - heights[i] - 1) < j;

            lastFrame = frame;
            return frame;
        }

        private int GetColumnHeight(bool[,] array, int column)
        {
            int height = 0;
            for (int i = 0; i < array.GetLength(1); i++)
                height += array[column, i] ? 1 : 0;

            return height;
        }
    }
}
