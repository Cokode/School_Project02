namespace schoolProject
{
    public class Wall
    {
        public bool isUp {  get; set; }
        public bool isDown { get; set; }
        public bool isLeft { get; set; }
        public bool isRight { get; set; }
        public Position? WallPosition { get; set; }

        public Wall()
        {
            isUp = false;
            isDown = false;
            isLeft = false;
            isRight = false;
            WallPosition = null;
        }

        public Wall(bool isUp,bool isDown, bool isLeft, bool isRight, Position position)
        {
            this.isUp = isUp;
            this.isDown = isDown;
            this.isLeft = isLeft;
            this.isRight = isRight;
            this.WallPosition = position;
        }
         
    }  
}