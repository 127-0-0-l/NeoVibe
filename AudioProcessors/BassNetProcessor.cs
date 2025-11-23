using NeoVibe.Interfaces;
using Un4seen.Bass;

namespace NeoVibe.AudioProcessors
{
    internal class BassNetProcessor : IAudioProcessor
    {
        private int _streamId;

        public BassNetProcessor()
        {
            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
        }

        float[] IAudioProcessor.GetFFT(int minFFTLength)
        {
            float[] fft = new float[1024];
            Bass.BASS_ChannelGetData(_streamId, fft, (int)BASSData.BASS_DATA_FFT2048);
            return fft;
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

        void IAudioProcessor.SetTime(TimeSpan time)
        {
            throw new NotImplementedException();
        }

        void IAudioProcessor.Stop()
        {
            throw new NotImplementedException();
        }
    }
}
