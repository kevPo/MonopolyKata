namespace Monopoly
{
    public interface IBailAdvisor
    {
        bool PlayerShouldPayBail(IPlayer player);
    }
}
