using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }

    public void TelaJogo()
    {
        SceneManager.LoadScene("TelaJogo");
    }

    public void TelaCredito()
    {
        SceneManager.LoadScene("TelaCredito");
    }

    public void TelaInicial()
    {
        SceneManager.LoadScene("telaInicial");
    }

    public void TelaOptions()
    {
        SceneManager.LoadScene("TelaOptions");
    }

    public void SairJogo()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
