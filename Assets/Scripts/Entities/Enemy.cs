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
    public AudioSource enemyDiesSound;
    public AudioSource enemyShootSound;
    public AudioSource enemyHitSound;
    void Awake()
    {
        this.collision = GetComponent<Rigidbody2D>();
    }

    public int health()
    {
        return this.hp;
    }

    public void attack()
    {
        this.attacking = true;
        this.animator.SetTrigger("Attacking");
        enemyShootSound.Play();
    }

    public void takeDamage()
    {
        this.hp--;
        enemyHitSound.Play();
        if (this.hp <= 0)
        {
            this.animator.SetBool("Alive", false);
            enemyDiesSound.Play();
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
            Destroy(this.gameObject);
    }
}
