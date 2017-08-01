using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text timerNum;
    public Text infoText;
    public Button tryAgainButton;
    public Button homeButton;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        timerNum.text = "60";
        InvokeRepeating("ReduceTime", 1, 1);
    }

    void ReduceTime()
    {
        if (PlayerPrefs.GetString("STATUS").Equals("ALIVE"))
        {             if (timerNum.text == "1")
            {
                /* Alert */
                Time.timeScale = 0;
                PlayerPrefs.SetString("STATUS", "GAMEOVER");
            }
        timerNum.text = (int.Parse(timerNum.text) - 1).ToString();
        }
    }

    // Update is called once per frame
    void Update () {
	    
	}

    public void OpenHomeScene()
    {
        SceneManager.LoadScene("Home");
    }

    public void OpenMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
