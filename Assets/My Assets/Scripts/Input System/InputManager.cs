using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputManager : MonoBehaviour
{

    private UserInputAction actions;
    private bool isHolding=false;
    private Vector2 mousePosition;
    private void Awake()
    {
        actions = new UserInputAction();
    }

    private void OnEnable()
    {
        actions.Enable();
        actions.Player.Move.performed += OnMovePerformed;
        actions.Player.LeftMouse.started +=OnMouseStarted;
        actions.Player.LeftMouse.performed +=OnMousePerformed;
        actions.Player.LeftMouse.canceled +=OnMouseCanceled;

    }
    private void OnDisable()
    {
        actions.Disable();
        actions.Player.Move.performed -= OnMovePerformed;
        actions.Player.LeftMouse.started -=OnMouseStarted;
        actions.Player.LeftMouse.performed -=OnMousePerformed;
        actions.Player.LeftMouse.canceled -=OnMouseCanceled;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Move pressed");
    }
    private void OnMouseStarted(InputAction.CallbackContext context)
    {
        // isHolding = true;
    }
    private void OnMousePerformed(InputAction.CallbackContext context)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (context.interaction is TapInteraction)
        {
            FurnitureManager.Instance.InputLeftMouseTap();
        }
        else if (context.interaction is HoldInteraction)
        {
            Debug.Log("Mouse Holding");
            isHolding = true;
        }
    }
    private void OnMouseCanceled(InputAction.CallbackContext context)
    {
        FurnitureManager.Instance.InputLeftMouseReleased();
        isHolding=false;
    }

    private void Update()
    {
        if (isHolding)
        {
            mousePosition = Mouse.current.position.ReadValue();
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            FurnitureManager.Instance.InputLeftMouseHold(mousePosition,mouseDelta);
        }
    }
}
