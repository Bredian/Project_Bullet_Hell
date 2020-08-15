using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;
    [SerializeField] private AudioSource zoomOut;
    [SerializeField] private AudioSource zoomIn;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game_Screen")
            zoomIn.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadGame()
    {
        zoomOut.Play();
        ObjectivePoint.score = 0;
        StartCoroutine(LoadLevel("Game_Screen"));
    }
    public void LoadMainMenu()
    {
        ObjectivePoint.score = 0;
        StartCoroutine(LoadLevel("Start_Menu"));
    }
    IEnumerator LoadLevel(string levelName)
    {
        //zoomOut.Play();
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
