using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" && !PlayerDeath.dead)
        {
            col.gameObject.GetComponent<PlayerOldMovement>().speed = 0;
            col.gameObject.GetComponent<PlayerDeath>().Death();
        }
    }

}
