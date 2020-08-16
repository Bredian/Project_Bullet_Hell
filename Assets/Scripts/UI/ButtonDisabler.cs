using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisabler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button button;
    [SerializeField] private float disableTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(disableTime > 0)
        {
            disableTime -= Time.deltaTime;
            button.interactable = false;
        }
        if(disableTime <= 0)
        {
            disableTime = 0;
            button.interactable = true;
        }

    }
}
