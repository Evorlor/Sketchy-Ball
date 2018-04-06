using System.Collections.Generic;
using UnityEngine;

namespace Sketchy.Gameplay
{
    [RequireComponent(typeof(EdgeCollider2D))]
    [RequireComponent(typeof(LineRenderer))]
    public class Line : MonoBehaviour
    {
        private EdgeCollider2D edgeCollider2D;
        private LineRenderer lineRenderer;
        private List<Vector2> waypoints = new List<Vector2>();
        private Vector2 originalPosition;

        private void Awake()
        {
            edgeCollider2D = GetComponent<EdgeCollider2D>();
            lineRenderer = GetComponent<LineRenderer>();
        }

        private void Start()
        {
            originalPosition = transform.position;
        }

        /// <summary>
        /// Adds a waypoint to the line given a screen position
        /// </summary>
        /// <param name="screenPosition">Screen position where the waypoint is to be added</param>
        internal void AddPosition(Vector2 screenPosition)
        {
            screenPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            var movementAdjustment = (Vector2)transform.position - originalPosition;
            screenPosition -= movementAdjustment;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, screenPosition);
            waypoints.Add(screenPosition);
            if (waypoints.Count > 2)
            {
                edgeCollider2D.points = waypoints.ToArray();
            }
        }

        /// <summary>
        /// Gets the number of waypoints in the line
        /// </summary>
        /// <returns>Number of waypoints in the line</returns>
        internal int CountWaypoints()
        {
            return waypoints.Count;
        }
    }
}
