using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class InputTerminalColors : MonoBehaviour {

    //set variables for the walls for the interact to turn them on and off
    public GameObject frontWall;
    public GameObject sectionFrontLeft;
    public GameObject sectionFrontRight;

    public GameObject interactText;
    private bool interactable = false;


    //Get the text for the input field
    public Text inputText;

    //The input panel, need this to set and hide the input panel
    public GameObject inputTextPanel;

    //sound controls for object
    public AudioSource audios;

    //sounds to play for good/bad input
    public AudioClip good;
    public AudioClip bad;

    //sound for pop-up
    public AudioClip popup;

    // Use this for initialization
    void Start ()
    {
        //hide the input text
        interactText.SetActive(false);

        //hide the sections of the front wall
        sectionFrontLeft.SetActive(false);
        sectionFrontRight.SetActive(false);

        //get the audiosource
        audios = this.gameObject.GetComponent<AudioSource>();

        //hide the panel on start
        inputTextPanel.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {
        //check to see if the stand can be interacted with
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("The interact button was hit successfully!");

                //play popup sound
                audios.PlayOneShot(popup);

                //pop up the input canvas so it prompts the player for the passcode
                inputTextPanel.SetActive(true);

                //stop time to keep the character still
                Time.timeScale = 0.0f;
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

    public void CloseModal()
    {
        inputTextPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }


    public void ConfirmCode()
    {

        if (inputText.text.ToLower() == "rgb")
        {
            //play sound effect for opening doors or chime of being correct
            audios.PlayOneShot(good);

            //open up the front wall and hide the original wall
            frontWall.SetActive(false);
            sectionFrontLeft.SetActive(true);
            sectionFrontRight.SetActive(true);

            //close out modal after correct input is received
            CloseModal();
        }
        else
        {
            //play sound effect for wrong input

            //clear out text field for more input
            inputText.text = "";
            audios.PlayOneShot(bad);

        }




    }//end of ConfirmCode

}//end of class
