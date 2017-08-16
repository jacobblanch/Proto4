using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int nazisPunched;
    public int totalNazis;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (nazisPunched >= 10)
            Debug.Log("Winner");
	}
}
