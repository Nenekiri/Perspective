using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    public GameObject pausePanel;
    public bool isPaused;
    
     

	// Use this for initialization
	void Start ()
    {
        isPaused = false; 	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isPaused)
        {
            PauseGame(true); //show the pause screen
        }
        else
        {
            PauseGame(false);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            switchPause();
        }

    }//end of Update

    void PauseGame(bool state)
    {
        if (state)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);
        }
    }//end of PauseGame method

    public void switchPause()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }

    }

    public void ChangeScene(string scene)
    {

        Application.LoadLevel(scene);


    }

    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void GTFO()
    {
        Application.Quit(); 
    }


}//end of pausemanager
