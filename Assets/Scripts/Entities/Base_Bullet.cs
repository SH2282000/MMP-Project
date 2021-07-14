using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class Base_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D collision;
    public Vector2 motion;
    public int livingTimeMax = 5;

    public GameObject self;

    void Start()
    {
        
    }

    void Awake() {
        this.collision = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.collision.velocity = this.motion;
    }

    public void setMotion(Vector2 motion) {
        motion = motion.normalized;
        motion = new Vector2(motion.x * 100, motion.y * 100);
        this.motion = motion;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedWalls")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else Destroy(this.self);
    }
}
