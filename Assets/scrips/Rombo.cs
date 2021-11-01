using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rombo : MonoBehaviour
{

    bool chasingPlayer = false;
    public Transform player;
    public float speed = 1;
    public float pushForce = 1;
    Rigidbody rig;
    public float vida = 5;
    PlayerControler playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerControler>();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Si el tanque esta persiguiendo al jugador, que siempre vuelva a ver hacia el y se mueva hacia adelante
        if (chasingPlayer)
        {
            // Rota al enemigo para que vea hacia el jugador
            Vector3 posicionJugador = player.position;
            posicionJugador.y = transform.position.y;

            transform.LookAt(posicionJugador);
            // Mueve hacia el frente al enemigo
            rig.velocity = transform.forward * speed + new Vector3(0, rig.velocity.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            chasingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            chasingPlayer = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Con los tags se puede saber con lo que estoy chocando
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Perder");
           
        }

        
        if (collision.gameObject.tag == "Bala")
        {
            vida -= 1;
            Destroy(collision.gameObject);
            if (vida <= 0)
            {
                playerScript.EnemigoMuerto();
                Destroy(gameObject);
            }
        }
    }
}