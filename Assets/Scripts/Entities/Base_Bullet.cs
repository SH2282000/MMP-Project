using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        motion = new Vector2(motion.x * 50, motion.y * 50);
        this.motion = motion;
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.self);
    }
}
