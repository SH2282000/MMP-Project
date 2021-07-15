using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float livingTicks = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.livingTicks -= Time.deltaTime;
        if(this.livingTicks <= 0)
            Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
