using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class Base_Bullet : MonoBehaviour
{
    private Rigidbody2D collision;
    public Vector2 motion;
    public int livingTimeMax = 5;

    void Awake()
    {
        this.collision = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.collision.velocity = this.motion;
    }

    public void setMotion(Vector2 motion)
    {
        motion = motion.normalized;
        motion = new Vector2(motion.x * 100, motion.y * 100);
        this.motion = motion;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedWalls" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else Destroy(this.gameObject);
    }
}
