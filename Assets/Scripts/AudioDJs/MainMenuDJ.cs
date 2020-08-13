using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDJ : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<AudioSource> mainMenuThemes;
    private int currentTheme;
    void Start()
    {
        currentTheme = Random.Range(0, mainMenuThemes.Count);
        mainMenuThemes[currentTheme].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!mainMenuThemes[currentTheme].isPlaying)
        {
            currentTheme = Random.Range(0, mainMenuThemes.Count);
            mainMenuThemes[currentTheme].Play();
        }
    }
}
