using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] english = new string[] { "sun", "moon", "earth" };
            string[] chinese = new string[] { "太阳", "月亮", "地球" };

            Dictionary<Human, bool> isCnDict = new Dictionary<Human, bool>();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            Human cn = new Human("WAWA", 14);
            Human us = new Human("BABY", 6);

            isCnDict.Add(cn, true);
            isCnDict.Add(us, false);

            dict.Add("sun", "太阳");
            dict.Add("moon", "月亮");
            dict.Add("earth", "地球");

            foreach( bool b in isCnDict.Values )
            {
                Console.WriteLine("CN:" + b);
            }

            string enword = "moon";
            string cnword = CheckDictionary(enword, english, chinese);

            Console.WriteLine(enword + " is " + cnword + " in Chinese.");

            Console.WriteLine(dict["sun"]);
            Console.WriteLine(dict["moon"]);
            Console.WriteLine(dict["earth"]);

            Console.ReadKey();
        }

        static string CheckDictionary(string word, string[] english, string[] chinese)
        {
            int wordIndex = -1;

            for(int i = 0; i < english.Length; i++)
            {
                if(word == english[i])
                {
                    wordIndex = i;
                    break;
                }
            }

            if(wordIndex == -1)
            {
                return null;
            }
            else
            {
                return chinese[wordIndex];
            }
        }
    }
}
