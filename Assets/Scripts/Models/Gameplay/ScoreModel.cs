using System;
using UnityEngine;

namespace Sketchy.Gameplay
{
    [Serializable]
    public class ScoreModel
    {
        [Tooltip("Current score achieved by player")]
        [SerializeField]
        [Range(0.0f, 10000.0f)]
        private float score = 0.0f;

        /// <summary>
        /// Gets the user's current score
        /// </summary>
        /// <returns>Current score</returns>
        internal float GetScore()
        {
            return score;
        }

        /// <summary>
        /// Sets the user's current score
        /// </summary>
        /// <param name="score">Current score</param>
        internal void SetScore(float score)
        {
            this.score = score;
        }
    }
}