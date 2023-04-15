using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Guide
{
    [SerializeField] private float guideLength;
    [SerializeField] private LineRenderer lineRenderer;

    public void Draw(Vector3 startPosition, Vector3 direction)
    {
        Vector3 currentPosition = startPosition;
        Vector3 currentDirection = direction;
        float remainingLength = guideLength;

        List<Vector3> linePoints = new List<Vector3>();
        linePoints.Add(currentPosition);

        while (remainingLength > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(currentPosition, currentDirection, out hit, remainingLength))
            {
                linePoints.Add(hit.point);
                currentPosition = hit.point;
                currentDirection = Vector3.Reflect(currentDirection, hit.normal);
                remainingLength -= hit.distance;
            }
            else
            {
                linePoints.Add(currentPosition + currentDirection * remainingLength);
                remainingLength = 0;
            }
        }

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
    }
    
    public void Clear()
    {
        lineRenderer.positionCount = 0;
    }
}
