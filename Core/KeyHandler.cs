namespace NeoVibe.Core
{
    internal static class KeyHandler
    {
        internal delegate void Handler (ConsoleKey key);
        internal static event Handler KeyListener;

        internal static void Listen()
        {
            while(true)
                KeyListener?.Invoke(Console.ReadKey(true).Key);
        }
    }
}
