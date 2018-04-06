using System;
using UnityEngine;

namespace Sketchy.Gameplay
{
    [Serializable]
    public class CoinsModel
    {
        [Tooltip("Current coins achieved by player")]
        [SerializeField]
        [Range(0.0f, 10000.0f)]
        private float coins = 0.0f;

        /// <summary>
        /// Gets the user's current coin count
        /// </summary>
        /// <returns>Current number of coins</returns>
        internal float GetCoins()
        {
            return coins;
        }

        /// <summary>
        /// Sets the user's current coin count
        /// </summary>
        /// <param name="coins">Current number of coins</param>
        internal void SetCoins(float coins)
        {
            this.coins = coins;
        }
    }
}