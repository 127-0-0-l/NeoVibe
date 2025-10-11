using NeoVibe.Interfaces;

namespace NeoVibe.Visualisers
{
    internal class MatrixVisualizer : IVisualizer
    {
        public bool[,] RenderFrame(float[] fftData, int width, int height)
        {
            bool[,] frame = new bool[width, height];
            Random rnd = new Random();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    frame[i, j] = rnd.Next(2) == 1;
                }
            }

            return frame;
        }
    }
}
