namespace NeoVibe.Interfaces
{
    internal interface IAudioProcessor
    {
        void SetAudio(string filePath);

        void Play();

        void Pause();

        void Stop();

        void Restart();

        void SetTime(int minutes, int secconds);

        float[] GetFFT(int minFFTLength);
    }
}
