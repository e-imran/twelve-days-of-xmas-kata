using System.IO;

namespace TwelveDays.Tests
{
    public interface IIOHelper
    {
        void LogOutputToTextFile(string output);
    }

    public class IOHelper : IIOHelper
    {
        public const string OutputFilePath = @"C:\Users\ImranE\code\dotnet\twelve-days-of-xmas-kata\TwelveDays.Tests\OutputTest.txt";
        public void LogOutputToTextFile(string output)
        {
            File.WriteAllText(OutputFilePath, output);
        }
    }
}