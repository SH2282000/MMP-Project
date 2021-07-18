using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingOverlaySettings : MonoBehaviour
{
    private float startY;
    private int tick;

    // Start is called before the first frame update
    void Start()
    {
        this.startY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.tick++;
        float y = (float)Math.Sin(this.tick * 0.02) * 3;
        Vector3 newPos = new Vector3(this.transform.position.x, this.startY + y, this.transform.position.z);
        this.transform.position = newPos;

    }
}
