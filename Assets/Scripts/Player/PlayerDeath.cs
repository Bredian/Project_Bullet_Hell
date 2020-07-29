using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private SpriteRenderer sprite;
    private bool dead = false;
    public void Death()
    {
        dead = true;
        sprite.enabled = false;
        explosion.Play();
    }
    void Update()
    {
        if(!explosion.isPlaying && dead)
        {
            Destroy(this.gameObject);
        }
    }
}
