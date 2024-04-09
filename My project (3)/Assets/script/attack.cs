using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float colldownTimer=Mathf.Infinity;

    private void Awake()
    {
        anim=GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)&& colldownTimer>attackCooldown && playerMovement.canAttack())
            Attack();
        
        colldownTimer+=Time.deltaTime;
    }
    private void Attack()
    {
        anim.SetTrigger("attack");
        colldownTimer=0;
    }
}
