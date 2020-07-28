using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private InputMaster inputMaster;
    
    private bool moving = false;
    private Vector3 tapPosition;
    [SerializeField] float deltaRadius;
    public float speed = 2;
    void Start()
    {
        
    }
    void Awake()
    {
        inputMaster = new InputMaster();
        inputMaster.Enable();
        inputMaster.Player.Movement.performed += context => Move();
    }
    void Move()
    {
        if(Application.isMobilePlatform)
        {
            tapPosition = Camera.main.ScreenToWorldPoint(Touchscreen.current.position.ReadValue());
            //transform.position = new Vector3(pos.x, pos.y, 0f);
            moving = true;
        } 
        if(Application.isEditor)
        {
            tapPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            //transform.position = new Vector3(pos.x, pos.y, 0f);
            moving = true;
        } 
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(tapPosition.x, tapPosition.y, 0f) - transform.position;
        if(moving)
        {
            transform.position += Vector3.Normalize(direction) * speed * Time.deltaTime;
        }
        if(direction.magnitude <= deltaRadius)
        {
            moving = false;
        }
    }
}
