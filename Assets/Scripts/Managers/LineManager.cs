using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField]
    private MovementController _movementController;

    [SerializeField]
    private MeshFilter _meshFilter;

    [SerializeField]
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private EdgeCollider2D _edgeCollider;

    [SerializeField]
    private Camera _drawCam;

    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private LineRenderer drawLineRenderer;

    private List<Vector2> points;

    private void Awake()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 0;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.useWorldSpace = false;
    }

    private void Update()
    {
        if (!_drawCam.pixelRect.Contains(Input.mousePosition)) return;
        if (Input.GetMouseButtonDown(0))
        {
            Reset();
        }

        if (Input.GetMouseButton(0))
        {
            var mousePos = _drawCam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            if (!points.Contains(mousePos))
            {
                points.Add(mousePos);
                lineRenderer.positionCount = points.Count;
                drawLineRenderer.positionCount = points.Count;
                var pos = mousePos - _drawCam.transform.position;
                pos.z = 0;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
                drawLineRenderer.SetPosition(drawLineRenderer.positionCount - 1, mousePos);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _meshFilter.transform.parent.rotation = Quaternion.identity;
            Mesh _mesh = new Mesh();
            lineRenderer.BakeMesh(_mesh);
            _meshFilter.sharedMesh = _mesh;
            Vector3[] positions = new Vector3[lineRenderer.positionCount];
            lineRenderer.GetPositions(positions);
            _edgeCollider.points = positions.ToVector2Array();
            _movementController.SetHingePositions(GetCorrectPos(points[0]), GetCorrectPos(points[points.Count - 1]));
        }
    }
    private void Reset()
    {
        lineRenderer.positionCount = 0;
        drawLineRenderer.positionCount = 0;
        _meshFilter.transform.position = Vector3.zero;
        points.Clear();
    }

    private Vector2 GetCorrectPos(Vector2 pos)
    {
        return new Vector2(pos.x - _drawCam.transform.position.x, pos.y - _drawCam.transform.position.y);
    }
}

