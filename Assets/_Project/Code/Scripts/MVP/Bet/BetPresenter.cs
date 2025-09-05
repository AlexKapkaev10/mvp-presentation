using Project.ScriptableObjects;
using UnityEngine;
using VContainer;

namespace Project.Game
{
    public class BetPresenter : IBetPresenter
    {
        private readonly IBetModel _model;
        private readonly BetPresenterConfig _config;
        
        private IBetView _view;

        [Inject]
        public BetPresenter(IBetModel model, BetPresenterConfig config)
        {
            _model = model;
            _config = config;
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
                    _view.ButtonUp.onClick.AddListener(OnButtonUp);
                    _view.ButtonDown.onClick.AddListener(OnButtonDown);
                    
                    UpdateView();
                    break;
                
                case false:
                    if (_view == null)
                    {
                        return;
                    }
                    
                    _view.ButtonUp.onClick.RemoveListener(OnButtonUp);
                    _view.ButtonDown.onClick.RemoveListener(OnButtonDown);
                    _view?.Destroy();
                    _view = null;
                    break;
            }
        }

        private void UpdateView()
        {
            _view?.UpdateText(_model.BetAmount.ToString());
        }

        private void OnButtonDown()
        {
            _model.UpdateBet(UpDownType.Down);
            
            UpdateView();
        }

        private void OnButtonUp()
        {
            _model.UpdateBet(UpDownType.Up);
            
            UpdateView();
        }
    }
}