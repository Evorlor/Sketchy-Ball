using Sketchy.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Sketchy.Gameplay
{
    public class Level : MonoBehaviour
    {
        internal static UnityAction<float> OnLevelProgressed;

        [Tooltip("Speed at which the level scrolls, in terms of units per second")]
        [SerializeField]
        [Range(0.0f, 9.81f)]
        private float scrollSpeed = 1.0f;

        [Tooltip("Acceleration rate of level's scroll speed, in terms of units per second")]
        [SerializeField]
        [Range(0.0f, 2.0f)]
        private float accelerationRate = 0.1f;

        [Tooltip("Background, which is to be scrolled at the speed of the level")]
        [SerializeField]
        private MeshRenderer background;

        [Tooltip("GameObject to attach walls to.  Leave empty if no walls are wanted")]
        [SerializeField]
        private GameObject wallsGameObject;

        [Tooltip("How fast the scroll speed accelerates after game over")]
        [SerializeField]
        [Range(0.0f, 9.81f)]
        private float gameOverAcceleration = 1.0f;

        private const string WallsGameObjectName = "Walls";
        private static readonly Vector2 ScrollDirection = Vector2.down;

        private static Vector2 mainTextureOffset = Vector2.zero;

        private void OnEnable()
        {
            GameplayManager.OnGameOver += ClearLevel;
        }

        private void Start()
        {
            background.material.mainTextureOffset = mainTextureOffset;
            if (wallsGameObject)
            {
                CreateWalls();
            }
        }

        private void Update()
        {
            ScrollLevel();
            AccelerateScrollSpeed();
        }

        private void OnDisable()
        {
            GameplayManager.OnGameOver -= ClearLevel;
        }

        private void ScrollLevel()
        {
            var translation = -ScrollDirection * scrollSpeed * Time.deltaTime;
            transform.Translate(translation);
            background.material.mainTextureOffset += -translation / background.transform.localScale.y;
            mainTextureOffset = background.material.mainTextureOffset;
            if (OnLevelProgressed != null)
            {
                OnLevelProgressed(translation.y);
            }
        }

        private void AccelerateScrollSpeed()
        {
            scrollSpeed += Time.deltaTime * accelerationRate;
        }

        private void CreateWalls()
        {
            var walls = wallsGameObject.GetComponents<EdgeCollider2D>();
            float yExtent = Camera.main.orthographicSize;
            float xExtent = (float)Screen.width / Screen.height * yExtent;
            var leftWallPoints = new Vector2[2]
                {
                    new Vector2(-xExtent, -yExtent),
                    new Vector2(-xExtent, yExtent)
                };
            walls[0].points = leftWallPoints;
            var rightWallPoints = new Vector2[2]
                {
                    new Vector2(xExtent, -yExtent),
                    new Vector2(xExtent, yExtent)
                };
            walls[1].points = rightWallPoints;
        }

        private void ClearLevel()
        {
            accelerationRate = gameOverAcceleration;
        }
    }
}