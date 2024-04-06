namespace schoolProject
{
    public class Wall
    {
        bool isUp {  get; set; }
        bool isDown { get; set; }
        bool isLeft { get; set; }
        bool isRight { get; set; }
        public Position? WallPosition { get; set; }

        public Wall()
        {

        }
         
    }  
}