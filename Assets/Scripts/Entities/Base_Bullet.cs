using UnityEngine;

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

    public void setMotion(Vector2 mot)
    {
        mot = mot.normalized;
        mot = new Vector2(mot.x * 100, mot.y * 100);
        this.motion = mot;
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
