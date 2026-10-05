using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    [SerializeField] private GameObject MoveMarker;
    [SerializeField] private GameObject RotateMarker;

    public void ShowMove()
    {
        MoveMarker.SetActive(true);
        RotateMarker.SetActive(false);
    }
    public void ShowRotate()
    {
        MoveMarker.SetActive(false);
        RotateMarker.SetActive(true);
    }

    public void Hide()
    {
        MoveMarker.SetActive(false);
        RotateMarker.SetActive(false);
    }
}