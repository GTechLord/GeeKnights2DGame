using UnityEngine;

public class Orcattack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public LayerMask playerLayer;
    public Animator animator;
    public float attackCooldown = 2f;
    private float nextAttackTime = 0f;
    private bool playerInRange = false;
    private GameObject player;
    void Update()
    {
        if (playerInRange && Time.time >= nextAttackTime)
        {
            animator.SetTrigger("AttackTrigger");
            nextAttackTime = Time.time + attackCooldown;
        }

    }
    // called  when another collider enters this GameObject's 2D trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player by checking tag
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            // Store a reference to the player GameObject
            player = other.gameObject;
        }
    }

    // when it exit
    void OnTriggerExit2D(Collider2D other)
    {
        // If its the player
        if (other.CompareTag("Player"))
        {
            // when he not in range anymore
            playerInRange = false;
        }
    }

    public void DealDamage()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayers)
        {
            if (player.TryGetComponent<PlayerHealth>(out var playerHealth))
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

