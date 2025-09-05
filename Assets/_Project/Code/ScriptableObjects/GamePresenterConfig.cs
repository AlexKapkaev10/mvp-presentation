using Project.Game;
using UnityEngine;

namespace Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(GamePresenterConfig), menuName = "Config/MVP/Game Presenter")]
    public class GamePresenterConfig : ScriptableObject
    {
        [field: SerializeField] public GameView ViewPrefab { get; private set; }
    }
}