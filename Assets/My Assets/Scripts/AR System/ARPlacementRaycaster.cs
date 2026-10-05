using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementRaycaster : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private LayerMask furnitureLayer;

    private static readonly List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public bool CheckFurniture(Vector2 screenPosition, out GameObject hitObject)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if(Physics.Raycast(ray, out RaycastHit hit, 100f, furnitureLayer))
        {
            Debug.Log("Hit: " + hit.collider.name);
            hitObject= hit.collider.gameObject;
            return true;
        }
        hitObject=null;
        return false;
    }

    public bool GetFurniturePlacingPoint(Vector2 screenPosition, out Pose pose)
    {
        if (raycastManager.Raycast( screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            pose=hitPose;
            return true;
        }
        pose=default;
        return false;
    }
    public bool GetFurnitureMovePoint(Vector2 screenPosition, out Pose pose)
    {
        if (raycastManager.Raycast( screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            pose=hitPose;
            return true;
        }
        pose=default;
        return false;
    }
}