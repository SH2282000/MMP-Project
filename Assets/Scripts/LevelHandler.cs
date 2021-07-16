using System.Threading;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] spawnLocations, powerUpLocations;

    public Enemy bot, muddy;

    public GameObject power, speed;

    private float delay, powerUpDelay;

    private int spawnedEnemies;

    // Update is called once per frame
    void Update()
    {
        if (this.delay > 0)
        {
            this.delay -= Time.deltaTime;
        }
        else
        {
            int amount = Random.Range(1, 4);
            
            for (int i = 0; i < amount; i++)
            {
                int loc = Random.Range(0, this.spawnLocations.Length);
                int type = Random.Range(0, 2);
                GameObject location = this.spawnLocations[loc];
                Enemy enemy;
                if (type == 0)
                    enemy = Instantiate(bot);
                else
                    enemy = Instantiate(muddy);

                enemy.transform.position = new Vector3(location.transform.position.x + Random.Range(-2.1f, 2.1f), location.transform.position.y + Random.Range(-2.1f, 2.1f), location.transform.position.z);
                this.spawnedEnemies++;
            }
            this.delay = Random.Range(10, 25);

        }
        if (this.powerUpDelay > 0)
        {
            this.powerUpDelay -= Time.deltaTime;
        }
        else
        {
            int loc = Random.Range(0, this.powerUpLocations.Length);
            int type = Random.Range(0, 2);
            GameObject location = this.powerUpLocations[loc];
            GameObject powerup;
            if (type == 0)
                powerup = Instantiate(power);
            else
                powerup = Instantiate(speed);
            powerup.transform.position = new Vector3(location.transform.position.x, location.transform.position.y, location.transform.position.z);
            this.powerUpDelay = Random.Range(10, 25);
        }
    }
}
