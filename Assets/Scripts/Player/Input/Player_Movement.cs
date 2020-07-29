using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    //Radius around tapPosition where you need stop moving
    [SerializeField] private float deltaRadius;
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
    void Awake()
    {
        //InputMaster init: creating instance of InputMaster and enabling it
        inputMaster = new InputMaster();
        inputMaster.Enable();
        //Connecting Move function when action Movement performed
        inputMaster.Player.Movement.performed += context => Move();
    }
    void Move()
    {
        //Getting tapPosition from Touchscreen class if on Mobile platform
        if(Application.isMobilePlatform)
        {
            //Touchscreen.current.position is Vector2Control for some reason, you need to cast ReadValue() to get Vector2 from it.
            SetMovement(Camera.main.ScreenToWorldPoint(Touchscreen.current.position.ReadValue()));
        } 
        //Getting tapPosition from Mouse class in Editor
        if(Application.isEditor)
        {
            //Mouse.current.position is Vector2Control for some reason, you need to cast ReadValue() to get Vector2 from it.
            SetMovement(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        } 
    }
    void SetMovement(Vector3 position)
    {
        tapPosition = position;
        //Flattening tapPosition
        tapPosition = new Vector3(tapPosition.x, tapPosition.y, 0f)
;       //Rising flags
        moving = true;
        needRotation = true;
    }
    void Update()
    {
        //Getting direction
        Vector3 direction = tapPosition - transform.position;
        //Rotating when needRotation flag is rised
        if(needRotation)
        {
            transform.Rotate(0f, 0f, Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg);
            needRotation = false;
        }
        //Moving in direction with our speed until we in deltaRadius from tapPosition
        if(moving)
            transform.position += Vector3.Normalize(direction) * speed * Time.deltaTime;
        if(direction.magnitude <= deltaRadius)
            moving = false;  
    }
}
