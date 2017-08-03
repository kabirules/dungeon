using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void OpenMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
