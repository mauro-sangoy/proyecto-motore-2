using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ControlBot : MonoBehaviour
{
    private int HP;
    private GameObject Player;
    public int Velocidad;

    private void Start()
    {
        HP = 100;
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.LookAt(Player.transform); //rota segun lka posicion de otro objeto
        transform.Translate(Velocidad * Vector3.forward * Time.deltaTime); //avanza solo hacia adelante
    }

    public void RecibirDaño() 
    {
        HP = HP - 25;

        if (HP <= 0) 
        {
            this.Desaparecer();
        }  
    }
    private void Desaparecer()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala")) 
        {
            RecibirDaño();
        }
    }
}
