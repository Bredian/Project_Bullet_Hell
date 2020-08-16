using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerOldMovement : MonoBehaviour
{
    //Radius around tapPosition where you need stop moving
    [SerializeField] private float deltaRadius;
    [SerializeField] private PlayerDeath playerDeath;
    [SerializeField] private AudioSource step;
    //New Input Systems Actions called InputMaster
    //Move flag
    private bool moving = false;
    //Rotate hero flag
    private bool needRotation = false;
    //Position where you tapped
    private Vector3 tapPosition;
    //Speed magnitude
    public float speed = 2;
    private float transitionTime = 1f;
    private bool beenPaused = false;
    private Camera mainCamera;
    private Vector3 prevPosition;
    void Awake()
    {
        mainCamera = Camera.main;
        step.mute = false;
        tapPosition = transform.position;
        prevPosition = tapPosition;
        //InputMaster init: creating instance of InputMaster and enabling it

        //Connecting Move function when action Movement performed
    }
    void Move()
    {
        //Getting tapPosition from Touchscreen class if on Mobile platform
        if(Application.isMobilePlatform)
        {
            //Touchscreen.current.position is Vector2Control for some reason, you need to cast ReadValue() to get Vector2 from it.
                SetMovement(mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position));
        } 
        //Getting tapPosition from Mouse class in Editor
        else
        {
            //Mouse.current.position is Vector2Control for some reason, you need to cast ReadValue() to get Vector2 from it.
            Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            SetMovement(mainCamera.ScreenToWorldPoint(vector));
        } 
    }
    void SetMovement(Vector3 position)
    {
        if(transitionTime <= 0)
        {
            tapPosition = position;
            if((tapPosition - prevPosition).magnitude > 2.5f * deltaRadius)
            {
                //Flattening tapPosition
            tapPosition = new Vector3(tapPosition.x, tapPosition.y, 0f);
           //Rising flags
            moving = true;
            needRotation = true;
            prevPosition = tapPosition;    
            }
            else
            {
                tapPosition = prevPosition;
                moving = false;
                needRotation = false;
            }
        }
    }
    void Update()
    {
        if(transitionTime > 0)
        {
            transitionTime -= Time.deltaTime;
        }
        else
        {
            transitionTime = 0;
        }
        if((Input.touchCount > 0 || Input.GetMouseButtonDown(0)) && !PlayerDeath.dead)
        {
            Move();
        }
        //Getting direction
        Vector3 direction = tapPosition - transform.position;
        //Rotating when needRotation flag is rised
        if(needRotation)
        {
            transform.Rotate(0f, 0f, Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg);
            needRotation = false;
        }
        //Moving in direction with our speed until we in deltaRadius from tapPosition
        if(moving && !PauseMenu.paused && !beenPaused)
        {
            transform.position += Vector3.Normalize(direction) * speed * Time.deltaTime;
            if(!step.isPlaying)
                step.Play();
        }
        if(beenPaused && moving)
        {
            needRotation = false;
            moving = false;
            beenPaused = false;
        }
        if(direction.magnitude <= deltaRadius)
        {
            moving = false;
            step.Stop();  
        }
        if(PauseMenu.paused)
        {
            beenPaused = true;
            step.Stop();
        }
    }
}
