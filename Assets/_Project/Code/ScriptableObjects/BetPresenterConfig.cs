using Project.Game;
using UnityEngine;

namespace Project.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(BetPresenterConfig), menuName = "Config/MVP/Bet Presenter")]
    public class BetPresenterConfig : ScriptableObject
    {
        [field: SerializeField] public BetView ViewPrefab { get; private set; }
    }
}