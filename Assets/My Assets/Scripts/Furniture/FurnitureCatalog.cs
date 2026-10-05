using UnityEngine;

public class FurnitureCatalog : MonoBehaviour
{
    [SerializeField]
    private FurnitureData[] furnitureItems;

    public FurnitureData[] FurnitureItems => furnitureItems;
}