using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.TextCore.Text;

public class CharacterControl : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 dir;
    [SerializeField] [Range(0f,5f)] private float speed = 3;

    [SerializeField] private GunScript gunScript;
    private float gravity = -9.81f;
    private bool ground = true;
    private CharacterAnim anim;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (characterController == null)
            return;

        anim = GetComponent<CharacterAnim>();
    }

    void LateUpdate()
    {
        ground = characterController.isGrounded;

        var velocity = transform.TransformDirection(dir) * (speed * Time.deltaTime);
        if (ground && velocity.y < 0) velocity.y = 0;

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity);
        anim.UpdateMovedir(new Vector2(dir.x, dir.z));
    }

    private void OnAttack()
    {
        gunScript.Shoot();
    }

    private void OnReload()
    {
        gunScript.ReloadingStart();
    }

    public void OnMove(InputValue context)
    {
        //characterController.Move(context.Get<Vector2>());
        dir = new Vector3(context.Get<Vector2>().x, 0, context.Get<Vector2>().y);
    }
}
