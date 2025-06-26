namespace NeoVibe.Interfaces
{
    internal interface IVisualizer
    {
        void Init(int height, int width, int fftLength);

        bool[,] RenderFrame(float[] fftData);
    }
}
