using System.Collections.ObjectModel;

namespace NeoVibe.Constants
{
    internal static class ErrorMessage
    {
        internal static readonly string OutputDeviceNotInit = nameof(OutputDeviceNotInit);
        internal static readonly string VisualizerNotFound = nameof(VisualizerNotFound);

        private static readonly ReadOnlyDictionary<string, string> _errorMessages =
            new ReadOnlyDictionary<string, string>(
                new Dictionary<string, string>
                {
                    { OutputDeviceNotInit, "output device not initialized" },
                    { VisualizerNotFound, "visualizer not found" }
                }
            );

        internal static string GetErrorMessage(string errorCode)
        {
            return _errorMessages.TryGetValue(errorCode, out string message)
                ? message : $"unknown error: {errorCode}";
        }
    }
}
