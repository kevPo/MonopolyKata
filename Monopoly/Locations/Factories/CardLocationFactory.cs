using System.Linq;
using Monopoly.Actions;
using Monopoly.Cards;

namespace Monopoly.Locations.Factories
{
    public class CardLocationFactory : ICardLocationFactory
    {
        private IAction pickUpCardAction = new PickupCardAction(new CardDeck(Enumerable.Empty<ICard>()));

        public ILocation CreateChanceLocation(int locationIndex)
        {
            return new Location(locationIndex, pickUpCardAction, new NullAction());
        }

        public ILocation CreateCommunityChestLocation(int locationIndex)
        {
            return new Location(locationIndex, pickUpCardAction, new NullAction());
        }
    }
}
