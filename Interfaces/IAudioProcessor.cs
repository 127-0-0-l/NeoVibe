namespace NeoVibe.Interfaces
{
    internal interface IAudioProcessor
    {
        void SetAudio(string filePath);

        void Play();

        void Pause();

        void Stop();

        void Restart();

        void SetTime(TimeSpan time);

        float[] GetFFT(int minFFTLength);
    }
}
