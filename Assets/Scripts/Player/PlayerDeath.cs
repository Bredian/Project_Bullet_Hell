﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Collider2D playerCollider;
    public static bool dead = false;
    void Start()
    {
        gameObject.tag = "Player";
    }
    public void Death()
    {
        playerCollider.enabled = false;
        if(!dead)
        {
            Debug.Log("Been here");
            gameObject.tag = "Untagged";
            dead = true;
            sprite.enabled = false;
            explosion.Play();
        }
    }
    void Update()
    {
        
        if(!explosion.isPlaying && dead)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
