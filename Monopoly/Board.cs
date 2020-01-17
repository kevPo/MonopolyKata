using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Board
    {
        public const int Go = 0;
        private const int NumberOfLocations = 40;

        public IEnumerable<int> Locations { get; private set; }

        private IDictionary<string, int> playerLocations;

        public Board()
        {
            Locations = Enumerable.Range(0, NumberOfLocations);
            playerLocations = new Dictionary<string, int>();
        }

        public int MovePlayer(string name, int locationsToMove)
        {
            if (!playerLocations.ContainsKey(name))
            {
                playerLocations[name] = 0;
            }

            return playerLocations[name] = CalculateNewLocation(playerLocations[name], locationsToMove);
        }

        private int CalculateNewLocation(int currentLocation, int locationsToMove)
        {
            return (currentLocation + locationsToMove) % NumberOfLocations;
        }
    }
}
