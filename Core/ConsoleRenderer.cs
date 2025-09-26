namespace NeoVibe.Core
{
    internal static class ConsoleRenderer
    {

        internal static void KeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.N:
                    //do smth;
                    break;
                default:
                    Console.Write(key.ToString());
                    return;
            }
        }
    }
}
