using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class GameController : MonoBehaviour {

    public float timeLimit;
    public Text timerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        timeLimit -= Time.deltaTime;
        timerText.text = timeLimit.ToString("00");

        if (timeLimit <= 0)
            SceneManager.LoadScene("WinScreen");
    }
}
