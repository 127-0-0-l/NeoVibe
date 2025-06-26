using Microsoft.Extensions.DependencyInjection;
using NeoVibe.AudioProcessors;
using NeoVibe.Core;
using NeoVibe.Interfaces;
using NeoVibe.Visualisers;

namespace NeoVibe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAudioProcessor, NAudioPocessor>()
                .AddSingleton<IVisualizer, SpectrumVisualizer>()
                .AddSingleton<NeoVibeApp>()
                .BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<NeoVibeApp>();
            app.Run();
        }
    }
}
