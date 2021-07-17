using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingOverlayReturn : MonoBehaviour
{
    private float startY;
    private int tick;
    private float returnDelay = 5;

    public GameObject returnText;

    void Start()
    {
        this.startY = this.transform.position.y;
    }

    void Update()
    {
        this.returnDelay -= Time.deltaTime;
        this.tick++;
        float y = (float)Math.Sin(this.tick * 0.02) * 3;
        Vector3 newPos = new Vector3(this.transform.position.x, this.startY + y, this.transform.position.z);
        this.transform.position = newPos;
        this.transform.position = newPos;
        if(this.returnDelay <= 0) {
            if(!this.returnText.activeSelf)
                this.returnText.SetActive(true);
            if(Input.GetMouseButtonDown(0))
                SceneManager.LoadScene("MainMenu");
        }
    }
}
