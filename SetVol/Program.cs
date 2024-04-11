using System;
using System.Threading.Tasks;

namespace SetVol;

internal static partial class Program
{
    private static async Task Main(string[] args)
    {
        if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Missing volume argument");
            Console.ResetColor();
            return;
        }

        bool isValidLevel = float.TryParse(args[0], out float level);
        if (isValidLevel && level > 0)
        {
            AudioManager.SetMasterVolume(level);
            Console.WriteLine(AudioManager.GetMasterVolume());
        }
    }
}