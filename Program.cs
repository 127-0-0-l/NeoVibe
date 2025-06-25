using NAudio.Dsp;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace NeoVibe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const int FFTLength = 256;
                var complexBuffer = new Complex[FFTLength];

                var audioFile = new AudioFileReader(@"C:\Users\maks\Downloads\Careless Whisper George Michael.mp3");
                var provider = audioFile.ToSampleProvider();

                var bufferedProvider = new SampleToWaveProvider(provider);
                var outputDevice = new WaveOutEvent();
                outputDevice.Init(bufferedProvider);
                outputDevice.Play();

                float[] readBuffer = new float[FFTLength];

                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    int samplesRead = provider.Read(readBuffer, 0, FFTLength);
                    if (samplesRead == 0) break;

                    for (int i = 0; i < FFTLength; i++)
                    {
                        complexBuffer[i].X = (float)(readBuffer[i] * FastFourierTransform.HammingWindow(i, FFTLength));
                        complexBuffer[i].Y = 0;
                    }

                    FastFourierTransform.FFT(true, (int)Math.Log(FFTLength, 2), complexBuffer);

                    for (int i = 0; i < FFTLength / 2; i++)
                    {
                        float magnitude = (float)Math.Sqrt(complexBuffer[i].X * complexBuffer[i].X + complexBuffer[i].Y * complexBuffer[i].Y);
                        Console.WriteLine(magnitude);
                    }
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
