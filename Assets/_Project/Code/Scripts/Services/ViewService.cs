using Project.Game;
using UnityEngine;
using VContainer;

namespace Project.Services
{
    public class ViewService : IViewService
    {
        private readonly IGamePresenter _gamePresenter;
        private readonly IBetPresenter _betPresenter;

        [Inject]
        public ViewService(IGamePresenter gamePresenter, IBetPresenter betPresenter)
        {
            _gamePresenter = gamePresenter;
            _betPresenter = betPresenter;
        }
        
        public void Initialize()
        {
            _gamePresenter.SetActiveView(true);
            _betPresenter.SetActiveView(true);
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _gamePresenter.SetActiveView(false);
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                _gamePresenter.SetActiveView(true);
            }
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _betPresenter.SetActiveView(false);
            }
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                _betPresenter.SetActiveView(true);
            }
        }
    }
}