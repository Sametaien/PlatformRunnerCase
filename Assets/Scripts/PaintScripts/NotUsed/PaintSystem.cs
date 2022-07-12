#region

using System.Collections.Generic;
using UnityEngine;

#endregion

namespace PaintScripts
{
    public class PaintSystem : MonoBehaviour
    {
        public GameObject linePrefab;
        public GameObject currentLine;
        public LineRenderer lineRenderer;
        public EdgeCollider2D edgeCollider;
        public List<Vector2> points;
        public Camera paintCam;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) CreateLine();
            if (Input.GetMouseButton(0))
            {
                Vector2 tempPoint = paintCam.ScreenToWorldPoint(Input.mousePosition);
                if (Vector2.Distance(tempPoint, points[points.Count - 1]) > .1f) UpdateLine(tempPoint);
            }
        }

        private void CreateLine()
        {
            currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
            lineRenderer = currentLine.GetComponent<LineRenderer>();
            edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
            points.Clear();
            points.Add(paintCam.ScreenToWorldPoint(Input.mousePosition));
            points.Add(paintCam.ScreenToWorldPoint(Input.mousePosition));
            lineRenderer.SetPosition(0, points[0]);
            lineRenderer.SetPosition(1, points[1]);
            edgeCollider.points = points.ToArray();
        }

        private void UpdateLine(Vector2 newPoints)
        {
            points.Add(newPoints);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPoints);
            edgeCollider.points = points.ToArray();
        }
    }
}