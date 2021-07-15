using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour, Entity
{
    //List items;

    private Rigidbody2D collision;
    public Animator animator;
    private bool faceRight = true;
    private int hp = 3;
    private float cooldown;
    private bool attacking = false;
    public Base_Bullet base_bullet;

    void Awake() {
        this.collision = GetComponent<Rigidbody2D>();
    }

    public int health() {
        return this.hp;
    }

    public void move(float horizontal, float vertical) {
        horizontal *= 100f;
        vertical *= 100f;
        this.animator.SetBool("Moving", horizontal != 0 || vertical != 0);
        this.collision.velocity = new Vector2(horizontal, vertical);
        if(horizontal > 0 && !this.faceRight) {
            this.faceRight = true;
            Vector3 scale = this.transform.localScale;
            scale.x *= -1;
            this.transform.localScale = scale;
        } else if(horizontal < 0 && this.faceRight) {
            this.faceRight = false;
            Vector3 scale = this.transform.localScale;
            scale.x *= -1;
            this.transform.localScale = scale;
        }
        //Debug.Log(this.collision.velocity);
    }

    public void shoot(Vector3 dir) {
        if(this.cooldown <= 0) {
            Base_Bullet bullet = Instantiate(base_bullet);
            bullet.tag = "Bullet";
            Vector2 dir2 = new Vector2(dir.x, dir.y);
            bullet.setMotion(dir2);
            bullet.transform.position = new Vector3(this.transform.position.x + bullet.motion.x * 0.1f, this.transform.position.y + bullet.motion.y * 0.1f, -5);
            Destroy(bullet.self, 5);
            this.cooldown = 1;
        }
    }

    public void attack()
    {
        this.attacking = true;
        this.animator.SetBool("Attacking", true);
    }

    public void takeDamage() {
        this.hp--;
        if(this.hp <= 0) {
            this.animator.SetBool("Alive", false);
            //Destroy(this.self);

            //Game Over
        }
    }

    void Update() {
        this.cooldown -= Time.deltaTime;    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.takeDamage();
        }
    }
}