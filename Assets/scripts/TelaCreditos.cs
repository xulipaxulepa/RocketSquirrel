using UnityEngine;
using System.Collections;

public class TelaCreditos : MonoBehaviour {

    public GameObject placa;
    public SpriteRenderer texto;
    public Sprite[] textocredito = new Sprite[8];
    public float speed;
    public int indicetextocredito = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = placa.transform.position;
        pos.y = pos.y - speed * Time.deltaTime;
        placa.transform.position = pos;

        if(placa.transform.position.y < -7)
        {
            indicetextocredito++;
            placa.transform.position = new Vector2(0,7);
            texto.sprite = textocredito[indicetextocredito];            
        }

        if (indicetextocredito >= 8)
        {
            indicetextocredito = 0;
        }
    }
}
