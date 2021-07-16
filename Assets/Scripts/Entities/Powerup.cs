using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float livingTicks = 10;

    void Update()
    {
        this.livingTicks -= Time.deltaTime;
        if (this.livingTicks <= 0)
            Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
