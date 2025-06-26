using NeoVibe.Interfaces;

namespace NeoVibe.AudioProcessors
{
    internal class NAudioPocessor : IAudioProcessor
    {
        float[] IAudioProcessor.GetFFT(int minFFTLength)
        {
            throw new NotImplementedException();
        }

        void IAudioProcessor.Pause()
        {
            throw new NotImplementedException();
        }

        void IAudioProcessor.Play()
        {
            throw new NotImplementedException();
        }

        void IAudioProcessor.Restart()
        {
            throw new NotImplementedException();
        }

        void IAudioProcessor.SetAudio(string filePath)
        {
            throw new NotImplementedException();
        }

        void IAudioProcessor.SetTime(int minutes, int secconds)
        {
            throw new NotImplementedException();
        }

        void IAudioProcessor.Stop()
        {
            throw new NotImplementedException();
        }
    }
}
