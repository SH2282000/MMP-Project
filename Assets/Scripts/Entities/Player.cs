using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour, Entity
{
    //List items;

    private Rigidbody2D collision;
    public Animator animator;
    private bool faceRight = true;
    private int hp = 3;

    

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
    }

    public void shoot() {

    }

    public void takeDamage() {
        this.hp--;
        if(this.hp <= 0) {
            //Game Over
        }
    }
}