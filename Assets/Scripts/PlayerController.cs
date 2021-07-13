using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;
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
        this.player.move(horizontal, vertical);
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos = Input.mousePosition;
            player.shoot(cameraRef.ScreenToWorldPoint(mousePos) - player.transform.position);
        }
    }
}
