using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private GameObject gameOverPanel; // reference to UI panel

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHPUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // make sure it's hidden at start
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHPUI();

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHPUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHealth;
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        StartCoroutine(RestartAfterDelay(5f)); // wait 5 seconds
    }

    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}