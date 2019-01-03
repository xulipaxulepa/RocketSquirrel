using UnityEngine;
using System.Collections;

public class MoveRocket : MonoBehaviour {

    public bool direita;
    public bool esquerda;
    public int saiAnimacaoDireita;
    public int saiAnimacaoEsquerda;
    public Animator rocketAnimado;
    public GameObject rocket;
    public GameLogic rocketScript;
    public float speed;
    public float posRocket = 0;
	// Use this for initialization
	void Start () {
	
	}

    void OnMouseDrag()
    {
        if(rocketScript.RocketEstaVivo == true)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if(rocket.transform.position.x - objPosition.x > 2)
            {

            } else if (rocket.transform.position.x - objPosition.x < -2)
            {

            } else
            {
                rocket.transform.position = new Vector3(objPosition.x, -1f, objPosition.z);
            }

                        
        }        
    }

    public void animaRocket()
    {
        if(rocket.transform.position.x > posRocket)
        {
            direita = true;
            esquerda = false;

            if (direita == true)
            {
                rocket.transform.rotation = Quaternion.Lerp(rocket.transform.rotation, Quaternion.Euler(0, 0, -45), Time.deltaTime * speed);

            }
            posRocket = rocket.transform.position.x;
        } if (rocket.transform.position.x < posRocket)
        {
            direita = false;
            esquerda = true;

            if (esquerda == true)
            {
                rocket.transform.rotation = Quaternion.Lerp(rocket.transform.rotation, Quaternion.Euler(0, 0, 45), Time.deltaTime * speed);

            }
            posRocket = rocket.transform.position.x;
        }
    }

    public void estabilizaRocket()
    {
        if (rocket.transform.position.x >= 2)
        {
            rocket.transform.position = new Vector2(2.5f, -1);
        }
        else if (rocket.transform.position.x <= -2)
        {
            rocket.transform.position = new Vector2(-2.5f, -1);
        }
    }

    // Update is called once per frame
    void Update () {

        if (rocketScript.IniciouJogo == true)
        {
            estabilizaRocket();

            animaRocket();
        }
    }
}
