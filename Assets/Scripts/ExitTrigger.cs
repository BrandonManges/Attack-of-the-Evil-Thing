using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!SurvivalTimer.levelComplete) return;

        LoadNextLevel();
    }
    
    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if(currentScene >= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentScene + 1);
        }
    }
}
