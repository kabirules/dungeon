using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text timerNum;
    public Text gameOverText;
    public Button tryAgainButton;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("STATUS", "ALIVE");
        timerNum.text = "05";
        InvokeRepeating("ReduceTime", 1, 1);
        tryAgainButton.gameObject.SetActive(false);
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
            gameOverText.text ="Time is over!You loose!";
            tryAgainButton.gameObject.SetActive(true);
        }

        timerNum.text = (int.Parse(timerNum.text) - 1).ToString();
    }

    // Update is called once per frame
    void Update () {
	    
	}

    public void OpenHomeScene()
    {
        SceneManager.LoadScene("Home");
    }
}
