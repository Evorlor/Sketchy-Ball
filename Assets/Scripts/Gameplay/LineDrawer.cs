using UnityEngine;
using UnityEngine.Events;

namespace Sketchy.Gameplay
{
    public class LineDrawer : MonoBehaviour
    {
        /// <summary>
        /// Event called when a line has been drawn
        /// </summary>
        public static UnityAction OnLineDrawn;

        [Tooltip("Line prefab used to draw lines")]
        [SerializeField]
        private Line linePrefab;

        [Tooltip("Container for lines")]
        [SerializeField]
        private Transform lineContainer;

        [Tooltip("Minimum threshold of drag for line to start drawing (in screen units)")]
        [SerializeField]
        [Range(0.0f, 100.0f)]
        private float dragThreshold = 0.0f;

        private const string LineGameObjectName = "Line";

        private Line activeLine;
        private Vector2 startingPosition;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartLine();
            }
            if (Input.GetMouseButton(0) && activeLine)
            {
                DrawLine();
            }
            if (Input.GetMouseButtonUp(0) && activeLine)
            {
                FinishLine();
            }
        }

        private void OnDestroy()
        {
            if (activeLine)
            {
                FinishLine();
            }
        }

        private void StartLine()
        {
            activeLine = Instantiate(linePrefab, lineContainer, true);
            activeLine.name = LineGameObjectName;
            startingPosition = Input.mousePosition;
        }

        private void DrawLine()
        {
            if (((Vector2)Input.mousePosition - startingPosition).magnitude > dragThreshold)
            {
                activeLine.AddPosition(Input.mousePosition);
            }
        }

        private void FinishLine()
        {
            if (activeLine.CountWaypoints() >= 2)
            {
                if (OnLineDrawn != null)
                {
                    OnLineDrawn();
                }
            }
            activeLine = null;
        }
    }
}