using UnityEngine;

public class Playerattack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public LayerMask enemyLayers;
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator attached to the player
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Right-click
        {
            Attack();
        }
    }

    void Attack()
    {
        // Play attack animation
        {
            animator.SetTrigger("Attack");
        }

        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
       {
           if (enemy.TryGetComponent<OrcHealth>(out var enemyHealth))
          {
               enemyHealth.TakeDamage(attackDamage);
           }
       }
    }

    // Draw the attack range in the editor
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

