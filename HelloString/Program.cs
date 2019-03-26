using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HelloString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] profileStrings = File.ReadAllLines("./profile.csv");

            List<Character> charList = new List<Character>();

            for(int i = 1; i < profileStrings.Length; i++)
            {
                Character savedCharacter = CreateCharacterFromText(profileStrings[i]);
                savedCharacter.LevelUp();
                charList.Add(savedCharacter);
            }

            SaveCharacter(charList[0]);
            SaveCharacter(charList[2]);

            //Character newCharacter = new Character("新玩家", 1, 1, 100, 200, 50, 25);
            Console.Read();
        }

        // 从一条字符串中提取角色参数，并生成一个角色实例
        static Character CreateCharacterFromText(string info)
        {
            string name;
            int job;
            int level;
            int hp;
            int mana;
            int atk;
            int def;

            string[] strings = info.Split(',');

            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(i + ":" + strings[i]);
            }

            name = strings[0];
            job = int.Parse(strings[1]);
            level = int.Parse(strings[2]);
            hp = int.Parse(strings[3]);
            mana = int.Parse(strings[4]);
            atk = int.Parse(strings[5]);
            def = int.Parse(strings[6]);

            Character character = new Character(name, job, level, hp, mana, atk, def);
            return character;
        }

        // 将一个角色实例的信息保存到存档文件
        static bool SaveCharacter(Character character)
        {
            try
            {
                string[] profileStrings = File.ReadAllLines("./profile.csv");

                string s = character.GetProfileString();

                for (int i = 1; i < profileStrings.Length; i++)
                {
                    // 如果存档文件里有某条记录是以现在要保存的角色的名字开头的，说明这个角色之前已经在存档里
                    if (profileStrings[i].StartsWith(character.GetName()))
                    {
                        profileStrings[i] = s;
                        File.WriteAllLines("./profile.csv", profileStrings);
                        return true;
                    }
                }

                File.AppendAllText("./profile.csv", s);
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine("不能打开存档文件，保存角色失败！");
                return false;
            }
        }
    }
}
