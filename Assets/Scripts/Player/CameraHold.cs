using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraHold : MonoBehaviour
{
    [SerializeField] Transform Player;

    [SerializeField] Transform pivot;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private float sensivity = 2f;
    private Vector2 lookInput;

    private float pitch;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        var mouseX = lookInput.x * sensivity;
        var mouseY = lookInput.y * sensivity;
        Player.Rotate(Vector3.up * mouseX);
        pitch -= mouseY * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minY, maxY);
        Debug.Log(pitch);

        pivot.localRotation = quaternion.Euler(pitch, 0f, 0f);
    } 

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

}
