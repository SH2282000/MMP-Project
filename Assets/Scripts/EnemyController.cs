using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    public Camera cameraRef;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        this.enemy.move(horizontal, vertical);
        /*if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            enemy.shoot(cameraRef.ScreenToWorldPoint(mousePos) - enemy.transform.position);
        }*/
    }
}
