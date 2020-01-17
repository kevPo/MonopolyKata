namespace Monopoly
{
    public class Turn
    {
        public int TurnOrder { get; private set; }
        public Player Player { get; private set; }

        public Turn(int turnOrder, Player player)
        {
            TurnOrder = turnOrder;
            Player = player;
        }
    }
}
