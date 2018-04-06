using Sketchy.Constants;
using UnityEngine;

namespace Sketchy.Managers
{
    public class ScoreManager
    {
        private float highScore;

        /// <summary>
        /// Creates a new Score Manager
        /// </summary>
        internal ScoreManager()
        {
            LoadHighScore();
        }

        /// <summary>
        /// Gets the high score
        /// </summary>
        /// <returns>Player's highest score</returns>
        internal float GetHighScore()
        {
            return highScore;
        }

        /// <summary>
        /// Tries to set the high score, and returns whether or not the score was high enough to be the new high score
        /// </summary>
        /// <param name="score">Score to set</param>
        /// <returns>Whether or not the score was a new high score</returns>
        internal bool SetHighScore(float score)
        {
            if (score > highScore)
            {
                highScore = score;
                SaveHighScore();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LoadHighScore()
        {
            highScore = PlayerPrefs.GetFloat(DataKeys.HighScore, 0.0f);
        }

        private void SaveHighScore()
        {
            PlayerPrefs.SetFloat(DataKeys.HighScore, highScore);
        }
    }
}