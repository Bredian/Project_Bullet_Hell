using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadGame()
    {
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
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
