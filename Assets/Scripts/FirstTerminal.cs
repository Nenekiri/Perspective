using UnityEngine;
using System.Collections;

public class FirstTerminal : MonoBehaviour {

    public GameObject interactText;
    private bool interactable = false;

    //set variables for the walls for the interact to turn them on and off
    public GameObject frontWall;
    public GameObject sectionLeft;
    public GameObject sectionRight;

    //create an AudioSource for the transmission sound
    public AudioSource audiosource; 

    //sound for the transmission going through
    public AudioClip transmission; 

	// Use this for initialization
	void Start ()
    {
        audiosource = GetComponent<AudioSource>(); 

        interactText.SetActive(false);
        sectionLeft.SetActive(false);
        sectionRight.SetActive(false); 

	}//end of start
	
	// Update is called once per frame
	void Update ()
    {
        //check to see if the stand can be interacted with
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("The interact button was hit successfully!");


                StartCoroutine(DelayThenOpen(2.5f));  

                //open up the wall and hide the original wall
                frontWall.SetActive(false); 
                sectionLeft.SetActive(true);
                sectionRight.SetActive(true);

            }
        }
	
	}//end of update

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            interactText.SetActive(true);
            interactable = true; 
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            interactText.SetActive(false);
            interactable = false; 
        }
    }


    IEnumerator DelayThenOpen(float delay)
    {
        audiosource.PlayOneShot(transmission);
        yield return new WaitForSeconds(delay);
        //OPEN UP THE TRANSMISSION
        Application.OpenURL("www.google.com");
    }

}//end of FirstTerminal class
