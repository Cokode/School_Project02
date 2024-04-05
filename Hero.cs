using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    internal class Hero
    {
        public int points { get; set; }
        public string name { get; set; }
        public Position heroPosition { get; set; } = new(0, 0);
        private static Hero? HeroInstance { get; set; } 
        
        public Hero() { }

        public static Hero InitializeHero()
        {
            HeroInstance ??= new Hero
            {
                points = 0
            };

            return HeroInstance;
        }
    }
}
