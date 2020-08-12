using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool paused = false;
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private Button pauseButton; 
    [SerializeField] private PlayerDeath playerDeath;
    [SerializeField] private Canvas gameOverMenu;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI bestText;
    public void Pause()
    {
        if(!paused)
        {
            paused = true;
            Time.timeScale = 0f;
            pauseButton.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
            return;
        }
        if(paused)
        {
            paused = false;
            Time.timeScale = 1f;
            pauseButton.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
            return;
        }
    }
    // Update is called once per frame
    void Start()
    {
        PlayerDeath.dead = false;
        player.SetActive(true);
        playerDeath.OnPlayerDeath.AddListener((dead) =>
        {
            if(ObjectivePoint.score > SaveHighScore.LoadScore())
            {
                SaveHighScore.SaveScore();
            }
            CameraShake.TriggerShake();
            bestText.text = "Best: " + SaveHighScore.LoadScore();
            pauseButton.gameObject.SetActive(false);
            gameOverMenu.gameObject.SetActive(true);
            
        });
    }
    public void Quit()
    {
        ObjectivePoint.score = 0;
        Application.Quit();
    }
    public void Restart()
    {
        ObjectivePoint.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        
    }
}
