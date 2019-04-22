using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public bool RocketEstaVivo;
    public bool IniciouJogo = false;
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
    public SpriteRenderer spriteRocket;
    public float TimerDesativaPowerUp;
    float timerCriaNozes;
    float timerCriaTroncos;
    float timerRocketMorto;
    public Animator slideToMove;
    public Animator clickToMove;
    public AudioSource musicaDoJogo;
    public RectTransform scoreUI;
    bool subScore;

    // Use this for initialization
    void Start () {
        subScore = true;
        AnimaRocket.Play("intro");
        TimerTroncos = 0;
        timerCriaNozes = 2;
        timerCriaTroncos = 7;
        padroesTroncos = Random.Range(1, 9);
        if(PlayerPrefs.GetString("UI") == "Canhoto")
        {
            scoreUI.localPosition = new Vector2(292, 546);
        }        

        if (PlayerPrefs.GetInt("Som") == 0)
        {
            musicaDoJogo.Play();
        }

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

        if (TimerNozes > timerCriaNozes)
        {
            TimerNozes = 0;
            float posX = Random.Range(-2, 2);
            posicaoNoz = new Vector3(posX, 8, 0);
            Instantiate(NozNormal, posicaoNoz, Quaternion.identity);            
        }

        if(TimerNozesPowerUps > 11 && EscolhePowerUp == 1) {
            Instantiate(NozVelocidade, posicaoNoz, Quaternion.identity);
            TimerNozesPowerUps = 0;
            EscolhePowerUp = Random.Range(1, 4);
        } else if (TimerNozesPowerUps > 11 && EscolhePowerUp == 2) {
            Instantiate(NozInvencibilidade, posicaoNoz, Quaternion.identity);
            TimerNozesPowerUps = 0;
            EscolhePowerUp = Random.Range(1, 4);
        } else if (TimerNozesPowerUps > 11 && EscolhePowerUp == 3) {
            Instantiate(NozMagnetismo, posicaoNoz, Quaternion.identity);
            TimerNozesPowerUps = 0;
            EscolhePowerUp = Random.Range(1, 4);
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
            slideToMove.Play("slidetomovee");
            clickToMove.Play("clicktomovee");
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
            bg1.transform.position = new Vector2(0.03f, bg2.transform.up.y * 40.5f);            
        } else if (bg2.transform.position.y <= -20.45f)
        {
            bg2.transform.position = new Vector2(0.03f, bg1.transform.up.y * 40.5f);
        }
    }

    public void criaTroncos()
    {
        TimerTroncos += Time.deltaTime;

        if(TimerTroncos > timerCriaTroncos && padroesTroncos == 1)
        {
            TimerTroncos = 0;
            Instantiate(tronco1, new Vector3(-1f,8,0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(1.33f, 15, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > timerCriaTroncos && padroesTroncos == 2)
        {
            TimerTroncos = 0;
            Instantiate(tronco1, new Vector3(-2.5f, 7, 0), Quaternion.identity);
            Instantiate(tronco2, new Vector3(-2.5f, 10, 0), Quaternion.identity);
            Instantiate(tronco5, new Vector3(-2.5f, 13, 0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(2.5f, 7, 0), Quaternion.identity);
            Instantiate(tronco4, new Vector3(2.5f, 10, 0), Quaternion.identity);
            Instantiate(tronco6, new Vector3(2.5f, 13, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > timerCriaTroncos && padroesTroncos == 3)
        {
            TimerTroncos = 0;
            Instantiate(tronco3, new Vector3(1.55f, 8, 0), Quaternion.identity);
            Instantiate(tronco1, new Vector3(-1.33f, 15, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        }
        else if (TimerTroncos > timerCriaTroncos && padroesTroncos == 4)
        {
            TimerTroncos = 0;
            Instantiate(tronco2, new Vector3(-1.43f, 8, 0), Quaternion.identity);
            Instantiate(tronco5, new Vector3(-1.4f, 14, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > timerCriaTroncos && padroesTroncos == 5)
        {
            TimerTroncos = 0;
            Instantiate(tronco3, new Vector3(1.33f, 8, 0), Quaternion.identity);
            Instantiate(tronco4, new Vector3(1.33f, 14, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > timerCriaTroncos && padroesTroncos == 6)
        {
            TimerTroncos = 0;
            Instantiate(tronco1, new Vector3(-1f, 7, 0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(2f, 13, 0), Quaternion.identity);
            Instantiate(tronco2, new Vector3(-1.43f, 18, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > timerCriaTroncos && padroesTroncos == 7)
        {
            TimerTroncos = 0;
            Instantiate(tronco3, new Vector3(1.33f, 7, 0), Quaternion.identity);
            Instantiate(tronco2, new Vector3(-1.43f, 13, 0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(1.33f, 18, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > timerCriaTroncos && padroesTroncos == 8)
        {
            TimerTroncos = 0;
            Instantiate(tronco2, new Vector3(-3, 8, 0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(3, 8, 0), Quaternion.identity);
            Instantiate(tronco6, new Vector3(2f, 14, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        } else if (TimerTroncos > timerCriaTroncos && padroesTroncos == 9)
        {
            TimerTroncos = 0;
            Instantiate(tronco2, new Vector3(-3, 8, 0), Quaternion.identity);
            Instantiate(tronco3, new Vector3(3, 8, 0), Quaternion.identity);
            Instantiate(tronco5, new Vector3(-2f, 14, 0), Quaternion.identity);
            padroesTroncos = Random.Range(1, 9);
        }
    }

    public void powerUpsRocket()
    {
        if(rocket.PowerUpVelocidadeAtivo == true && TimerDesativaPowerUp < 3)
        {
            TimerDesativaPowerUp += Time.deltaTime;
            brilhoRocket.color = new Color(1f, 0f, 0f, 1f);
            timerCriaTroncos = timerCriaTroncos * 2;
            timerCriaNozes = 1;
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
            spriteRocket.color = new Color(1f, 1f, 1f, 0.5f);
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
                go.GetComponent<Noz>().speed = speed;
            }
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<Troncos>().speed = speed;
                go.GetComponent<PolygonCollider2D>().enabled = true;
            }
            musicaDoJogo.volume = 1;
            brilhoRocket.color = new Color(1f, 1f, 1f, 0);
            spriteRocket.color = new Color(1f, 1f, 1f, 1f);
            rocket.PowerUpVelocidadeAtivo = false;
            rocket.PowerUpMagnetismoAtivo = false;
            rocket.PowerUpInvencibilidadeAtivo = false;
            speed = 7;
            TimerDesativaPowerUp = 0;
        }
    }

    public void DificuldadeJogo()
    {
        if(Pontuacao >= 5 && Pontuacao < 10 && rocket.PowerUpVelocidadeAtivo == false)
        {
            if(rocket.PowerUpMagnetismoAtivo == true)
            {
                timerCriaNozes = 1;
            } else
            {
                timerCriaNozes = 3;
            }
            
            timerCriaTroncos = 5;
            speed = 8;

            GameObject[] allObjectsNoz = GameObject.FindGameObjectsWithTag("Noz");
            foreach (GameObject go in allObjectsNoz)
            {
                go.GetComponent<Noz>().speed = speed;
            }
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<Troncos>().speed = speed;
            }
        } else if (Pontuacao >= 10 && Pontuacao < 15 && rocket.PowerUpVelocidadeAtivo == false)
        {
            if (rocket.PowerUpMagnetismoAtivo == true)
            {
                timerCriaNozes = 1;
            }
            else
            {
                timerCriaNozes = 4;
            }            
            timerCriaTroncos = 4;
            speed = 9;

            GameObject[] allObjectsNoz = GameObject.FindGameObjectsWithTag("Noz");
            foreach (GameObject go in allObjectsNoz)
            {
                go.GetComponent<Noz>().speed = speed;
            }
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<Troncos>().speed = speed;
            }
        } else if (Pontuacao >= 15 && Pontuacao < 20 && rocket.PowerUpVelocidadeAtivo == false)
        {
            if (rocket.PowerUpMagnetismoAtivo == true)
            {
                timerCriaNozes = 1;
            }
            else
            {
                timerCriaNozes = 5;
            }
            
            timerCriaTroncos = 3;
            speed = 10;

            GameObject[] allObjectsNoz = GameObject.FindGameObjectsWithTag("Noz");
            foreach (GameObject go in allObjectsNoz)
            {
                go.GetComponent<Noz>().speed = speed;
            }
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<Troncos>().speed = speed;
            }
        } else if (Pontuacao >= 20 && Pontuacao < 25 && rocket.PowerUpVelocidadeAtivo == false)
        {
            if (rocket.PowerUpMagnetismoAtivo == true)
            {
                timerCriaNozes = 1;
            }
            else
            {
                timerCriaNozes = 6;
            }
            
            timerCriaTroncos = 2;
            speed = 11;

            GameObject[] allObjectsNoz = GameObject.FindGameObjectsWithTag("Noz");
            foreach (GameObject go in allObjectsNoz)
            {
                go.GetComponent<Noz>().speed = speed;
            }
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<Troncos>().speed = speed;
            }
        }
        else if (Pontuacao >= 25 && Pontuacao < 30 && rocket.PowerUpVelocidadeAtivo == false)
        {
            if (rocket.PowerUpMagnetismoAtivo == true)
            {
                timerCriaNozes = 1;
            }
            else
            {
                timerCriaNozes = 7;
            }
            
            timerCriaTroncos = 2;
            speed = 12;

            GameObject[] allObjectsNoz = GameObject.FindGameObjectsWithTag("Noz");
            foreach (GameObject go in allObjectsNoz)
            {
                go.GetComponent<Noz>().speed = speed;
            }
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<Troncos>().speed = speed;
            }
        }
        else if (Pontuacao >= 30 && Pontuacao < 35 && rocket.PowerUpVelocidadeAtivo == false)
        {
            if (rocket.PowerUpMagnetismoAtivo == true)
            {
                timerCriaNozes = 1;
            }
            else
            {
                timerCriaNozes = 8;
            }
            
            timerCriaTroncos = 2;
            speed = 13;

            GameObject[] allObjectsNoz = GameObject.FindGameObjectsWithTag("Noz");
            foreach (GameObject go in allObjectsNoz)
            {
                go.GetComponent<Noz>().speed = speed;
            }
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<Troncos>().speed = speed;
            }
        }
        else if (Pontuacao >= 35 && rocket.PowerUpVelocidadeAtivo == false)
        {
            if (rocket.PowerUpMagnetismoAtivo == true)
            {
                timerCriaNozes = 1;
            }
            else
            {
                timerCriaNozes = 10;
            }
            
            timerCriaTroncos = 2;
            speed = 15;

            GameObject[] allObjectsNoz = GameObject.FindGameObjectsWithTag("Noz");
            foreach (GameObject go in allObjectsNoz)
            {
                go.GetComponent<Noz>().speed = speed;
            }
            GameObject[] allObjectsTroncos = GameObject.FindGameObjectsWithTag("Tronco");
            foreach (GameObject go in allObjectsTroncos)
            {
                go.GetComponent<Troncos>().speed = speed;
            }
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

            DificuldadeJogo();

            TextoPontuacao.text = Pontuacao.ToString();
        }

        if (RocketEstaVivo == false && IniciouJogo == true)
        {
            timerRocketMorto += Time.deltaTime;

            if(timerRocketMorto < 1 && PlayerPrefs.GetInt("Som") == 0)
            {
                musicaDoJogo.Stop();
            }

            if (timerRocketMorto > 1)
            {
                if (Pontuacao > PlayerPrefs.GetInt("HiScore") && subScore == true)
                {
                    subScore = false;
                    PlayerPrefs.SetInt("HiScore", Pontuacao);
                    GameObject.Find("Main Camera").GetComponent<LeaderBoards>().SubmitScore(Pontuacao);
                }
                gameover.Play();
                hiscore.text = PlayerPrefs.GetInt("HiScore").ToString();
                yourscore.text = Pontuacao.ToString();
            }            
        }
    }
}
