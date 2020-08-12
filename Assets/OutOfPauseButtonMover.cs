using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfPauseButtonMover : MonoBehaviour
{
    // Start is called before the first frame update
    void OnColliderEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<ObjectivePoint>() != null)
        {
            col.gameObject.transform.position = new Vector3(col.gameObject.transform.position.x - 0.9f, col.gameObject.transform.position.y, col.gameObject.transform.position.z);
        }
    }
}
