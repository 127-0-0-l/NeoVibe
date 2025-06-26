using NeoVibe.Core;

namespace NeoVibe.Utils
{
    internal static class AudioUtils
    {
        internal static int GetFFTLength(int minLength)
        {
            int fftLength = 2;
            while (fftLength < minLength && fftLength < Constants.MaxFFTLength)
                fftLength *= 2;
            return fftLength;
        }
    }
}
