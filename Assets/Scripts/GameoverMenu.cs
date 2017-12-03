using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverMenu : MonoBehaviour {

    public BoolValue gameover;
    public GameObject gameoverPnl;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameover.Value && !gameoverPnl.activeSelf)
        {
            gameoverPnl.SetActive(true);
        }
        if(!gameover.Value && gameoverPnl.activeSelf)
        {
            gameoverPnl.SetActive(false);
        }
	}

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
