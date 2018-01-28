using UnityEngine;
using System.Collections;

public class MusicSingleton : MonoBehaviour {

    //declares this script as a singleton, which means that there will only be one of these at all times even when transitioning between scenes
    private static MusicSingleton instance = null;

    public static MusicSingleton Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public AudioSource s;
    public AudioClip ac;

    // Use this for initialization
    void Start ()
    {
        s = GetComponent<AudioSource>();

        s.clip = ac;
        s.Play();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Globals.FinalDoorSolved == true)
        {
            s.Stop();
            StartCoroutine(DelayThenEnd(30.0f)); 
        }

	
	}


    IEnumerator DelayThenEnd(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }


}//end of class
