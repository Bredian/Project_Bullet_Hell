using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private ObjectivePoint objective;
    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        objective.OnScoreChange.AddListener((score) =>
        {
            text.text = ObjectivePoint.score.ToString();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
