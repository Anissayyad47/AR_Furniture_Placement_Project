using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FurnitaureUI : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform furnitureContainerParent;
    [SerializeField] private GameObject furnitureItemPrefeb;
    [SerializeField] private FurnitureManager furnitureManager;

    [Header("UI Panels")]
    [SerializeField] private GameObject FurnitureSelection;
    [SerializeField] private GameObject FurnitureMovement;
    [Header("Furniture Items")]
    [SerializeField] private FurnitureItem sofa1;
    [SerializeField] private FurnitureItem sofa2;
    [SerializeField] private FurnitureItem couch1;
    [SerializeField] private FurnitureItem couch2;

    [Header("Furniture Movement Icons")]
    [SerializeField] private GameObject UISelectionMove;
    [SerializeField] private GameObject UISelectionRotation;

    [Header("Furniture Items Selection Frame")]
    [SerializeField] private GameObject UISelectionFrame1;
    [SerializeField] private GameObject UISelectionFrame2;
    [SerializeField] private GameObject UISelectionFrame3;
    [SerializeField] private GameObject UISelectionFrame4;

    public void Start()
    {
        DisableAllUiSelectionFrame();
        DisableAllUISelectionInFurnitureMovement();
        FurnitureSelection.SetActive(true);
        FurnitureMovement.SetActive(false);
    }

    public void EnableFurnitureSelection()
    {
        DisableAllUISelectionInFurnitureMovement();
        FurnitureSelection.SetActive(true);
        FurnitureMovement.SetActive(false);
    }
    public void EnableFurnitureMovement()
    {
        FurnitureSelection.SetActive(false);
        FurnitureMovement.SetActive(true);
    }

    public void SelectFurnitureMove()
    {
        DisableAllUISelectionInFurnitureMovement();
        UISelectionMove.SetActive(true);
        FurnitureManager.Instance.SelectFurnitureMove();
    }
    public void SelectFurnitureRotate()
    {
        DisableAllUISelectionInFurnitureMovement();
        UISelectionRotation.SetActive(true);
        FurnitureManager.Instance.SelectFurntitureRotate();
    }
    public void SelectSofa1()
    {
        furnitureManager.SelectFurniture(sofa1);
        DisableAllUiSelectionFrame();
        UISelectionFrame1.SetActive(true);
    }
    public void SelectSofa2()
    {
        furnitureManager.SelectFurniture(sofa2);
        DisableAllUiSelectionFrame();
        UISelectionFrame2.SetActive(true);
    }
    public void SelectCouch1()
    {
        furnitureManager.SelectFurniture(couch1);
        DisableAllUiSelectionFrame();
        UISelectionFrame3.SetActive(true);
    }
    public void SelectCouch2()
    {
        furnitureManager.SelectFurniture(couch2);
        DisableAllUiSelectionFrame();
        UISelectionFrame4.SetActive(true);
    }

    private void DisableAllUiSelectionFrame()
    {
        UISelectionFrame1.SetActive(false);
        UISelectionFrame2.SetActive(false);
        UISelectionFrame3.SetActive(false);
        UISelectionFrame4.SetActive(false);
    }
    private void DisableAllUISelectionInFurnitureMovement()
    {
        UISelectionMove.SetActive(false);
        UISelectionRotation.SetActive(false);
    }

}
