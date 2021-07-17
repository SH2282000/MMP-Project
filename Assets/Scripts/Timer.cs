using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeValue = 90;
    public Text timeText;
    public GameObject youWon;

    public Player player;

    // blink comps
    private Color initColor;
    private bool transparentText = false;

    private void Start()
    {
        initColor = timeText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player.health() <= 0)
            return;
        // counts seconds down
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            this.youWon.SetActive(true);
            Destroy(this.player.gameObject);
        }

        DisplayTime(timeValue);

        /* Doesnt work until now - Blinks timer
        if (timeValue < 10) {
            StartCoroutine("Blink");
        }
        */
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator Blink()
    {
        while (true)
        {
            if (!transparentText)
            {
                timeText.color = new Color(initColor.r, initColor.g, initColor.b, 0);
                transparentText = true;
            }
            else
            {
                timeText.color = new Color(initColor.r, initColor.g, initColor.b, 1);
                transparentText = false;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
