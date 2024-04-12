using System.Net.Security;
using System.Xml.Linq;

namespace schoolProject
{
    public class Queen
    {
        public int Points { get; }
        public Position queenPosition {get; }
        public bool queenIsCaptured { get; set; }

        public Queen()
        {
            Random r = new Random();
            int col = r.Next(0, 15);
            queenPosition = new(20, col);
            this.Points = 100;
            queenIsCaptured = false;
        }

    }
}