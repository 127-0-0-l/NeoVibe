using NAudio.Wave;

namespace NeoVibe.Extensions
{
    internal static class WaveOutEventExtension
    {
        internal static bool IsInitialized(this WaveOutEvent waveOutEvent)
        {
            try
            {
                var state = waveOutEvent.PlaybackState;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
