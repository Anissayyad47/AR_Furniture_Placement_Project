using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaceCube : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject cubePrefab;

    private GameObject placedCube;

    private bool isDragging = false;

    private static List<ARRaycastHit> rayHits = new List<ARRaycastHit>();

    private void Update()
    {
        // No AR Raycast Manager assigned
        if (raycastManager == null)
            return;

        // Mouse input for XR Simulation / Unity Editor
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        // Start click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPosition = Input.mousePosition;

            // If cube already exists, check if we clicked the cube
            if (placedCube != null)
            {
                Debug.Log("PlaceCube is not null");
                Ray ray = Camera.main.ScreenPointToRay(screenPosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform == placedCube.transform)
                    {
                        isDragging = true;
                        return;
                    }
                }
            }

            // If we didn't click the cube, try placing it on a plane
            if (placedCube == null)
            {
                Debug.Log("PlaceCube is not null");
                PlaceCube(screenPosition);
            }
        }

        // While holding mouse button
        if (Input.GetMouseButton(0) && isDragging)
        {
            MoveCube(Input.mousePosition);
        }

        // Release mouse button
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    private void PlaceCube(Vector2 screenPosition)
    {
        if (raycastManager.Raycast(
            screenPosition,
            rayHits,
            TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = rayHits[0].pose;

            placedCube = Instantiate(
                cubePrefab,
                hitPose.position,
                hitPose.rotation
            );
        }
    }

    private void MoveCube(Vector2 screenPosition)
    {
        if (raycastManager.Raycast(
            screenPosition,
            rayHits,
            TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = rayHits[0].pose;

            placedCube.transform.SetPositionAndRotation(
                hitPose.position,
                hitPose.rotation
            );
        }
    }
}