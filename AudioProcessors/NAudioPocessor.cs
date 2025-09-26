using NAudio.Dsp;
using NAudio.Wave;
using NeoVibe.Constants;
using NeoVibe.Core;
using NeoVibe.Extensions;
using NeoVibe.Interfaces;
using NeoVibe.Utils;

namespace NeoVibe.AudioProcessors
{
    internal class NAudioPocessor : IAudioProcessor
    {
        private AudioFileReader _audioFileReader;
        private WaveOutEvent _outputDevice = new WaveOutEvent();

        void IAudioProcessor.SetAudio(string filePath)
        {
            try
            {
                _audioFileReader = new AudioFileReader(filePath);
                _outputDevice.Init(_audioFileReader);
                _outputDevice.Play();
            }
            catch (Exception ex)
            {
                ErrorHandler.ShowError(ex.Message);
            }
        }

        void IAudioProcessor.SetTime(TimeSpan time)
        {
            ExecuteInitialized(() =>
            {
                _audioFileReader.CurrentTime = time;
            });
        }

        float[] IAudioProcessor.GetFFT(int minFFTLength)
        {
            // multiple by 2 becouse of fft array have two mirrored parts.
            // i take only one of them (fftLength/2 items)
            int FFTLength = AudioUtils.GetFFTLength(minFFTLength) * 2;

            if (_outputDevice.PlaybackState != PlaybackState.Playing || !_outputDevice.IsInitialized())
            {
                ErrorHandler.ShowError(ErrorMessage.OutputDeviceNotInit);
                return new float[FFTLength / 2];
            }

            float[] readBuffer = new float[FFTLength];
            var complexBuffer = new Complex[FFTLength];

            int samplesRead = _audioFileReader.Read(readBuffer, 0, FFTLength);
            if (samplesRead == 0)
                return new float[FFTLength / 2];

            for (int i = 0; i < FFTLength; i++)
            {
                complexBuffer[i].X = (float)(readBuffer[i] * FastFourierTransform.HammingWindow(i, FFTLength));
                complexBuffer[i].Y = 0;
            }

            FastFourierTransform.FFT(true, (int)Math.Log(FFTLength, 2), complexBuffer);

            float[] result = new float[FFTLength / 2];
            // get values using Pythagorean Theorem
            for (int i = 0; i < FFTLength / 2; i++)
                result[i] = (float)Math.Sqrt(complexBuffer[i].X * complexBuffer[i].X + complexBuffer[i].Y * complexBuffer[i].Y);

            return result;
        }

        void IAudioProcessor.Play() => ExecuteInitialized(_outputDevice.Play);

        void IAudioProcessor.Pause() => ExecuteInitialized(_outputDevice.Pause);

        void IAudioProcessor.Stop() => ExecuteInitialized(_outputDevice.Stop);

        void IAudioProcessor.Restart()
        {
            ExecuteInitialized(() =>
            {
                _outputDevice.Stop();
                _audioFileReader.Position = 0;
                _outputDevice.Play();
            });
        }

        private void ExecuteInitialized(Action action)
        {
            if (_outputDevice.IsInitialized())
                action();
            else
                ErrorHandler.ShowError(ErrorMessage.OutputDeviceNotInit);
        }

    }
}
