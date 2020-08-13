using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestText;
    // Start is called before the first frame update
    void Start()
    {
        bestText.text = "Best: " + SaveHighScore.LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
