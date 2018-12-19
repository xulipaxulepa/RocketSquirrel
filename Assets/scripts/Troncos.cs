using UnityEngine;
using System.Collections;

public class Troncos : MonoBehaviour {

    public GameLogic gamelogic;
    public float speed;
    // Use this for initialization
    void Start () {
        gamelogic = GameObject.Find("Main Camera").GetComponent<GameLogic>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {       
        gamelogic.RocketEstaVivo = false;        
    }

    // Update is called once per frame
    void Update () {
        if(gamelogic.RocketEstaVivo == true)
        {
            Vector2 pos = transform.position;
            pos.y = pos.y - speed * Time.deltaTime;
            transform.position = pos;
        } 

        if (transform.position.y <= -8)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
