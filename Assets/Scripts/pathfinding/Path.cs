using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private Vector3[] nodes;
    private int currentIndex;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Boolean finished() {
        return this.currentIndex < this.nodes.Length;
    }

    public Vector3 nextNode() {
        return this.nodes[this.currentIndex];
    }
}
