using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    //Radius around tapPosition where you need stop moving
    [SerializeField] private float deltaRadius;
    [SerializeField] private PlayerDeath playerDeath;
    [SerializeField] private AudioSource step;
    //New Input Systems Actions called InputMaster
    private InputMaster inputMaster;
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
    private Touchscreen touchscreen = null;
    private Mouse mouse = null;
    void Awake()
    {
        if(Application.isMobilePlatform)
            touchscreen = Touchscreen.current;
        if(Application.isEditor)
            mouse = Mouse.current;
        mainCamera = Camera.main;
        step.mute = false;
        tapPosition = transform.position;
        //InputMaster init: creating instance of InputMaster and enabling it
        inputMaster = new InputMaster();
        inputMaster.Enable();
        //Connecting Move function when action Movement performed
        inputMaster.Player.Movement.performed += context => Move();
        playerDeath.OnPlayerDeath.AddListener((dead) =>
        {
            inputMaster.Disable();
        });
    }
    void Move()
    {
        //Getting tapPosition from Touchscreen class if on Mobile platform
        if(Application.isMobilePlatform)
        {
            //Touchscreen.current.position is Vector2Control for some reason, you need to cast ReadValue() to get Vector2 from it.
            SetMovement(mainCamera.ScreenToWorldPoint(touchscreen.position.ReadValue()));
        } 
        //Getting tapPosition from Mouse class in Editor
        if(Application.isEditor)
        {
            //Mouse.current.position is Vector2Control for some reason, you need to cast ReadValue() to get Vector2 from it.
            SetMovement(mainCamera.ScreenToWorldPoint(touchscreen.position.ReadValue()));
        } 
    }
    void SetMovement(Vector3 position)
    {
        if(transitionTime <= 0)
        {
            tapPosition = position;
            //Flattening tapPosition
            tapPosition = new Vector3(tapPosition.x, tapPosition.y, 0f);
           //Rising flags
            moving = true;
            needRotation = true;
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
