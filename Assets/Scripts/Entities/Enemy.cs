using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Entity
{
    //List items;
    private Rigidbody2D collision;
    public Animator animator;
    private bool faceRight = true;
    private int hp = 2;
    private float cooldown;
    private bool attacking = false;
    public GameObject self;

    void Awake()
    {
        this.collision = GetComponent<Rigidbody2D>();
    }

    public int health()
    {
        return this.hp;
    }

    public void move(float horizontal, float vertical)
    {
        horizontal *= 100f;
        vertical *= 100f;
        this.animator.SetBool("Moving", horizontal != 0 || vertical != 0);
        this.collision.velocity = new Vector2(horizontal, vertical);
        if (horizontal > 0 && !this.faceRight)
        {
            this.faceRight = true;
            Vector3 scale = this.transform.localScale;
            scale.x *= -1;
            this.transform.localScale = scale;
        }
        else if (horizontal < 0 && this.faceRight)
        {
            this.faceRight = false;
            Vector3 scale = this.transform.localScale;
            scale.x *= -1;
            this.transform.localScale = scale;
        }
        //Debug.Log(this.collision.velocity);
    }

    public void attack()
    {
        this.attacking = true;
        this.animator.SetTrigger("Attacking");
    }

    public void takeDamage()
    {
        this.hp--;
        if (this.hp <= 0)
        {
            this.animator.SetBool("Alive", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("enemy touched");
            this.takeDamage();
        }
        if (collision.gameObject.tag == "Player")
        {
            this.attack();
        }
    }

    void Update()
    {
        this.cooldown -= Time.deltaTime;
        AnimatorStateInfo anim = this.animator.GetCurrentAnimatorStateInfo(0);
        if(anim.IsName("dead") && anim.normalizedTime > 1)
            Destroy(this.self);
    }
}
