using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLevelExit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        LoadNextLevel();
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(0);
    }
}