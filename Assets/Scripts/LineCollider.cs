using System.Collections.Generic;
using UnityEngine;

public class LineCollider : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        SetColliderPoints();
    }

    void SetColliderPoints()
    {
        Vector2[] positions = new Vector2[lineRenderer.positionCount];
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            positions[i] = lineRenderer.GetPosition(i);
        }
        edgeCollider.SetPoints(new List<Vector2>(positions));
    }

    void Update()
    {
        SetColliderPoints();
    }
}
