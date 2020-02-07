﻿namespace Monopoly.Locations
{
    public class NullLocation : ILocation
    {
        public NullLocation(int locationIndex)
        {
            LocationIndex = locationIndex;
            Cost = 0;
        }

        public int LocationIndex { get; }
        public int Cost { get; }
        public IPlayer Owner { get; set; }

        public void ProcessLandingAction(IPlayer player)
        {
        }

        public void ProcessPassingAction(IPlayer player)
        {
        }
    }
}
