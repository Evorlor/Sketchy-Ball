using Sketchy.Gameplay;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Sketchy.Managers
{
    public class GameplayManager : MonoBehaviour
    {
        /// <summary>
        /// Event called when the game starts
        /// </summary>
        internal static UnityAction OnGameStarted;

        /// <summary>
        /// Event called when the game is over.  This means the player lost, but the game over sequence is still occuring.
        /// </summary>
        internal static UnityAction OnGameOver;

        /// <summary>
        /// Event called when the game has finished.  This will be called after the game over sequence ends.
        /// </summary>
        internal static UnityAction OnGameFinished;

        [Tooltip("The instructions displayed before the user draws their first line")]
        [SerializeField]
        private GameObject instructions;

        [Tooltip("Level which contains all of the gameplay contents")]
        [SerializeField]
        private Level level;

        [Tooltip("Line drawer which allowed the player to draw lines")]
        [SerializeField]
        private LineDrawer lineDrawer;

        private bool gameStarted = false;

        private void OnEnable()
        {
            LineDrawer.OnLineDrawn += StartGame;
            PlayerController.OnPlayerDied += GameOver;
            ScoreController.OnScoreEarned += EarnScore;
            CoinsController.OnCoinsEarned += EarnCoins;
        }

        private void Start()
        {
            Time.timeScale = 0.0f;
        }

        private void OnDisable()
        {
            LineDrawer.OnLineDrawn -= StartGame;
            PlayerController.OnPlayerDied -= GameOver;
            ScoreController.OnScoreEarned -= EarnScore;
            CoinsController.OnCoinsEarned -= EarnCoins;
        }

        private void StartGame()
        {
            if (gameStarted)
            {
                return;
            }
            gameStarted = true;
            if (OnGameStarted != null)
            {
                OnGameStarted();
            }
            Destroy(instructions);
            Time.timeScale = 1.0f;
        }

        private void GameOver()
        {
            if (OnGameOver != null)
            {
                OnGameOver();
            }
            StartCoroutine(FinishGame());
        }

        private IEnumerator FinishGame()
        {
            Destroy(lineDrawer);
            if (level)
            {
                foreach (var spawner in level.GetComponents<Spawner>())
                {
                    Destroy(spawner);
                }
            }
            yield return new WaitUntil(IsGameFinished);
            if (OnGameFinished != null)
            {
                OnGameFinished();
            }
        }

        private bool IsGameFinished()
        {
            if (!level)
            {
                return true;
            }
            bool levelCleared = level.transform.childCount == 0;
            return levelCleared;
        }

        private void EarnScore(float score)
        {
            if (GameManager.ScoreManager != null)
            {
                GameManager.ScoreManager.SetHighScore(score);
            }
        }

        private void EarnCoins(float coins)
        {
            if (GameManager.CoinsManager != null)
            {
                GameManager.CoinsManager.SetCoins(GameManager.CoinsManager.GetCoins() + coins);
                GameManager.CoinsManager.SetLifetimeCoins(GameManager.CoinsManager.GetLifetimeCoins() + coins);
            }
        }
    }
}