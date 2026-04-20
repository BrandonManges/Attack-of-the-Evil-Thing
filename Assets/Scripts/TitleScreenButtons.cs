using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreenButtons : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 1f;
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
