using UnityEngine;
using System.Collections;


public class TelaInicial : MonoBehaviour {

    public Animator AnimaRocketIntro;
    private float count;
    public int indiceanimacao;
    AudioSource bgMusic;
    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("Morreu", 0);
        playerOptions();
        count = 0f;
        indiceanimacao = 0;
        bgMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("Som") == 0)
        {
            bgMusic.Play();
        }
    }
    
    public void playerOptions()
    {
        if (PlayerPrefs.GetInt("Som") == 1)
        {
            PlayerPrefs.SetInt("Som", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Som", 0);
        }
        if (PlayerPrefs.GetString("UI") == "Canhoto")
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
        count += Time.deltaTime;

        if(count > 5f)
        {
            count = 0f;
            if(indiceanimacao == 0)
            {
                AnimaRocketIntro.Play("intro rocket extra1");
                indiceanimacao++;
            } else if (indiceanimacao == 1)
            {
                AnimaRocketIntro.Play("intro rocket extra2");
                indiceanimacao++;
            } else if (indiceanimacao == 2)
            {
                AnimaRocketIntro.Play("intro rocket extra3");
                indiceanimacao = 0;
            }

        }
	}
}
