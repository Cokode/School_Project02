using System.Net.Security;
using System.Xml.Linq;

namespace schoolProject
{
    public class Queen
    {
        public Position queenPosition {get; }
        public int Points {get; }

        public Queen()
        {
            Random r = new Random();
            int col = r.Next(0, 15);
            queenPosition = new(21, col);
            this.Points = 100;
        }

    }
}