using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YasDrawing : MonoBehaviour
{
    // Prefab that has a LineRenderer component on it.
    public GameObject pencil;

    // The active line we’re currently adding points to.
    private LineRenderer currentLineRenderer;

    // Cache the last point we actually added (to avoid adding duplicates).
    private Vector3 lastPos;

    // Camera used to convert mouse to world. If not set, we’ll grab Camera.main.
    public Camera m_camera;

    void Start()
    {
        if (m_camera == null)
        {
            m_camera = Camera.main;
        }
    }

    void Update()
    {
        // 1) Start a new stroke when mouse is first pressed.
        if (Input.GetMouseButtonDown(0))
        {
            BeginStroke();
            AddPointAtMouse(); // add the very first point where we pressed
        }

        // 2) While holding the mouse, keep adding points.
        if (Input.GetMouseButton(0) && currentLineRenderer != null)
        {
            AddPointAtMouse();
        }

        // 3) On release, end the stroke.
        if (Input.GetMouseButtonUp(0))
        {
            EndStroke();
        }
    }

    // Create a new line and prepare it.
    private void BeginStroke()
    {
        GameObject strokeInstance = Instantiate(pencil);
        currentLineRenderer = strokeInstance.GetComponent<LineRenderer>();

        // Make sure line uses world space and starts empty.
        currentLineRenderer.useWorldSpace = true;
        currentLineRenderer.positionCount = 0;
    }

    // Stop adding points to the current line.
    private void EndStroke()
    {
        currentLineRenderer = null;
    }

    // Convert mouse position to world and add a point if it changed.
    private void AddPointAtMouse()
    {
        // For an orthographic 2D setup, draw on z = 0.
        Vector3 mouseScreen = Input.mousePosition;
        mouseScreen.z = Mathf.Abs(m_camera.transform.position.z); // distance to z=0 plane (orthographic ignores z, but keeps it stable)
        Vector3 mouseWorld = m_camera.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = 0f;

        // Only add if the point moved since last time (avoids duplicate points).
        if (currentLineRenderer.positionCount == 0 || (mouseWorld - lastPos).sqrMagnitude > 0.0001f)
        {
            AddPoint(mouseWorld);
            lastPos = mouseWorld;
        }
    }

    // Actually append a point to the LineRenderer.
    private void AddPoint(Vector3 pointPos)
    {
        int nextIndex = currentLineRenderer.positionCount;
        currentLineRenderer.positionCount = nextIndex + 1;
        currentLineRenderer.SetPosition(nextIndex, pointPos);
    }
}
