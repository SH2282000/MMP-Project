using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialHandler : MonoBehaviour
{
    
    private int cooldown;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.anyKey && --cooldown <= 0) {
            cooldown = 100;
            SceneManager.LoadScene("Level01");
        }
    }
}
