using NeoVibe.Interfaces;

namespace NeoVibe.Visualisers
{
    internal class SpectrumVisualizer : IVisualizer
    {
        void IVisualizer.Init(int height, int width, int fftLength)
        {
            throw new NotImplementedException();
        }

        bool[,] IVisualizer.RenderFrame(float[] fftData)
        {
            throw new NotImplementedException();
        }
    }
}
