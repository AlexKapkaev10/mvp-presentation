using MessagePipe;
using VContainer;

namespace Project.Game
{
    public class BetModel : IBetModel
    {
        private readonly IPublisher<ActiveMessage> _activeMessagePublisher;
        private const int Min = 0;
        private const int Max = 10;
        private bool _isActive;
        
        public int BetAmount { get; private set; } = Min;

        [Inject]
        public BetModel(IPublisher<ActiveMessage> activeMessagePublisher)
        {
            _activeMessagePublisher  = activeMessagePublisher;
            _isActive = true;
            CheckActive();
        }

        public void UpdateBet(UpDownType type)
        {
            switch (type)
            {
                case UpDownType.Up:
                    if (BetAmount + 1 > Max) 
                        return;
                    
                    BetAmount++;
                    break;

                case UpDownType.Down:
                    if (BetAmount - 1 < Min) 
                        return;
                    
                    BetAmount--;
                    break;
            }


            CheckActive();
        }

        private void CheckActive()
        {
            bool isActive = BetAmount > 0;
            
            if (isActive != _isActive)
            {
                _isActive = isActive;
                
                _activeMessagePublisher.Publish(new ActiveMessage(isActive));
            }
        }
    }
}