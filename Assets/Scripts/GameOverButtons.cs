using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip damageSound;
    private void Start()
    {
        audioSource.PlayOneShot(damageSound);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(LevelTracker.lastLevelIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}