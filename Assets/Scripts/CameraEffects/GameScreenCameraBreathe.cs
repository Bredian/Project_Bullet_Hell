using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreenCameraBreathe : MonoBehaviour
{
    [SerializeField] private Camera breatheCamera;
    private float breatheMagnitude;
    [SerializeField] private float breathePeriod;
    [SerializeField] private float initialOrthographicSize;
    void Start()
    {
        //initialOrthographicSize = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        breatheMagnitude = 0.05f * ObjectivePoint.score / SaveHighScore.LoadScore();
        breatheCamera.transform.Rotate(0f, 0f, Mathf.Sin(Time.time/breathePeriod) * breatheMagnitude);
    }
}
