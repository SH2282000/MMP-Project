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

    public void addPoints(float kill)
    {
        pointStatus += kill * killFactor;
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
