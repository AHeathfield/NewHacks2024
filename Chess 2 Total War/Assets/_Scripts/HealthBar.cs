using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject[] healthSegments; // Array to hold the health segments (Segment 1, Segment 2, Segment 3)
    private int currentHealth;


    void Start()
    {
        // Set the initial health to the total number of segments
        currentHealth = healthSegments.Length;
    }

    void OnMouseDown()
    {
        // Reduce health when the pawn is clicked
        TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        // Reduce current health
        currentHealth = Mathf.Max(0, currentHealth - damage);

        // Update the health bar visibility
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        // Loop through each segment and toggle its visibility based on current health
        for (int i = 0; i < healthSegments.Length; i++)
        {
            if (i < currentHealth)
            {
                // Set active if within current health
                healthSegments[i].SetActive(true);
            }
            else
            {
                // Make transparent if outside current health
                healthSegments[i].SetActive(false);
            }
        }
    }
}