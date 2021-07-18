using UnityEngine;
using Pathfinding;

public class PlayerTarget : MonoBehaviour
{
    Player target;
    IAstarAI ai;
    Enemy data;

    void OnEnable()
    {
        ai = GetComponent<IAstarAI>();
        data = GetComponent<Enemy>();
        if (ai != null) ai.onSearchPath += Update;
        target = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnDisable()
    {
        if (ai != null) ai.onSearchPath -= Update;
    }

    void Update()
    {
        if (data.health() <= 0 || target == null || target.health() <= 0)
        {
            ai.canMove = false;
            return;
        }
        if (target != null && ai != null) ai.destination = target.transform.position;
    }
}
