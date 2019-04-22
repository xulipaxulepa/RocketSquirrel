using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float speed;
    public Animator AnimaRocket;
    public GameLogic gamelogic;
    public bool PowerUpVelocidadeAtivo;
    public bool PowerUpInvencibilidadeAtivo;
    public bool PowerUpMagnetismoAtivo;

    // Use this for initialization
    void Start () {
        PowerUpInvencibilidadeAtivo = false;
        PowerUpMagnetismoAtivo = false;
        PowerUpVelocidadeAtivo = false;
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Noz"))
        {
            gamelogic.Pontuacao++;
        }
    }
    

    

    // Update is called once per frame
    void FixedUpdate () {
        if(gamelogic.RocketEstaVivo == false)
        {
            Vector2 pos = transform.position;
            pos.y = pos.y - speed * Time.deltaTime;
            transform.position = pos;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -180), Time.deltaTime * 3);
        }           

    }
}
