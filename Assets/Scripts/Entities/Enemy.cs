using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy : MonoBehaviour, Entity
{
    //List items;
    private Rigidbody2D collision;
    public Animator animator;
    private bool faceRight = true;
    private int hp = 2;
    private float cooldown;
    private bool attacking = false;
    public float killCount = 0;

    public AudioSource enemyDiesSound;
    public AudioSource enemyShootSound;
    public AudioSource enemyHitSound;

    Points points;

    public LevelHandler levelHandler;

    public AIPath path;

    void Awake()
    {
        this.collision = GetComponent<Rigidbody2D>();
        this.points = GameObject.Find("PointsManager").GetComponent<Points>();
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
        if (this.hp <= 0)
        {
            this.animator.SetBool("Alive", false);
            this.killCount++;
            this.enemyDiesSound.Play();
            this.points.addPoints(this.killCount);
            this.levelHandler.remove(this);
        }
        else
        {
            this.enemyHitSound.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.hp <= 0 || (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<Enemy>().health()<=0))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            return;
        }
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
        AnimatorStateInfo anim = this.animator.GetCurrentAnimatorStateInfo(0);
        if (this.health() > 0)
        {
            this.cooldown -= Time.deltaTime;
            if (this.path.hasPath)
                this.animator.SetBool("Moving", true);
            else
            {
                this.animator.SetBool("Moving", false);
            }
            if (this.path.desiredVelocity.x > 0 && !this.faceRight)
            {
                this.faceRight = true;
                Vector3 scale = this.transform.localScale;
                scale.x *= -1;
                this.transform.localScale = scale;
            }
            else if (this.path.desiredVelocity.x < 0 && this.faceRight)
            {
                this.faceRight = false;
                Vector3 scale = this.transform.localScale;
                scale.x *= -1;
                this.transform.localScale = scale;
            }
        }
        if (anim.IsName("dead") && anim.normalizedTime > 1)
            Destroy(this.gameObject);
    }
}
