using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    public UnityEvent<bool> OnPlayerDeath;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private AudioSource explosionSound;
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
            OnPlayerDeath.Invoke(dead);
            sprite.enabled = false;
            explosion.Play();
            explosionSound.Play();
        }
    }
    void Update()
    {
        
        if(!explosion.isPlaying && dead)
        {
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}
