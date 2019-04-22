using UnityEngine;
using System.Collections;

public class Noz : MonoBehaviour {

    public GameLogic gamelogic;
    public bool PowerUpVelocidade;
    public bool PowerUpInvencibilidade;
    public bool PowerUpMagnetismo;
    public float speed;
    public AudioSource[] somNoz;
    Rocket rocket;
    // Use this for initialization
    void Start () {
        rocket = GameObject.Find("rocket_0").GetComponent<Rocket>();
        gamelogic = GameObject.Find("Main Camera").GetComponent<GameLogic>();
        somNoz = GameObject.Find("Main Camera").GetComponents<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("Som") == 0)
            {
                if (PowerUpInvencibilidade == true || PowerUpVelocidade == true || PowerUpMagnetismo == true)
                {
                    somNoz[3].Play();
                    somNoz[0].volume = 0;
                }
                else
                {
                    somNoz[1].Play();
                }
            }
            
            if(PowerUpInvencibilidade == true)
            {
                rocket.PowerUpInvencibilidadeAtivo = true;
                GameObject.Destroy(this.gameObject);
            } else if (PowerUpVelocidade == true)
            {
                rocket.PowerUpVelocidadeAtivo = true;
                GameObject.Destroy(this.gameObject);
            } else if (PowerUpMagnetismo == true)
            {
                rocket.PowerUpMagnetismoAtivo = true;
                GameObject.Destroy(this.gameObject);
            } else
            {
                GameObject.Destroy(this.gameObject);
            }

        }
    }

    // Update is called once per frame
    void Update () {
        if (gamelogic.RocketEstaVivo == false)
        {
			somNoz[3].volume = 0;
		}
		
		if (gamelogic.RocketEstaVivo == true)
        {
            Vector2 pos = transform.position;
            pos.y = pos.y - speed * Time.deltaTime;
            transform.position = pos;
        }		

        if(transform.position.y <= -8)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
