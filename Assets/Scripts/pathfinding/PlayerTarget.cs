using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerTarget : MonoBehaviour
{
    GameObject target;
    IAstarAI ai;
    Enemy data;

    void OnEnable()
    {
        ai = GetComponent<IAstarAI>();
        data = GetComponent<Enemy>();
        if (ai != null) ai.onSearchPath += Update;
        target = GameObject.Find("Player");
    }

    void OnDisable()
    {
        if (ai != null) ai.onSearchPath -= Update;
    }

    void Update()
    {
        if (data.health() <= 0)
        {
            ai.canMove = false;
            return;
        }
        if (target != null && ai != null) ai.destination = target.transform.position;
    }
}
