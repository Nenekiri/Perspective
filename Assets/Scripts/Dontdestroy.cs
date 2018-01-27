using UnityEngine;
using System.Collections;

public class Dontdestroy : MonoBehaviour {

    //called immediately as the scene starts
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}//end of DontDestroy
