using Sketchy.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Sketchy.Gameplay
{
    [RequireComponent(typeof(ScoreView))]
    public class ScoreController : MonoBehaviour
    {
        /// <summary>
        /// Event called when the game is over with the score achieved
        /// </summary>
        internal static UnityAction<float> OnScoreEarned;

        [Tooltip("Data for the score")]
        [SerializeField]
        private ScoreModel scoreModel;

        [Tooltip("Score value for 1 unit of level progression")]
        [SerializeField]
        [Range(0.0f, 10.0f)]
        private float scorePerLevelProgression = 1.0f;

        private ScoreView scoreView;

        private void Awake()
        {
            scoreView = GetComponent<ScoreView>();
        }

        private void OnEnable()
        {
            Level.OnLevelProgressed += ProgressLevel;
            Collectable.OnCollected += CollectCollectable;
            GameplayManager.OnGameStarted += StartGame;
            GameplayManager.OnGameOver += GameOver;
        }

        private void Start()
        {
            scoreView.ShowScoreboard(false);
        }

        private void OnDisable()
        {
            Level.OnLevelProgressed -= ProgressLevel;
            Collectable.OnCollected -= CollectCollectable;
            GameplayManager.OnGameStarted -= StartGame;
            GameplayManager.OnGameOver -= GameOver;
        }

        private void ProgressLevel(float progression)
        {
            float scoreIncrease = progression * scorePerLevelProgression;
            scoreModel.SetScore(scoreModel.GetScore() + scoreIncrease);
            scoreView.SetScore(scoreModel.GetScore());
        }

        private void CollectCollectable(Collectable collectable)
        {
            scoreModel.SetScore(scoreModel.GetScore() + collectable.GetScoreCollected());
            scoreView.SetScore(scoreModel.GetScore());
        }

        private void StartGame()
        {
            scoreView.ShowScoreboard(true);
        }

        private void GameOver()
        {
            scoreView.ShowScoreboard(false);
            if (OnScoreEarned != null)
            {
                OnScoreEarned(scoreModel.GetScore());
            }
        }
    }
}