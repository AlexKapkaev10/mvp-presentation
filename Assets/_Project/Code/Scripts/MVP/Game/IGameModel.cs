
namespace Project.Game
{
    public interface IGameModel
    {
        ActiveMessage ActiveMessage { get; }
        void SetMessage(ActiveMessage message);
    }
}