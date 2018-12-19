using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public bool RocketEstaVivo;
    bool IniciouJogo = false;
    public float speed;
    float TimerTroncos;
    int padroesTroncos;
    Vector3 posicaoNoz = new Vector3(0, 8, 0);
    public GameObject bg1;
    public GameObject bg2;
    public GameObject NozNormal;
    public GameObject NozVelocidade;
    public GameObject NozInvencibilidade;
    public GameObject NozMagnetismo;
    public GameObject tronco1;
    public GameObject tronco2;
    public GameObject tronco3;
    public GameObject tronco4;
    public GameObject tronco5;
    public GameObject tronco6;
    public Animator AnimaRocket;
    public float TimerNozes;
    public float TimerNozesPowerUps;
    private float EscolhePowerUp;
    public Text TextoPontuacao;
    public Text yourscore;
    public Text hiscore;
    public Animation gameover;
    public Text ContagemRegressiva;
    public float ContRegressiva;
    public int Pontuacao;
    public Rocket rocket;
    public SpriteRenderer brilhoRocket;
    public float TimerDesativaPowerUp;

    // Use this for initialization
    void Start () {
        AnimaRocket.Play("intro");
        TimerTroncos = 3;
        padroesTroncos = Random.Range(1, 9);
    }

    public void OnGameStart()
    {
        Instantiate(NozNormal, posicaoNoz, Quaternion.identity);
        RocketEstaVivo = true;
        Pontuacao = 0;
        TextoPontuacao.text = Pontuacao.ToString();

        EscolhePowerUp = Random.Range(1, 3);
    }

    public void criaNozes()
    {
        TimerNozes += Time.deltaTime;
        TimerNozesPowerUps += Time.deltaTime;

        if (TimerNozes > 3)
        {
            Instantiate(NozNormal, posicaoNoz, Quaternion.identity);
            TimerNozes = 0;
        }

        if(TimerNozesPowerUps > 11 && EscolhePowerUp == 1) {
            Instantiate(NozVelocidade, posicaoNoz, Quaternion.identity);
            TimerNozesPowerUps = 0;
            EscolhePowerUp = Random.Range(1, 3);
        } else if (TimerNozesPowerUps > 11 && EscolhePowerUp == 2) {
            Instantiate(NozInvencibilidade, posicaoNoz, Quaternion.identity);
            TimerNozesPowerUps = 0;
            EscolhePowerUp = Random.Range(1, 3);
        } else if (TimerNozesPowerUps > 11 && EscolhePowerUp == 3) {
            Instantiate(NozMagnetismo, posicaoNoz, Quaternion.identity);
            TimerNozesPowerUps = 0;
            EscolhePowerUp = Random.Range(1, 3);
        }
    }

    public void contagemregressivainicial()
    {
        ContRegressiva += Time.deltaTime;

        if(ContRegressiva >= 0 && ContRegressiva < 1)
        {
            ContagemRegressiva.text = "3";
        } else if (ContRegressiva > 1 && ContRegressiva < 2)
        {
            ContagemRegressiva.text = "2";
        } else if (ContRegressiva > 2 && ContRegressiva < 3)
        {
            ContagemRegressiva.text = "1";
        } else if (ContRegressiva > 3 && ContRegressiva < 4)
        {
            ContagemRegressiva.text = "Go!";
        }
        else if (ContRegressiva > 5)
        {
            IniciouJogo = true;
            ContagemRegressiva.enabled = false;
            AnimaRocket.applyRootMotion = true;
            OnGameStart();
        } 
    }

    public void caiBG()
    {
        Vector2 pos1 = bg1.transform.position;
        pos1.y = pos1.y - speed * Time.deltaTime;
        bg1.transform.position = pos1;

        Vector2 pos2 = bg2.transform.position;
        pos2.y = pos2.y - speed * Time.deltaTime;
        bg2.transform.position = pos2;

        if (bg1.transform.position.y <= -20.45f)
        {
            bg1.transform.position = new Vector2(0.03f,40);
        } else if (bg2.transform.position.y <= -20.45f)
        {
            bg2.transform.position = new Vector2(0.03f, 40.3f);
        }
    }

    public void criaTroncos()
    {
        TimerTroncos += Time.deltaTime;

        if(TimerTroncos > 2 && padroesTroncos == 1)
        {
            TimerTroncos = 0;
            posicaoNoz = new Vector3(-1.5f, 8, 0);
            Instantiate(tronco1, new Vector3(-1.55f,8,0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(1.33f, 15, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > 2 && padroesTroncos == 2)
        {
            TimerTroncos = 0;
            posicaoNoz = new Vector3(0, 8, 0);
            Instantiate(tronco1, new Vector3(-3, 7, 0), Quaternion.identity);
            Instantiate(tronco2, new Vector3(-3, 10, 0), Quaternion.identity);
            Instantiate(tronco5, new Vector3(-3, 13, 0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(3, 7, 0), Quaternion.identity);
            Instantiate(tronco4, new Vector3(3, 10, 0), Quaternion.identity);
            Instantiate(tronco6, new Vector3(4.05f, 13, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > 2 && padroesTroncos == 3)
        {
            TimerTroncos = 0;
            posicaoNoz = new Vector3(1.5f, 8, 0);
            Instantiate(tronco3, new Vector3(1.55f, 8, 0), Quaternion.identity);
            Instantiate(tronco1, new Vector3(-1.33f, 15, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        }
        else if (TimerTroncos > 2 && padroesTroncos == 4)
        {
            TimerTroncos = 0;
            posicaoNoz = new Vector3(1.5f, 8, 0);
            Instantiate(tronco2, new Vector3(-1.43f, 8, 0), Quaternion.identity);
            Instantiate(tronco5, new Vector3(-1.4f, 14, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > 2 && padroesTroncos == 5)
        {
            TimerTroncos = 0;
            posicaoNoz = new Vector3(-1.5f, 8, 0);
            Instantiate(tronco3, new Vector3(1.33f, 8, 0), Quaternion.identity);
            Instantiate(tronco4, new Vector3(1.33f, 14, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > 2 && padroesTroncos == 6)
        {
            TimerTroncos = 0;
            posicaoNoz = new Vector3(-1.5f, 8, 0);
            Instantiate(tronco1, new Vector3(-1.55f, 7, 0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(2.33f, 13, 0), Quaternion.identity);
            Instantiate(tronco2, new Vector3(-1.43f, 18, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > 2 && padroesTroncos == 7)
        {
            TimerTroncos = 0;
            posicaoNoz = new Vector3(-1.5f, 8, 0);
            Instantiate(tronco3, new Vector3(1.33f, 7, 0), Quaternion.identity);
            Instantiate(tronco2, new Vector3(-1.43f, 13, 0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(1.33f, 18, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > 2 && padroesTroncos == 8)
        {
            TimerTroncos = 0;
            posicaoNoz = new Vector3(-1.5f, 8, 0);
            Instantiate(tronco2, new Vector3(-3, 8, 0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(3, 8, 0), Quaternion.identity);
            Instantiate(tronco6, new Vector3(2.35f, 14, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > 2 && padroesTroncos == 9)
        {
            TimerTroncos = 0;
            posicaoNoz = new Vector3(-1.5f, 8, 0);
            Instantiate(tronco2, new Vector3(-3, 8, 0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(3, 8, 0), Quaternion.identity);
            Instantiate(tronco5, new Vector3(-2.35f, 14, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        }
    }

    public void powerUpsRocket()
    {
        if(rocket.PowerUpVelocidadeAtivo == true && TimerDesativaPowerUp < 3)
        {
            TimerDesativaPowerUp += Time.deltaTime;
            brilhoRocket.color = new Color(1f, 0f, 0f, 1f);
            speed = 5;
            GameObject[] allObjectsNoz = GameObject.FindGameObjectsWithTag("Noz");
            foreach (GameObject go in allObjectsNoz)
            {
                go.GetComponent<Noz>().speed = 5;
            }
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<Troncos>().speed = 5;
            }
        } else if (rocket.PowerUpMagnetismoAtivo == true && TimerDesativaPowerUp < 3)
        {
            TimerDesativaPowerUp += Time.deltaTime;
            brilhoRocket.color = new Color(0f, 0f, 1f, 1f);
            GameObject[] allObjectsNoz = GameObject.FindGameObjectsWithTag("Noz");
            foreach (GameObject go in allObjectsNoz)
            {
                go.transform.position = Vector2.MoveTowards(go.transform.position, rocket.transform.position, 0.5f);
            }
        } else if (rocket.PowerUpInvencibilidadeAtivo == true && TimerDesativaPowerUp < 3)
        {
            TimerDesativaPowerUp += Time.deltaTime;
            brilhoRocket.color = new Color(1f, 1f, 0f, 1f);
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<PolygonCollider2D>().enabled = false;
            }
        }

        if (TimerDesativaPowerUp > 3)
        {
            GameObject[] allObjectsNoz = GameObject.FindGameObjectsWithTag("Noz");
            foreach (GameObject go in allObjectsNoz)
            {
                go.GetComponent<Noz>().speed = 10;
            }
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<Troncos>().speed = 10;
                go.GetComponent<PolygonCollider2D>().enabled = true;
            }

            brilhoRocket.color = new Color(1f, 1f, 1f, 0);
            rocket.PowerUpVelocidadeAtivo = false;
            rocket.PowerUpMagnetismoAtivo = false;
            rocket.PowerUpInvencibilidadeAtivo = false;
            speed = 10;
            TimerDesativaPowerUp = 0;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (IniciouJogo == false)
        {
            contagemregressivainicial();
            caiBG();
        }

        if(RocketEstaVivo == true)
        {
            caiBG();

            criaNozes();

            criaTroncos();

            powerUpsRocket();

            TextoPontuacao.text = Pontuacao.ToString();
        }

        if (RocketEstaVivo == false && IniciouJogo == true)
        {
            if(Pontuacao > PlayerPrefs.GetInt("HiScore"))
            {
                PlayerPrefs.SetInt("HiScore", Pontuacao);
            }            
            gameover.Play();
            hiscore.text = "Your High Score: " + PlayerPrefs.GetInt("HiScore").ToString();
            yourscore.text = "Points: "+Pontuacao.ToString();
        }


    }
}
