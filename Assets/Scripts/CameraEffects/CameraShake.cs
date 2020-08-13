using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Desired duration of the shake effect
    private static float shakeDuration = 0f;
    [SerializeField] private static float desiredShakeDuration = 0.4f;
    // A measure of magnitude for the shake. Tweak based on your preference
    [SerializeField] private float shakeMagnitude = 0.7f;
 
    // A measure of how quickly the shake effect should evaporate
    [SerializeField] private float dampingSpeed = 1.0f;
 
    // The initial position of the GameObject
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
   
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
    public static void TriggerShake()
    {
        shakeDuration = desiredShakeDuration;
    }
}
