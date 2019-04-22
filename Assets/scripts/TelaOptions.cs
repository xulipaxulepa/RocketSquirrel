using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TelaOptions : MonoBehaviour {

    public Image toogleOn;
    public Image toogleUIOn;
    public Text toogleSound;
    public Text toogleUI;
    AudioSource bgMusic;
    // Use this for initialization
    void Start () {
	    bgMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("Som") == 0)
        {
            bgMusic.Play();
        } 
    }
	
    public void ClickaSom()
    {
        if (PlayerPrefs.GetInt("Som") == 0)
        {
            PlayerPrefs.SetInt("Som", 1);
            bgMusic.Stop();
        } else
        {
            PlayerPrefs.SetInt("Som", 0);
            bgMusic.Play();
        }
    }

    public void ClickaUI()
    {
        if (PlayerPrefs.GetString("UI") == "Destro")
        {
            PlayerPrefs.SetString("UI", "Canhoto");
        }
        else
        {
            PlayerPrefs.SetString("UI", "Destro");
        }
    }

    // Update is called once per frame
    void Update () {
        if (PlayerPrefs.GetInt("Som") == 1)
        {
            toogleSound.text = "Sound: Off";
            toogleOn.enabled = false;            
        }
        if (PlayerPrefs.GetInt("Som") == 0)
        {
            toogleSound.text = "Sound: On";
            toogleOn.enabled = true;            
        }

        if(PlayerPrefs.GetString("UI") == "Destro")
        {
            toogleUIOn.enabled = true;
            toogleUI.text = "Right-Handed";
        }
        if (PlayerPrefs.GetString("UI") == "Canhoto")
        {
            toogleUIOn.enabled = false;
            toogleUI.text = "Left-Handed";
        }
    }
}
