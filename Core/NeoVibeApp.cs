using NeoVibe.Interfaces;
using NeoVibe.Visualisers;

namespace NeoVibe.Core
{
    internal class NeoVibeApp
    {
        internal void Run()
        {
            // init console


            // init key listener
            KeyHandler.KeyListener += ConsoleRenderer.KeyPress;
            var listener = new Thread(KeyHandler.Listen);
            listener.Start();

            // init visualizers
            VisualizerManager visualizerManager = new VisualizerManager(new List<IVisualizer>
            {
                new SpectrumVisualizer(),
                new MatrixVisualizer()
            });
        }

        internal void f()
        {

        }
    }
}
