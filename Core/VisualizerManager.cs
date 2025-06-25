using NeoVibe.Interfaces;

namespace NeoVibe.Core
{
    internal class VisualizerManager
    {
        private readonly Dictionary<string, IVisualizer> visualizers;
        private IVisualizer current;

        public VisualizerManager(IEnumerable<IVisualizer> availableVisualizers)
        {
            visualizers = availableVisualizers.ToDictionary(v => v.GetType().Name.ToLower());
            current = visualizers.Values.First();
        }

        public void SetVisualizer(string name)
        {
            if (visualizers.TryGetValue(name.ToLower(), out var visualizer))
            {
                current = visualizer;
                Console.WriteLine($"Визуализатор переключен на: {name}");
            }
            else
            {
                Console.WriteLine($"Визуализатор '{name}' не найден.");
            }
        }
    }
}
