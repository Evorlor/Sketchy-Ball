using UnityEngine;

namespace Sketchy.Utilities
{
    public static class MathUtility
    {
        /// <summary>
        /// Gets a random Gaussian float
        /// </summary>
        /// <param name="average">The average of the random distribution</param>
        /// <param name="sigma">The number of standard deviations allowed to move from the average</param>
        /// <returns>A random float</returns>
        public static float GetRandomFloat(float average, float sigma = 3.0f)
        {
            float randomArgument0 = Random.value;
            float randomArgument1 = Random.value;
            float normalizedRandomNumber = Mathf.Sqrt(-2.0f * Mathf.Log(randomArgument0)) * Mathf.Sin(2.0f * Mathf.PI * randomArgument1);
            float randomNumber = average + sigma * normalizedRandomNumber;
            return randomNumber;
        }
    }
}
