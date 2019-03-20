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
            byte[] buffer = new byte[1024];
            FileStream fs = new FileStream("./hello.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024);
            
            for(int i = 0; i < fs.Length; i++)
            {
                buffer[i] = (byte)fs.ReadByte();
                Console.Write('.');
            }

            Console.Write('\n');
            Console.WriteLine("读取完成");

            for (int i = 0; i < fs.Length; i++)
            {
                Console.Write((char)buffer[i]);
            }

            Console.Write('\n');

            fs.Close();

            fs = new FileStream("./map.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1024);

            fs.Read(buffer, 0, (int)fs.Length);

            for (int i = 0; i < fs.Length; i++)
            {
                Console.Write((char)buffer[i]);
            }

            Console.ReadKey(true);
        }
    }
}
