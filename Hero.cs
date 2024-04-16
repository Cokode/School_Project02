using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    public class Hero
    {
        public int points { get; set; }
        public string name { get;}
        public Position heroPosition { get; set; }
        public Position? wallToBreak { get; set; } 
        private static Hero? HeroInstance { get; set; } 
        
        private Hero() {
            Random r = new Random();
            name = "Hero";
            int col = r.Next(0, 15);
            heroPosition = new(0, col);
            wallToBreak = null;
        }

        public static Hero InitializeHero()
        {
            HeroInstance ??= new Hero
            {
                points = 15
            };

            return HeroInstance;
        }
    }
}
