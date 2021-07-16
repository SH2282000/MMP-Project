using System;
using System.Threading;
using UnityEngine;
public class Player : MonoBehaviour, Entity
{
    private Rigidbody2D collision;
    public Animator animator;
    private bool faceRight = true;
    private int hp = 3;
    private float cooldown, invulnerableTime, speedTime, powerTime;
    private bool attacking = false;
    public Base_Bullet base_bullet;
    //private AudioSource getshotAudio;
    public AudioSource playerHurtSound;
    public AudioSource playerShootSound;
    public AudioSource playerDiesSound;
    public GameObject[] hearts;
    public GameObject gameOver, speedObj, powerObj;

    void Awake()
    {
        this.collision = GetComponent<Rigidbody2D>();
        //this.getshotAudio = GetComponent<AudioSource>();
    }

    public int health()
    {
        return this.hp;
    }

    public void move(float horizontal, float vertical)
    {
        if (this.health() <= 0)
            return;
        horizontal *= 100f;
        vertical *= 100f;
        if (this.speedTime > 0)
        {
            horizontal *= 1.5f;
            vertical *= 1.5f;
        }
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

    public void shoot(Vector3 dir)
    {
        if (this.cooldown <= 0)
        {
            Base_Bullet bullet = Instantiate(base_bullet);
            Vector2 dir2 = new Vector2(dir.x, dir.y);
            bullet.setMotion(dir2);
            bullet.transform.position = new Vector3(this.transform.position.x + bullet.motion.x * 0.1f, this.transform.position.y + bullet.motion.y * 0.1f, this.transform.position.z);
            Destroy(bullet.gameObject, 5);
            this.cooldown = 1 - (this.powerTime > 0 ? 0.5f : 0);
            playerShootSound.Play();
        }
    }

    public void attack()
    {
        this.attacking = true;
        this.animator.SetTrigger("Attacking");
    }

    public void takeDamage()
    {
        if (this.hp <= 0 || this.invulnerableTime > 0)
            return;
        Debug.Log("Damage player");
        this.hp--;
        this.hearts[this.hp].SetActive(false);
        this.invulnerableTime = 1;
        playerHurtSound.Play();
        if (this.hp <= 0)
        {
            this.animator.SetBool("Alive", false);
            playerDiesSound.Play();
        }
    }

    void Update()
    {
        this.cooldown -= Time.deltaTime;
        this.invulnerableTime -= Time.deltaTime;
        Boolean hasSpeed = this.speedTime > 0;
        Boolean hasPower = this.powerTime > 0;
        this.speedTime -= Time.deltaTime;
        this.powerTime -= Time.deltaTime;
        if (this.speedTime <= 0 && hasSpeed)
            this.speedObj.SetActive(false);
        if (this.powerTime <= 0 && hasPower)
            this.powerObj.SetActive(false);
        AnimatorStateInfo anim = this.animator.GetCurrentAnimatorStateInfo(0);
        if (anim.IsName("dead") && anim.normalizedTime > 1)
        {
            Destroy(this.gameObject);
            this.gameOver.SetActive(true);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.takeDamage();
        }
        if (collision.gameObject.tag == "Power")
        {
            this.powerObj.SetActive(true);
            this.powerTime = 10;
        }
        if (collision.gameObject.tag == "Speed")
        {
            this.speedObj.SetActive(true);
            this.speedTime = 10;
        }
    }
}