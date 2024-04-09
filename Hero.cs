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
       // public Direction HeroDirection { get; set; } // may be redundant, remove 
        private static Hero? HeroInstance { get; set; } 
        
        private Hero() {
            this.name = "Hero";
            heroPosition = new(0, 0);
        }

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
