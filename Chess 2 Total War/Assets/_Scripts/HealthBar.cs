using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image barFill;
    public int maxHealth = 3;
    private int currentHealth;

    // Optional: references to segment images if you want visible segments
    [SerializeField] private Image[] healthSegments;

    void Start()
    {
        // Make sure the Image component is set to "Filled" type in the Inspector
        if (barFill != null)
        {
            barFill.type = Image.Type.Filled;
            barFill.fillMethod = Image.FillMethod.Horizontal; // or whatever direction you want
        }
        
        SetHealth(maxHealth);
    }

    public void SetHealth(int health)
    {
        currentHealth = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (barFill != null)
        {
            barFill.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}