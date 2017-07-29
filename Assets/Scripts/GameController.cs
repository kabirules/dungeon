using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text timerNum;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("STATUS", "ALIVE");
        timerNum.text = "05";
        InvokeRepeating("ReduceTime", 1, 1);
    }

    void ReduceTime()
    {
        if (timerNum.text == "1")
        {
            /* Alert */
            Time.timeScale = 0;
            //winText.text = "game over!!";
            //canvas.SetActive(true);
            PlayerPrefs.SetString("STATUS", "GAMEOVER");
        }

        timerNum.text = (int.Parse(timerNum.text) - 1).ToString();
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
