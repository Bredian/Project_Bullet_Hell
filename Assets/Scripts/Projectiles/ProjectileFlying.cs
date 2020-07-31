using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFlying : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed = 2f;
    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    // Update is called once per frame
}
