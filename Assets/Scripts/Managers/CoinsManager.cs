using Sketchy.Constants;
using UnityEngine;

namespace Sketchy.Managers
{
    public class CoinsManager
    {
        private float coins = 0.0f;
        private float lifetimeCoins = 0.0f;

        /// <summary>
        /// Creates a new Coins Manager
        /// </summary>
        internal CoinsManager()
        {
            LoadCoins();
        }

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
            SaveCoins();
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
            SaveLifetimeCoins();
        }

        private void LoadCoins()
        {
            coins = PlayerPrefs.GetFloat(DataKeys.Coins, 0.0f);
            lifetimeCoins = PlayerPrefs.GetFloat(DataKeys.LifetimeCoins, 0.0f);
        }

        private void SaveCoins()
        {
            PlayerPrefs.SetFloat(DataKeys.Coins, coins);
        }

        private void SaveLifetimeCoins()
        {
            PlayerPrefs.SetFloat(DataKeys.LifetimeCoins, lifetimeCoins);
        }
    }
}