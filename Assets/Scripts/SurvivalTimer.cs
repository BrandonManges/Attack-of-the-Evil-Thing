using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SurvivalTimer : MonoBehaviour
{

    [SerializeField] float timeRemaining = 60f;
    [SerializeField] TextMeshProUGUI timerText;
    public static bool levelComplete = false;

    private bool timerRunning = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!timerRunning) { return; }

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            levelComplete = true;
            timerText.text = "EXIT OPEN";
            return;
        }
        timerText.text = "SURVIVE " + Mathf.Ceil(timeRemaining).ToString();
    }


}
