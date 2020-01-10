namespace Monopoly
{
    public class Player
    {
        public string Name { get; }
        public int Location { get; set; } 

        public Player(string name)
        {
            Name = name;
        }
    }
}
