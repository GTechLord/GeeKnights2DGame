using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject gameOverUI; 
    public Animator animator;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die"); //  Die trigger in Animator

        // Delay game over UI until after death animation plays
        StartCoroutine(ShowGameOverAfterDelay(6.5f)); // Adjust delay to match animation length
    }

    private System.Collections.IEnumerator ShowGameOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverUI.SetActive(true);
        Time.timeScale = 0; // Freeze game
    }
}