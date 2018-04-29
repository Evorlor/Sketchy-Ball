using Sketchy.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Sketchy.Gameplay
{
    [RequireComponent(typeof(CoinsView))]
    public class CoinsController : MonoBehaviour
    {
        /// <summary>
        /// Event called when the game is over with the coins gained
        /// </summary>
        internal static UnityAction<float> OnCoinsEarned;

        [Tooltip("Data for the score")]
        [SerializeField]
        private CoinsModel coinsModel;

        private CoinsView coinsView;

        private void Awake()
        {
            coinsView = GetComponent<CoinsView>();
        }

        private void OnEnable()
        {
            Collectable.OnCollected += CollectCollectable;
            GameplayManager.OnGameStarted += StartGame;
            GameplayManager.OnGameOver += GameOver;
        }

        private void Start()
        {
            coinsView.ShowCoinboard(false);
        }

        private void OnDisable()
        {
            Collectable.OnCollected -= CollectCollectable;
            GameplayManager.OnGameStarted -= StartGame;
            GameplayManager.OnGameOver -= GameOver;
        }

        private void CollectCollectable(Collectable collectable)
        {
            coinsModel.SetCoins(coinsModel.GetCoins() + collectable.GetCoinsCollected());
            coinsView.SetCoins(coinsModel.GetCoins());
        }

        private void StartGame()
        {
            coinsView.ShowCoinboard(true);
        }

        private void GameOver()
        {
            coinsView.ShowCoinboard(false);
            if (OnCoinsEarned != null)
            {
                OnCoinsEarned(coinsModel.GetCoins());
            }
        }
    }
}