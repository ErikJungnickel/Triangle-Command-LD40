using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{    
    public float speed = 10;

    public delegate void EnemyHitEvent();
    public event EnemyHitEvent OnEnemyHit;

    public delegate void WallHitEvent();
    public event WallHitEvent OnWallHit;

    void Start()
    {
    }

    void Update()
    {
        this.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            if (OnEnemyHit != null)
            {
                OnEnemyHit();
            }
                    
        }
        else
        {
            OnWallHit();
        }

        Destroy(this.gameObject);
      
    }
}
