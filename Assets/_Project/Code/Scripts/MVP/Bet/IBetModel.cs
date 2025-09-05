namespace Project.Game
{
    public interface IBetModel
    {
        int BetAmount { get; }
        void UpdateBet(UpDownType type);
    }
}