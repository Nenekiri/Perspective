using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {


    //Main Menu methods
    public void NewGame()
    {
        //Deletes the game's data and lets the player start fresh
        PlayerPrefs.DeleteAll();
        Globals.FinalDoorSolved = false; 
        Application.LoadLevel("TestScene");
    }

    public void ChangeScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void NavigateURL(string URL)
    {
        Application.OpenURL(URL);
    }

    public void GTFO()
    {
        Application.Quit();
    }

    // Use this for initialization
    void Start ()
    {
	
	}//end of start
	
	// Update is called once per frame
	void Update ()
    {
	
	}//end of Update

}//end of MainMenuUI class
