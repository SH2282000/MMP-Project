using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text highscoreText;
    public Points pointsSrc;
    private string highscorePoints = "0";

    void Update()
    {
        highscorePoints = pointsSrc.pointStatus.ToString();
        highscoreText.text = string.Format("Highscore: {0:000}", highscorePoints);

    }
}