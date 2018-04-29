using Sketchy.Managers;
using UnityEngine;

namespace Sketchy.Menu
{
    [RequireComponent(typeof(CoinsView))]
    public class CoinsController : MonoBehaviour
    {
        [Tooltip("Data for the total coins")]
        [SerializeField]
        private CoinsModel coinsModel;

        private CoinsView coinsView;

        private void Awake()
        {
            coinsView = GetComponent<CoinsView>();
        }

        private void Start()
        {
            coinsView.SetCoins(GameManager.CoinsManager.GetCoins());
            coinsView.SetLifetimeCoins(GameManager.CoinsManager.GetLifetimeCoins());
        }
    }
}