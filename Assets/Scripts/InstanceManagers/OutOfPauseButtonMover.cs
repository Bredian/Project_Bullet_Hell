using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfPauseButtonMover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float pushAmmount = -0.9f;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<ObjectivePoint>() != null)
        {
            col.gameObject.transform.position = new Vector3(col.gameObject.transform.position.x + pushAmmount, col.gameObject.transform.position.y, col.gameObject.transform.position.z);
        }
    }
}
