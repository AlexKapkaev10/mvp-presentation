using MessagePipe;
using Project.Game;
using Project.ScriptableObjects;
using Project.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scopes
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private BetPresenterConfig _betPresenterConfig;
        [SerializeField] private GamePresenterConfig _gamePresenterConfig;
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();

            builder.RegisterMessageBroker<ActiveMessage>(options);
            
            builder.RegisterEntryPoint<ViewService>()
                .As<IViewService>();
                
            builder.Register<GameModel>(Lifetime.Scoped)
                .As<IGameModel>();
            
            builder.Register<GamePresenter>(Lifetime.Scoped)
                .As<IGamePresenter>()
                .WithParameter(_gamePresenterConfig);
            
            builder.Register<BetModel>(Lifetime.Scoped)
                .As<IBetModel>();
            
            builder.Register<BetPresenter>(Lifetime.Scoped)
                .As<IBetPresenter>()
                .WithParameter(_betPresenterConfig);
        }
    }
}