using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileKrak : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] kraks;
    [SerializeField] private float lifetime = 5f;
    private Transform player;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Transform[] krakSpawnPositions;
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
        transform.position += dir.normalized * speed * Time.deltaTime;
        if(lifetime <= 0)
        {
            if(!projectileDeath.dead)
            {
                for(int i = 0; i < kraks.Length; i++)
                {
                    Instantiate(kraks[i], krakSpawnPositions[i].position, transform.rotation * kraks[i].transform.rotation);
                }
            }  
            projectileDeath.Death();
        }
    }
 }
