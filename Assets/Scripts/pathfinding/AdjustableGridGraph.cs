using System;
using UnityEngine;
using Pathfinding;
public class AdjustableGridGraph : MonoBehaviour
{
    public AstarPath handler;

    public Canvas canvas;

    private float prevScaleFactor, defaultSize;

    private bool update;

    void Start() {
        this.defaultSize = this.handler.data.gridGraph.nodeSize;
    }

    void Update()
    {
        if(this.canvas.scaleFactor != this.prevScaleFactor) {
            this.prevScaleFactor = this.canvas.scaleFactor;
            GridGraph grid = this.handler.data.gridGraph;
            grid.center = this.transform.position;
            grid.nodeSize = this.defaultSize * this.canvas.scaleFactor; 
            this.handler.Scan(this.handler.graphs);
        }
    }
}
