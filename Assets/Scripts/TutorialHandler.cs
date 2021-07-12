using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialHandler : MonoBehaviour
{
    // Start is called before the first frame update
    
    private int cooldown;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey && --cooldown <= 0) {
            cooldown = 100;
            SceneManager.LoadScene("Level01");
        }
    }
}
