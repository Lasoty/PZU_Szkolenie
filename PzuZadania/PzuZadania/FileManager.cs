using System;
using System.IO;

namespace PzuZadania
{
    internal class FileManager
    {
        internal void SaveToFile(string text)
        {
            File.WriteAllText("userText.txt", text);
        }

        internal string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}