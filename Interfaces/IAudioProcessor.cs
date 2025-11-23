namespace NeoVibe.Interfaces
{
    internal interface IAudioProcessor
    {
        void SetAudio(string filePath);

        void SetTime(TimeSpan time);

        float[] GetFFT(int minFFTLength);

        void Play();

        void Pause();

        void Stop();

        void Restart();
    }
}
