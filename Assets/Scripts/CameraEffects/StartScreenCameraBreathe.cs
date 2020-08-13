using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenCameraBreathe : MonoBehaviour
{
    [SerializeField] private Camera breatheCamera;
    [SerializeField] private float breatheMagnitude;
    [SerializeField] private float breathePeriod;
    [SerializeField]private float initialOrthographicSize;
    void Start()
    {
        //initialOrthographicSize = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        breatheCamera.transform.Rotate(0f, 0f, Mathf.Sin(Time.time/breathePeriod) * breatheMagnitude);
        //breatheCamera.orthographicSize = initialOrthographicSize + Mathf.Sin(Time.time/breathePeriod) * breatheMagnitude;
    }
}
