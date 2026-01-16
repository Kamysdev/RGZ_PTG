using UnityEngine;
using UnityEngine.InputSystem;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField] private bool isOpen = true;

    private void OnMenu(InputValue context)
    {
        Debug.Log("Escape pressed");
        isOpen = !isOpen;
        ChangeMenuState();
    }

    private void ChangeMenuState()
    {
        if (isOpen) 
        {
            // Cursor.lockState = CursorLockMode.Locked;
            // Cursor.visible = false;
            Screen.lockCursor = true;
        }
        else
        {
            // Cursor.lockState = CursorLockMode.None;
            // Cursor.visible = true;
            Screen.lockCursor = false;
        }
    }
}
