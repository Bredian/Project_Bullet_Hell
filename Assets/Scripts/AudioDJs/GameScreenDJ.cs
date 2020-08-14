using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreenDJ : MonoBehaviour
{
    // Start is called before the first frame update
    private string currentScene;
    public static GameScreenDJ instance = null;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        currentScene = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScene != SceneManager.GetActiveScene().name)
        {
            Destroy(this.gameObject);
        }
    }
}
