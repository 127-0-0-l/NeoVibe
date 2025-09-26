using NeoVibe.Interfaces;

namespace NeoVibe.Core
{
    internal class VisualizerManager
    {
        private readonly List<IVisualizer> _visualizers;
        private readonly int _count;
        private int _index;

        internal VisualizerManager(List<IVisualizer> visualizers)
        {
            if (visualizers == null || visualizers.Count() < 1)
                throw new Exception();

            _visualizers = visualizers;
            _count = visualizers.Count();
            _index = 0;
        }

        internal void NextVisualizer()
        {
            _index = _index + 1 < _count ? _index + 1 : 0;
        }

        internal bool[,] RenderFrame(float[] fftData, int width, int height)
        {
            return _visualizers[_index].RenderFrame(fftData, width, height);
        }
    }
}
