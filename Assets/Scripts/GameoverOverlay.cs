using System;
using UnityEngine;

public class GameoverOverlay : MonoBehaviour
{
    private float startY;
    private int tick;
    
    void Start()
    {
        this.startY = this.transform.position.y;
    }

    void Update()
    {
        this.tick++;
        float y = (float)Math.Sin(this.tick * 0.02) * 3;
        Vector3 newPos = new Vector3(this.transform.position.x, this.startY + y, this.transform.position.z);
        this.transform.position = newPos;
    }
}
