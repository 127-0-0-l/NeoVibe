using NeoVibe.Constants;

namespace NeoVibe.Utils
{
    internal static class AudioUtils
    {
        internal static int GetFFTLength(int minLength)
        {
            int fftLength = 2;
            while (fftLength < minLength && fftLength < AudioConstants.MaxFFTLength)
                fftLength *= 2;
            return fftLength;
        }
    }
}
