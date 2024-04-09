namespace schoolProject
{
    public class Wall
    {
        public char wallType {  get; set; }
        public bool isAWall { get; set; }
        public Position? WallPosition { get; set; }

        public Wall()
        {
        }

        public Wall(char wallType, bool isAWall, Position position)
        {
            this.wallType = wallType;
            this.isAWall = isAWall;
            this.WallPosition = position;
        }
         
    }  
}