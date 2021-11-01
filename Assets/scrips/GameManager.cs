using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VolverAJugar()
    {       
       SceneManager.LoadScene("KillerBox");
    }
    public void EmpezarAJugar()
    {
        SceneManager.LoadScene("KillerBox");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
