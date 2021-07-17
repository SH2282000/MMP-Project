using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class LevelHandler : MonoBehaviour
{
    public GameObject[] spawnLocations, powerUpLocations;

    public Enemy bot, muddy;

    public GameObject power, speed;

    private float delay, powerUpDelay;

    private int spawnedEnemies;

    private List<Enemy> enemies = new List<Enemy>(), toRemove = new List<Enemy>();

    public Player player;

    public void remove(Enemy enemy)
    {
        this.toRemove.Add(enemy);
    }

    void Update()
    {
        foreach (Enemy e in this.toRemove)
        {
            this.enemies.Remove(e);
        }
        this.toRemove.Clear();
        if (this.player.health() <= 0 || this.enemies.Count > 5)
            return;
        if (this.delay > 0 && this.enemies.Count != 0)
        {
            this.delay -= Time.deltaTime;
        }
        else
        {
            int amount = Random.Range(1, 4);

            for (int i = 0; i < amount; i++)
            {
                int loc = Random.Range(0, this.spawnLocations.Length);
                int type = Random.Range(0, 7);
                GameObject location = this.spawnLocations[loc];
                Enemy enemy;
                if (type < 3)
                    enemy = Instantiate(muddy);
                else
                    enemy = Instantiate(bot);
                enemy.levelHandler = this;
                enemy.transform.position = new Vector3(location.transform.position.x + Random.Range(-2.1f, 2.1f), location.transform.position.y + Random.Range(-2.1f, 2.1f), location.transform.position.z);
                enemy.transform.parent = this.transform.parent;
                this.spawnedEnemies++;
                this.enemies.Add(enemy);
            }
            this.delay = Random.Range(5, 10);

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
            this.powerUpDelay = Random.Range(7, 25);
        }
    }
}
