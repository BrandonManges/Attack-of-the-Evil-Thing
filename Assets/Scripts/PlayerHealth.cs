using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int maxHealth = 3;
    public int currentHealth;

    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip damageSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("PLAYER TOOK A HIT");
        currentHealth -= damage;
        UpdateUI();
        audioSource.PlayOneShot(damageSound);

        if (currentHealth <= 0)
        {
            triggerGameOver();
        }
    }

    void triggerGameOver()
    {
        LevelTracker.lastLevelIndex = SceneManager.GetActiveScene().buildIndex;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;
    }

}
