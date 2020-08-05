using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Collider2D playerCollider;
    private bool dead = false;
    public void Death()
    {
        if(!dead)
        {
            dead = true;
            sprite.enabled = false;
            playerCollider.enabled = false;
            explosion.Play();
        }
    }
    void Update()
    {
        if(!explosion.isPlaying && dead)
        {
            Destroy(this.gameObject);
        }
    }
}
