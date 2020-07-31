using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private ProjectileDeath projectileDeath;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        lifetime = lifetime - Time.deltaTime;
        if(player == null)
        {
            player = transform;
        }
        Vector3 dir = player.position - transform.position;
        float angle = -Mathf.Atan2(dir.x,dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position += dir.normalized * speed * Time.deltaTime;

        if(lifetime <= 0)
        {
            projectileDeath.Death();
        }
    }
}
