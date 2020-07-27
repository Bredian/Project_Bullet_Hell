using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public InputMaster inputMaster;
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
            Vector3 pos = Camera.main.ScreenToWorldPoint(Touchscreen.current.position.ReadValue());
            transform.position = new Vector3(pos.x, pos.y, 0f);
        } 
        if(Application.isEditor)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = new Vector3(pos.x, pos.y, 0f);
        } 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
