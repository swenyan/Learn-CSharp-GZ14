using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Link", 100, 0, 0);
            UI ui = new UI(player);

            player.Init();
        }
    }
}
