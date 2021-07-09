using System;
using System.IO;
using System.Text;

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