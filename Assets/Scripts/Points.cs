using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public float pointStatus = 0;

    public Text pointsText;
    private float killFactor = 10;

    GameObject enemyObject;
    Enemy enemy;

    void Start()
    {
        enemyObject = GameObject.Find("Bot");
        enemy = enemyObject.GetComponent<Enemy>();
        pointStatus = enemy.killCount;
    }

    void Update()
    {
        pointStatus = enemy.killCount * killFactor;
        DisplayPoints(pointStatus);
    }

    void DisplayPoints(float currPoints)
    {
        if (currPoints < 0)
        {
            currPoints = 0;
        }

        pointsText.text = string.Format("{0:0} points", currPoints);
    }
}
