using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int nazisPunched;
    public int totalNazis;
    public GameObject exit;
    public float timeLimit;
    public Text timerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLimit -= Time.deltaTime;
        timerText.text = timeLimit.ToString("00");
        if (nazisPunched >= 10)
            if (exit.activeInHierarchy == false)
                exit.SetActive(true);
        if (timeLimit <= 0)
            SceneManager.LoadScene("LoseScreen");
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
