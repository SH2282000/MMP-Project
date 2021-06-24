using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour, Entity
{
    //List items;

    private Rigidbody2D collision;
    public Animator animator;
    private bool faceRight = true;

    void Awake() {
        this.collision = GetComponent<Rigidbody2D>();
    }

    int hp;

    public int health() {
        return this.hp;
    }

    public void move(float horizontal, float vertical) {
        horizontal *= 10f;
        vertical *= 10f;
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
}