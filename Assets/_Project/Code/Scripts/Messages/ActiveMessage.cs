namespace Project.Game
{
    public readonly struct ActiveMessage
    {
        public readonly bool IsActive;

        public ActiveMessage(bool isActive)
        {
            IsActive = isActive;
        }
    }
}