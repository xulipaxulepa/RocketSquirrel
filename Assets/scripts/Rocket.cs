using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public bool esquerda;
    public bool direita;
    public Rigidbody2D rb2d;
    public float speed;
    public Animator AnimaRocket;
    public GameLogic gamelogic;
    int verificaAnimacao;
    public bool PowerUpVelocidadeAtivo;
    public bool PowerUpInvencibilidadeAtivo;
    public bool PowerUpMagnetismoAtivo;

    // Use this for initialization
    void Start () {
        PowerUpInvencibilidadeAtivo = false;
        PowerUpMagnetismoAtivo = false;
        PowerUpVelocidadeAtivo = false;
        direita = false;
        esquerda = false;
        verificaAnimacao = 0;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Noz"))
        {
            gamelogic.Pontuacao++;
        }
    }

    public void VaiPraEsquerda()
    {
        if (gamelogic.RocketEstaVivo == true)
        {
            esquerda = true;
            direita = false;
            AnimaRocket.Play("ViraEsquerda");
        }
                    
    }

    public void VaiPraDireita()
    {
        if (gamelogic.RocketEstaVivo == true)
        {
            esquerda = false;
            direita = true;
            AnimaRocket.Play("ViraDireita");
        }
    }

    public void MovimentaRocket()
    {
        if(gamelogic.RocketEstaVivo == true)
        {
            Vector2 dir = Vector2.zero;

            if (esquerda == true)
            {
                dir.x = -1;
            }
            else if (direita == true)
            {
                dir.x = 1;
            }

            rb2d.velocity = dir * speed;
        }
        
    }

    public void estabilizaRocket()
    {
        if (transform.position.x >= 2)
        {
            if (verificaAnimacao == 0)
            {
                AnimaRocket.Play("EndireitaRocketDireita");
                verificaAnimacao++;
            }
            transform.position = new Vector2(2, -3.53f);
        }
        else if (transform.position.x <= -2)
        {
            if (verificaAnimacao == 0)
            {
                AnimaRocket.Play("EndireitaRocketEsquerda");
                verificaAnimacao++;
            }
            transform.position = new Vector2(-2, -3.53f);
        }
        else if (transform.position.x <= 2 && transform.position.x >= -2)
        {
            verificaAnimacao = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        MovimentaRocket();

        estabilizaRocket();        

    }
}
