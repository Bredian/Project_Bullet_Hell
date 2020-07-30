using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileKrak : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] kraks;
    [SerializeField] private float lifetime = 5f;
    private Transform player;
    private bool dead = false;
    [SerializeField] private ParticleSystem shatterEffect;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Transform[] krakSpawnPositions;
    [SerializeField] private float angle;   
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
        //transform.Rotate(0, 0, angle * Time.deltaTime);
        transform.position += dir.normalized * speed * Time.deltaTime;
        if(lifetime <= 0)
        {
            if(!dead)
                Death();
            if(!shatterEffect.isPlaying && dead)
            {
                Destroy(this.gameObject);
            }
        }
    }
        public void Death()
    {
        dead = true;
        speed = 0;
        sprite.enabled = false;
        for(int i = 0; i < kraks.Length; i++)
        {
           Instantiate(kraks[i], krakSpawnPositions[i].position, kraks[i].transform.rotation * transform.rotation);
        }
        shatterEffect.Play();
    }
 }
