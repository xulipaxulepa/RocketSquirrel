using UnityEngine;
using System.Collections;

public class TelaInicial : MonoBehaviour {

    public Animator AnimaRocketIntro;
    private float count;
    public int indiceanimacao;
	// Use this for initialization
	void Start () {
        count = 0f;
        indiceanimacao = 0;
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
