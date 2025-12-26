using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator anim;
    private Vector2 movedir;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void UpdateMovedir(Vector2 dir) => movedir = dir;

    void Update()
    {
        anim.SetFloat("SpeedX", movedir.x);
        anim.SetFloat("SpeedZ", movedir.y);
    }
}
