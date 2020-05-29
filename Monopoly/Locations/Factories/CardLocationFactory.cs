using Monopoly.Actions;

namespace Monopoly.Locations.Factories
{
    public class CardLocationFactory : ICardLocationFactory
    {
        private readonly IAction chancePickupAction;
        private readonly IAction communityChestPickupAction;

        public CardLocationFactory(IDeckFactory deckFactory)
        {
            chancePickupAction = new PickupCardAction(deckFactory.CreateChanceDeck());
            communityChestPickupAction = new PickupCardAction(deckFactory.CreateCommunityChestDeck());
        }

        public ILocation CreateChanceLocation(int locationIndex)
        {
            return new Location(locationIndex, chancePickupAction, new NullAction());
        }

        public ILocation CreateCommunityChestLocation(int locationIndex)
        {
            return new Location(locationIndex, communityChestPickupAction, new NullAction());
        }
    }
}
