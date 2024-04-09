using System.Net.Security;

namespace schoolProject
{
    public class Queen
    {
        public Position queenPosition {get; }
        public int Points {get; }

        public Queen()
        {
            this.queenPosition = new(21,14);
            this.Points = 100;
        }

    }
}