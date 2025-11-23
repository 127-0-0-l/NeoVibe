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
			if (minFFTLength > 1024)
				return new float[minFFTLength];
			
            float[] fft = new float[1024];
            Bass.BASS_ChannelGetData(_streamId, fft, (int)BASSData.BASS_DATA_FFT2048);
            return fft;
        }

        void IAudioProcessor.Pause()
        {
            if (Bass.BASS_ChannelIsActive(_streamId) == BASSActive.BASS_ACTIVE_PLAYING)
                Bass.BASS_ChannelPause(_streamId);
        }

        void IAudioProcessor.Play()
        {
            if (Bass.BASS_ChannelIsActive(_streamId) == BASSActive.BASS_ACTIVE_PAUSED)
                Bass.BASS_ChannelPlay(_streamId, false);
        }

        void IAudioProcessor.Restart()
        {
            throw new NotImplementedException();
        }

        void IAudioProcessor.SetAudio(string filePath)
        {
            if (_streamId != 0) Bass.BASS_StreamFree(_streamId);
            _streamId = Bass.BASS_StreamCreateFile(filePath, 0, 0, BASSFlag.BASS_DEFAULT);
            if (_streamId != 0) Bass.BASS_ChannelPlay(_streamId, false);
            else throw new Exception("file not found");
        }

        void IAudioProcessor.SetTime(TimeSpan time)
        {
            Bass.BASS_ChannelSetPosition(_streamId, time.Seconds);
            //int time = (int)Bass.BASS_ChannelBytes2Seconds(_streamId, Bass.BASS_ChannelGetPosition(_streamId));
        }

        void IAudioProcessor.Stop()
        {
            throw new NotImplementedException();
        }
    }
}
