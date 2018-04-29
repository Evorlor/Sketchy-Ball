using System;
using UnityEngine;

namespace Sketchy.Menu
{
    [Serializable]
    public class CoinsModel
    {
        [Tooltip("Total coins that the user currently has")]
        [SerializeField]
        [Range(0.0f, 1000.0f)]
        private float coins = 0.0f;

        [Tooltip("Lifetime coins the the user has cumulatively gained")]
        [SerializeField]
        [Range(0.0f, 100000.0f)]
        private float lifetimeCoins = 0.0f;

        /// <summary>
        /// Gets the number of coins the user currently has
        /// </summary>
        /// <returns>The number of coins the user currently has</returns>
        internal float GetCoins()
        {
            return coins;
        }

        /// <summary>
        /// Sets the number of coins the user currently has
        /// </summary>
        /// <param name="coins">Number of coins the user currently has</param>
        internal void SetCoins(float coins)
        {
            this.coins = coins;
        }

        /// <summary>
        /// Gets the number of coins the user has earned ever
        /// </summary>
        /// <returns>Lifetime number of coins earned</returns>
        internal float GetLifetimeCoins()
        {
            return lifetimeCoins;
        }

        /// <summary>
        /// Sets the cumulative number of coins the user has ever achieved
        /// </summary>
        /// <param name="lifetimeCoins">Number of coins user has achieved ever</param>
        internal void SetLifetimeCoins(float lifetimeCoins)
        {
            this.lifetimeCoins = lifetimeCoins;
        }
    }
}