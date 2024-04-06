using System.Net.Security;

namespace schoolProject
{
    public class Queen
    {
        public Position queenPosition;
        public int points;

        public Queen(Position queenPosition, int points)
        {
            this.queenPosition = queenPosition;
            this.points = points;
        }

        public override string ToString()
        {
            return queenPosition.ToString();
        } // from the window 

        
    }
}