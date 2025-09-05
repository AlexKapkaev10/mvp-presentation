namespace Project.Game
{
    public class GameModel : IGameModel
    {
        public ActiveMessage ActiveMessage { get; private set; }
        public void SetMessage(ActiveMessage message)
        {
            ActiveMessage = message;
        }
    }
}