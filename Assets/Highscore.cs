using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text highscoreText;
    public GameObject points;
    private Points pointsSrc;
    private string highscorePoints = "0";

    void Start()
    {
        points = GameObject.Find("PointsManager");
        pointsSrc = points.GetComponent<Points>();
    }

    // Update is called once per frame
    void Update()
    {
        highscorePoints = pointsSrc.pointStatus.ToString();
        highscoreText.text = string.Format("Highscore: {0:000}", highscorePoints);

    }
}
