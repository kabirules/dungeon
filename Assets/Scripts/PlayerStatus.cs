using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetString("STATUS").Equals("ALIVE")) {
            //Do nothing
        }
        if (PlayerPrefs.GetString("STATUS").Equals("GAMEOVER"))
        {
            //Kill the player
            gameObject.SetActive(false);
        }

    }
}
