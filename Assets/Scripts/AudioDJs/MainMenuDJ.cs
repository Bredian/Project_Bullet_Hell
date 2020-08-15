using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDJ : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<AudioSource> mainMenuThemes;
    private int currentTheme;
    private int lastTheme;
    void Start()
    {
        currentTheme = Random.Range(0, mainMenuThemes.Count);
        lastTheme = currentTheme;
        mainMenuThemes[currentTheme].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!mainMenuThemes[currentTheme].isPlaying)
        {
            do
            {
                currentTheme = Random.Range(0, mainMenuThemes.Count);
            } while(lastTheme == currentTheme);
            lastTheme = currentTheme;
            mainMenuThemes[currentTheme].Play();
        }
    }
}
