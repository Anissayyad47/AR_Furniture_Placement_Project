using UnityEngine;

[CreateAssetMenu(
    fileName = "FurnitureData",
    menuName = "AR Furniture/Furniture Data"
)]
public class FurnitureData : ScriptableObject
{
    [Header("Basic Information")]
    public string furnitureName;
    public Sprite previewImage;

    [Header("Furniture")]
    public GameObject prefab;

    [Header("Placement")]
    public bool canRotate = true;
}