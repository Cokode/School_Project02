using System.Net.Security;

namespace schoolProject
{
    public class Queen
    {
        public Position queenPosition {get; }
        public int Points {get; }

        public Queen()
        {
            this.queenPosition = new(17,8);
            this.Points = 100;
        }

    }
}