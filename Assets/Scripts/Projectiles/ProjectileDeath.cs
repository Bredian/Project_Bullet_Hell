using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Collider2D projectileCollider;
    public bool dead = false;
    public static int projectileCount = 0;
    void Start()
    {
        projectileCount++;
    }
    public void Death()
    {
        if(!dead)
        {
            
            dead = true;
            explosion.Play();
            //Making it "invisible" that way will not cause problems with OnBecomeInvisible() function
            sprite.color = new Color(0,0,0,0);
            projectileCollider.enabled = false;
        }
    }
    void LateUpdate()
    {
        if(!explosion.isPlaying && dead)
        {
            Destroy(this.gameObject);
        }
    }
    void OnBecameInvisible()
    {
        projectileCount--;
        Destroy(this.gameObject);
    }
}
