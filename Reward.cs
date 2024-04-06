namespace schoolProject
{
    public class Reward
    {
        public Position rewardPosition { get; set; }
        public int points { get; set; }

        public Reward(Position rewardPosition, int points) 
        {
            this.rewardPosition = rewardPosition;
            this.points = points;
        }
    }
}