using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class FurnitureManager : MonoBehaviour
{
    public static FurnitureManager Instance;
    public enum FurnitureState
    {
        None, Placing, Selected, Moving, Rotating
    }

    public FurnitureState furnitureState = FurnitureState.None;

    [Header("Reference")]
    [SerializeField] private ARPlacementRaycaster placementRaycaster;
    [SerializeField] private FurnitaureUI furnitaureUI;
    [SerializeField] private LayerMask furnitureLayer;

    [Header("Attributes")]
    [SerializeField] private float rotationSpeed = 0.5f;
// Private Attributes ----------------------------------------------------------
    public FurnitureItem SelectedFurniture;
    public GameObject currentSelectedFurniture;
    private SelectionIndicator currentSelectionIndicator;
// Bool
    public bool isSelected = false;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

// User Input ======================================================================================
    public void InputLeftMouseTap()
    {
        Debug.Log("Mouse Click");
        TryPlaceFurniture(Input.mousePosition);
    }
    public void InputLeftMouseHold(Vector2 screenPosition , Vector2 mouseDelta)
    {
        
        if (furnitureState == FurnitureState.Moving)
        {
            MoveFurniture(screenPosition);
        }else if(furnitureState == FurnitureState.Rotating)
        {
            RotateFurniture(mouseDelta);
        }
    }
    public void InputLeftMouseReleased()
    {
        
    }
// =================================================================================================
    private void TryPlaceFurniture(Vector2 screenPosition)
    {
        if (SelectedFurniture == null)
        {
            Debug.Log("No furniture selected.");
            return;
        }

        if(placementRaycaster.CheckFurniture(screenPosition,out GameObject furniture))
        {
            if(currentSelectionIndicator != null) currentSelectionIndicator.Hide();
            currentSelectedFurniture = furniture;
            currentSelectionIndicator = currentSelectedFurniture.GetComponent<SelectionIndicator>();
            currentSelectionIndicator.ShowMove();
            furnitureState=FurnitureState.Selected;
            Debug.Log("Furniture Selected : "+furniture.name);
            furnitaureUI.EnableFurnitureMovement();
            return;
        }

        if(furnitureState == FurnitureState.Selected || furnitureState == FurnitureState.Moving || furnitureState == FurnitureState.Rotating)
        {
            if(currentSelectionIndicator != null) currentSelectionIndicator.Hide();
            furnitureState = FurnitureState.Placing;
            furnitaureUI.EnableFurnitureSelection();

            return;
        }
        if(placementRaycaster.GetFurniturePlacingPoint(screenPosition, out Pose pose))
        {
            FurnitureItem furnitureItem = SelectedFurniture;
            GameObject prefab = furnitureItem.furnitureData.prefab;

            Instantiate(
                prefab,
                pose.position,
                pose.rotation
            );
            Debug.Log("Furniture Placed");
            return;
        }
    }

    public void MoveFurniture(Vector2 screenPosition)
    {
        if(currentSelectedFurniture == null)
        {
            Debug.Log("Current Furniture is null");
            return;
        }
        if (placementRaycaster.GetFurniturePlacingPoint(screenPosition, out Pose pose))
        {
            currentSelectedFurniture.transform.position = pose.position;
        }
    }

    private void RotateFurniture(Vector2 mouseDelta)
    {
        if (mouseDelta.sqrMagnitude > 0)
        {
            float rotationAmount = mouseDelta.x * rotationSpeed;
            currentSelectedFurniture.transform.Rotate( 0f, -rotationAmount, 0f );
        }
    }
// =============================================================================

    public void SelectFurniture(FurnitureItem furnitureItem)
    {
        SelectedFurniture = furnitureItem;
    }

    public void SelectFurnitureMove()
    {
        furnitureState = FurnitureState.Moving;
        currentSelectionIndicator.ShowMove();
    }
    public void SelectFurntitureRotate()
    {
        furnitureState = FurnitureState.Rotating;
        currentSelectionIndicator.ShowRotate();
    }

}