using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // For scene management

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public RectTransform healthBarFill;  // Use RectTransform instead of Image
    public GameObject gameOverPanel;  // Drag your Game Over UI panel in the inspector
    private float originalHealthBarWidth;


    private void Start()
    {
        originalHealthBarWidth = healthBarFill.sizeDelta.x;
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        // Check for game over
        if(currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBarFill.sizeDelta = new Vector2(healthPercentage * originalHealthBarWidth, healthBarFill.sizeDelta.y);  // Adjust width based on health percentage
    }
    
    void OnCollisionEnter2D(Collision2D collision) // For 2D games
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            TakeDamage(10);  // This will take away 10 health when the enemy touches the player.
        }
        if (collision.gameObject.CompareTag("Tree"))
        {
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("Truck"))
        {
            TakeDamage(5);
        }
    }

    void GameOver()
    {
        // Display Game Over UI
        gameOverPanel.SetActive(true);

        // Optionally: Pause the game
        // Time.timeScale = 0f;

        // Optionally: Restart the game after a delay (e.g., 3 seconds)
        Invoke("RestartGame", 3f);
    }

    void RestartGame()
    {
        // Reset the game time scale
        Time.timeScale = 1f;

        // Load the current scene (restarts the game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
