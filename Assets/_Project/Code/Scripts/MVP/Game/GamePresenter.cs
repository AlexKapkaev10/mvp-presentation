using System;
using MessagePipe;
using Project.ScriptableObjects;
using VContainer;
using Object = UnityEngine.Object;

namespace Project.Game
{
    public class GamePresenter : IGamePresenter
    {
        private readonly IGameModel _model;
        private readonly IDisposable _disposable;
        
        private readonly GamePresenterConfig _config;
        
        private IGameView _view;

        [Inject]
        public GamePresenter(IGameModel model, ISubscriber<ActiveMessage> activeMessageSubscriber, GamePresenterConfig config)
        {
            _model = model;
            _config = config;
            
            var bag = DisposableBag.CreateBuilder();
            
            activeMessageSubscriber.Subscribe(OnActiveMessage).AddTo(bag);
            _disposable = bag.Build();
        }

        public void SetActiveView(bool isActive)
        {
            switch (isActive)
            {
                case true:
                    if (_view != null)
                    {
                        return;
                    }
                    
                    _view = Object.Instantiate(_config.ViewPrefab, null);
                    _view.PlayButton.interactable = _model.ActiveMessage.IsActive;
                    break;
                case false:
                    if (_view == null)
                    {
                        return;
                    }
                    _view?.Destroy();
                    _view = null;
                    break;
            }
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }

        private void OnActiveMessage(ActiveMessage message)
        {
            _model.SetMessage(message);
            
            if (_view != null)
            {
                _view.PlayButton.interactable = _model.ActiveMessage.IsActive;
            }
        }
    }
}