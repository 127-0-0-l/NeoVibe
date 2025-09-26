using NeoVibe.Interfaces;

namespace NeoVibe.Visualisers
{
    internal class MatrixVisualizer : IVisualizer
    {
        public bool[,] RenderFrame(float[] fftData, int width, int height)
        {
            return new bool[width, height];
        }
    }
}
