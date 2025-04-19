using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OrcHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject healthBarUIPrefab;
    private GameObject healthBarUI;
    private Slider healthSlider;
    private Animator animator;

    private Transform uiCanvas;
    private Vector3 healthBarOffset = new Vector3(0, 1.5f, 0); // Adjust as needed

    void Start()
    {
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
        if (animator == null)

            if (healthBarUIPrefab != null && uiCanvas != null)
        {
            healthBarUI = Instantiate(healthBarUIPrefab, uiCanvas); // Parent to the Canvas
            healthSlider = healthBarUI.GetComponentInChildren<Slider>();
        }
    }

    void Update()
    {
        if (healthBarUI != null)
        {
            Vector3 worldPosition = transform.position + healthBarOffset;
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
            healthBarUI.transform.position = screenPosition;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Disable movement and other scripts to prevent further actions
        if (GetComponent<Orcmove>() != null)
        {
            GetComponent<Orcmove>().enabled = false;
        }
        if (GetComponent<Orcattack>() != null)
        {
            GetComponent<Orcattack>().enabled = false;
        }

        // Play the death animation and wait for it to finish
        if (animator != null)
        {
            animator.SetTrigger("Die"); // Trigger the death animation
            StartCoroutine(DestroyAfterAnimation());
        }
        else
        {
            // If no Animator, destroy immediately
            Destroy(healthBarUI);
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Wait for the death animation to finish
        // Get the length of the current animation clip (in the "Death" state)
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = stateInfo.length;

        // Wait for the animation to finish
        yield return new WaitForSeconds(animationLength);

        // Destroy the health bar and the orc
        if (healthBarUI != null)
        {
            Destroy(healthBarUI);
        }
        Destroy(gameObject);
    }
}