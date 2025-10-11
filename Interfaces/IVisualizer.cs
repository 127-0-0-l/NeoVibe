namespace NeoVibe.Interfaces
{
    public interface IVisualizer
    {
        bool[,] RenderFrame(float[] fftData, int width, int height);
    }
}
