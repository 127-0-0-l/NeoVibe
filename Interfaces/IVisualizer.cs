namespace NeoVibe.Interfaces
{
    internal interface IVisualizer
    {
        bool[,] RenderFrame(float[] fftData, int width, int height);
    }
}
