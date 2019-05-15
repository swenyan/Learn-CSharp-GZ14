using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HelloFile
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteFileWithFileClass();
            //WriteFileWithFileStreamClass();
        }
        
        private static void ReadFileWithFileStreamClass()
        {
            byte[] buffer = new byte[1024];

            FileStream fs = new FileStream("./map.txt", FileMode.Open, FileAccess.Read, FileShare.None, 1024);

            fs.Read(buffer, 0, (int)fs.Length);
            for (int i = 0; i < fs.Length; i++)
            {
                Console.Write((char)buffer[i]);
            }

            Console.Write('\n');

            fs.Close();
        }

        private static void WriteFileWithFileStreamClass()
        {
            string line = Console.ReadLine();

            byte[] lineBuffer = new byte[line.Length];

            for(int i = 0; i < line.Length; i++)
            {
                char[] lineCharArray = line.ToCharArray();
                lineBuffer[i] = (byte)lineCharArray[i];
            }

            FileStream fs = new FileStream("./new.txt", FileMode.Create, FileAccess.Write, FileShare.None, 1024);
            fs.Write(lineBuffer, 0, line.Length);
            fs.Close();
        }

        private static void ReadFileWithFileClass()
        {
            byte[] helloBuffer = File.ReadAllBytes("./hello.txt");

            for (int i = 0; i < helloBuffer.Length; i++)
            {
                Console.Write((char)helloBuffer[i]);
            }

            Console.Write('\n');

            string homeworkString = File.ReadAllText("./homework.txt");
            Console.Write(homeworkString);

            string[] homeworkLines = File.ReadAllLines("./homework.txt");

            Console.WriteLine("按任意键开始打印");

            for (int i = 0; i < homeworkLines.Length; i++)
            {
                Console.ReadKey(true);
                Console.WriteLine(homeworkLines[i]);
            }
        }

        private static void WriteFileWithFileClass()
        {
            Console.WriteLine("写首诗吧：");

            List<string> lines = new List<string>();

            bool isWriting = true;

            while(isWriting)
            {
                string newLine = Console.ReadLine();
                if(newLine != "")
                {
                    lines.Add(newLine);
                }
                else
                {
                    isWriting = false;
                }
            }

            File.WriteAllLines("./newfile.txt", lines.ToArray());
        }
    }
}
