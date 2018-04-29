using Sketchy.Extensions;
using Sketchy.Utilities;
using UnityEngine;

namespace Sketchy.Gameplay
{
    public class Spawner : MonoBehaviour
    {
        [Tooltip("The GameObject which is to be spawned")]
        [SerializeField]
        private GameObject spawnPrefab;

        [Tooltip("The initial rate at which the spawn will spawn, in terms of average seconds between spawns")]
        [SerializeField]
        [Range(0.0f, 60.0f)]
        private float spawnRate = 10.0f;

        [Tooltip("The rate of change in spawn rate, in terms of change per second")]
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        private float spawnRateChange = 0.0f;

        [Tooltip("Delay before first spawn starts")]
        [SerializeField]
        [Range(0.0f, 60.0f)]
        private float firstSpawnDelay = 0.0f;

        [Tooltip("Whether or not to use linear spawn rates, opposed to average spawn rates")]
        [SerializeField]
        private bool linearSpawning = false;

        private float spawnTimeRemaining;
        private float minSpawnX;
        private float maxSpawnX;
        private float spawnY;

        private void Start()
        {
            SetSpawnArea();
            spawnTimeRemaining = GetNextSpawnTime() + firstSpawnDelay;
        }

        private void Update()
        {
            if (spawnTimeRemaining > 0.0f)
            {
                spawnTimeRemaining -= Time.deltaTime;
            }
            if (spawnTimeRemaining <= 0.0f)
            {
                Spawn();
            }
            spawnRate += spawnRateChange * Time.deltaTime;
        }

        private void Spawn()
        {
            var spawnPosition = new Vector2(Random.Range(minSpawnX, maxSpawnX), spawnY);
            bool positionAvailable = !Physics2D.OverlapCircle(spawnPosition, spawnPrefab.GetExtents().magnitude);
            if (positionAvailable)
            {
                Instantiate(spawnPrefab, spawnPosition, Quaternion.identity, transform);
                spawnTimeRemaining = GetNextSpawnTime();
            }
            else
            {
                spawnTimeRemaining = Time.deltaTime;
            }
        }

        private void SetSpawnArea()
        {
            var spawnExtents = spawnPrefab.GetExtents();
            maxSpawnX = (float)Screen.width / Screen.height * Camera.main.orthographicSize - spawnExtents.x;
            minSpawnX = maxSpawnX * -1.0f;
            spawnY = -Camera.main.orthographicSize - spawnExtents.y;
        }

        private float GetNextSpawnTime()
        {
            return linearSpawning ? spawnRate : MathUtility.GetRandomFloat(spawnRate);
        }
    }
}