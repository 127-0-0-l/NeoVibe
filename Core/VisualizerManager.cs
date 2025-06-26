using NeoVibe.Interfaces;

namespace NeoVibe.Core
{
    internal class VisualizerManager
    {
        private readonly Dictionary<string, IVisualizer> visualizers;
        private IVisualizer current;

        internal VisualizerManager(IEnumerable<IVisualizer> availableVisualizers)
        {
            visualizers = availableVisualizers.ToDictionary(v => v.GetType().Name.ToLower());
            current = visualizers.Values.First();
        }

        internal void SetVisualizer(string name)
        {
            if (visualizers.TryGetValue(name.ToLower(), out var visualizer))
            {
                current = visualizer;
            }
            else
            {
                // show error
            }
        }
    }
}
