using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {

    public Text infoText;
    public Button tryAgainButton;
    public Button homeButton;

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetString("STATUS", "ALIVE");
        tryAgainButton.gameObject.SetActive(false);
        homeButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetString("STATUS").Equals("ALIVE")) {
            //Do nothing
        }
        if (PlayerPrefs.GetString("STATUS").Equals("GAMEOVER"))
        {
            // You loose!
            infoText.text = "Time is over! You loose!";
            tryAgainButton.gameObject.SetActive(true);
            homeButton.gameObject.SetActive(true);
            //Kill the player
            gameObject.SetActive(false);

        }
        if (PlayerPrefs.GetString("STATUS").Equals("EXIT"))
        {
            //You won!
            infoText.text = "You've found the exit!";
            tryAgainButton.gameObject.SetActive(true);
            homeButton.gameObject.SetActive(true);
        }

    }
}
