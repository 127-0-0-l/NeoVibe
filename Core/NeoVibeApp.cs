﻿using NeoVibe.AudioProcessors;
using NeoVibe.Interfaces;
using NeoVibe.Layout;
using NeoVibe.Visualisers;
using System.Diagnostics;

namespace NeoVibe.Core
{
    internal class NeoVibeApp
    {
        private static int _fps = 30;
        private static long _frequency = Stopwatch.Frequency;
        private static long _ticksPerFrame = _frequency / _fps;

        internal void Run()
        {
            // init viewports
            var visualizerViewport = new VisualizerViewport();
            Viewport[] viewports =
            {
                visualizerViewport
            };

            // init console
            ConsoleRenderer.Init(viewports);

            // init key listener
            KeyHandler.KeyListener += ConsoleRenderer.KeyPress;
            for(int i = 0; i < viewports.Length; i++)
                KeyHandler.KeyListener += viewports[i].KeyPress;
            var listener = new Thread(KeyHandler.Listen);
            listener.Start();

            // init visualizers
            VisualizerManager visualizerManager = new VisualizerManager(new List<IVisualizer>
            {
                //new SpectrumVisualizer(),
                new MatrixVisualizer()
            });

            NAudioPocessor.SetAudio(@"C:\Users\maks\Music\yt-music\Ivan B - Way Up.mp3");
            //Thread play = new Thread(NAudioPocessor.Play);
            //play.Start();
            NAudioPocessor.Play();

            // main loop
            Stopwatch frameTime = new Stopwatch();
            while (true)
            {
                frameTime.Start();

                float[] fft = NAudioPocessor.GetFFT(viewports[0].Width);
                bool[,] vFrame = visualizerManager.RenderFrame(fft, viewports[0].Width, viewports[0].Height);
                visualizerViewport.SetFrame(vFrame);
                ConsoleRenderer.RenderFrame();

                while(frameTime.ElapsedTicks < _ticksPerFrame) { }
                frameTime.Reset();
            }
        }
    }
}
