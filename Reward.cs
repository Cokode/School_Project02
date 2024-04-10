namespace schoolProject
{
    public class Reward
    {
        public Position rewardPosition { get; set; }
        public int points { get; set; }
        public bool isHaveReward { get; set; }

        public Reward(Position rewardPosition, int points, bool isHaveReward) 
        {
            this.rewardPosition = rewardPosition;
            this.points = points;
            this.isHaveReward = isHaveReward;
        }
    }
}