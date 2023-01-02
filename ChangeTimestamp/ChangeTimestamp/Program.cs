using System;
using System.IO;

namespace ChangeTimestamp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ChangeTimestamp filepath timestamp");
                return;
            }

            string filePath = args[0];
            DateTime timestamp = DateTime.Parse(args[1] + " " + args[2]);

            byte[] fileData;
            using (FileStream stream = File.OpenRead(filePath))
            {
                fileData = new byte[stream.Length];
                stream.Read(fileData, 0, fileData.Length);
            }

            int peHeaderOffset = BitConverter.ToInt32(fileData, 0x3C);
            int timestampOffset = peHeaderOffset + 8;
            int timestampValue = (int)(timestamp.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
            byte[] timestampBytes = BitConverter.GetBytes(timestampValue);

            fileData[timestampOffset + 0] = timestampBytes[0];
            fileData[timestampOffset + 1] = timestampBytes[1];
            fileData[timestampOffset + 2] = timestampBytes[2];
            fileData[timestampOffset + 3] = timestampBytes[3];

            using (FileStream stream = File.OpenWrite(filePath))
            {
                stream.Write(fileData, 0, fileData.Length);
            }
            File.SetCreationTime(filePath, timestamp);
            File.SetLastWriteTime(filePath, timestamp);
            File.SetLastAccessTime(filePath, timestamp);

            DateTime creationTime = File.GetCreationTime(filePath);
            DateTime lastWriteTime = File.GetLastWriteTime(filePath);
            DateTime lastAccessTime = File.GetLastAccessTime(filePath);

            Console.WriteLine("Change file timestamp successfully.");
            Console.WriteLine("Compilation time: " + timestamp);
            Console.WriteLine("Creation time: " + creationTime);
            Console.WriteLine("Last write time: " + lastWriteTime);
            Console.WriteLine("Last access time: " + lastAccessTime);
        }
    }
}