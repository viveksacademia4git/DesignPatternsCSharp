namespace IO;

public static class ConsoleExtensions
{
    public static void Print(this string str)
    {
        #if !DEBUG

        // For better print in Run-Mode
        Task.Delay(10);

        #endif

        Console.WriteLine(str);
    }
}