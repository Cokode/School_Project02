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

        public Wall(bool isAWall, Position position,char wallType)
        {
            this.wallType = wallType;
            this.isAWall = isAWall;
            this.WallPosition = position;
        }
         
    }  
}