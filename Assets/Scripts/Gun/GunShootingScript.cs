using UnityEngine;
using UnityEngine.Events;
using System.Collections; 

public class GunShootingScript : MonoBehaviour
{
    [SerializeField] private ShellEjectionScript shellEjection;
    [SerializeField] public UnityEvent eventShot;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayShootAnimation()
    {
        animator.SetBool("isFiring", true);
    }

    public void ShootStart()
    {
        Debug.Log("Start shooting");
        PlayShootAnimation();
        eventShot?.Invoke();
    }

    public void ShootStop()
    {
        Debug.Log("Stop shooting");
        animator.SetBool("isFiring", false);
    }

    public void Ejcectionmoment()
    {
        shellEjection.EjectShell();
    }
}
