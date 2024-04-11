using NAudio.CoreAudioApi;

namespace SetVol;

internal static class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Missing volume argument");
            Console.ResetColor();
            return;
        }

        bool isValidLevel = float.TryParse(args[0], out float level);
        if (isValidLevel && level > -1)
        {
            MMDeviceEnumerator deviceEnumerator = new();
            MMDevice device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            // Volume between 0 and 1 where 1 is max volume
            device.AudioEndpointVolume.MasterVolumeLevelScalar = level / 100;
        }
    }
}